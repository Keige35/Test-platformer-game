using UnityEngine;

public class InputController : MonoBehaviour
{
    public float moveHorizontal {  get; private set; }
    public float moveVertical {  get; private set; }
    public float mouseX { get; private set; }
    public bool isJump {  get; private set; }
    public bool closeGame {  get; private set; }

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        isJump = Input.GetButtonDown("Jump");
        closeGame = Input.GetButton("Cancel");
        if(closeGame)
        {
            EventBus.onCloseGame?.Invoke();
        }
    }
}
