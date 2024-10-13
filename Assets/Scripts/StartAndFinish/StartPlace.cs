using UnityEngine;

public class StartPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamagable>() != null)
        {
            EventBus.onTimerStart?.Invoke();
        }
    }
}
