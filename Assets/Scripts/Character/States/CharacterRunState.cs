public class CharacterRunState : State
{
    private readonly CharacterAnimationController _characterAnimationController;
    private readonly InputController _inputController;
    public CharacterRunState(CharacterAnimationController characterAnimationController, InputController inputController)
    {
        _characterAnimationController = characterAnimationController;
        _inputController = inputController;
    }

    public override void OnStateEnter()
    {
        _characterAnimationController.SetBool(CharacterAnimationParameter.Run, true);
    }

    public override void OnStateExit()
    {
        _characterAnimationController.SetBool(CharacterAnimationParameter.Run, false);
    }

    public override void OnUpdate()
    {
        _characterAnimationController.SetFloat(CharacterAnimationParameter.Horizontal, _inputController.moveHorizontal);
        _characterAnimationController.SetFloat(CharacterAnimationParameter.Vertical, _inputController.moveVertical);
    }
    
}
