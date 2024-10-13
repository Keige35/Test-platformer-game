using UnityEngine;

public class PlayerController : MonoBehaviour, IWindy
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private InputController _inputController;
    private Vector3 windVector = Vector3.zero;
    private bool isCharactermoving = true;
    private Rigidbody rb;
    private float rotationY = 0f;
    private bool isGrounded;

    void Start()
    {
        _inputController = GetComponent<InputController>();
        rb = GetComponent<Rigidbody>();
        EventBus.onPlayerDied += stopCharacterMoving;
        EventBus.onPlayerWin += stopCharacterMoving;
    }

    void Update()
    {
        if(isCharactermoving)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

            Vector3 move = transform.right * _inputController.moveHorizontal + transform.forward * _inputController.moveVertical;
            rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime + windVector.normalized * Time.deltaTime * 2);

            float mouseX = _inputController.mouseX * mouseSensitivity;
            rotationY += mouseX;
            transform.localEulerAngles = new Vector3(0, rotationY, 0);

            if (_inputController.isJump && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

        }
       
    }

    public void Wind(Vector3 wind)
    {
        windVector = wind;
    }
  
    private void stopCharacterMoving()
    {
        isCharactermoving = false;
        EventBus.onPlayerDied -= stopCharacterMoving;
        EventBus.onPlayerWin -= stopCharacterMoving;
    }
}
