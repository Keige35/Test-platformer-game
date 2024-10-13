using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamagable>() != null)
        {
            EventBus.onPlayerWin?.Invoke();
        }
    }
}
