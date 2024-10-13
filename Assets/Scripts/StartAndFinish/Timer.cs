using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool timerEnabled;
    private float  seconds = 0;

    private void Start()
    {
        EventBus.onTimerStart += TimerStart;
        EventBus.onPlayerWin += TimerStop;
        EventBus.onFinishTime += ReturnTime;
    }

    void Update()
    {
        if (timerEnabled)
        {
            seconds += Time.deltaTime;
        }
    }

   private void TimerStart()
    {
        timerEnabled = true;
        EventBus.onTimerStart -= TimerStart;
    }

    private void TimerStop()
    {
        timerEnabled = false;
        EventBus.onPlayerWin -= TimerStop;
    }
    private int ReturnTime()
    {
        return Mathf.RoundToInt(seconds);
    }
}
