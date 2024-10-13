using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [SerializeField] private GameObject spinGameObject;
    [SerializeField] private float spinSpeed = 50;

    void Update()
    {
        spinGameObject.transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
