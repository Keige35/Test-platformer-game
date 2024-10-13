using System;

public static class EventBus 
{
    public static Action onPlayerDied;
    public static Action onPlayerWin;
    public static Action onCloseGame;
    public static Action onTimerStart;
    public static Func<int> onFinishTime;
}
