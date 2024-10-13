using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    [SerializeField] private string currentState;
    [SerializeField] private Animator _animator;
    public CharacterAnimationController characterAnimationController { get; private set; }
    private InputController _inputController;
    private StateMachine _stateMachine;
   
    private void Awake()
    {
        _inputController = GetComponent<InputController>();
        InitializeStateMachine();
    }

    private void Update()
    {
        _stateMachine.OnUpdate();
        currentState = _stateMachine.CurrentState.ToString();
    }
    private void InitializeStateMachine()
    {
        var characterAnimatorController = new CharacterAnimationController(_animator);
       
        var idleState = new CharacterIdleState(characterAnimatorController);
        var runState = new CharacterRunState(characterAnimatorController, _inputController);

        idleState.AddTransition(new StateTransition(runState, new FuncStateCondition(() => _inputController.moveHorizontal != 0 | _inputController.moveVertical !=0)));
        runState.AddTransition(new StateTransition(idleState, new FuncStateCondition(() => _inputController.moveHorizontal == 0 & _inputController.moveVertical == 0)));

        _stateMachine = new StateMachine(idleState);
    } 
}
