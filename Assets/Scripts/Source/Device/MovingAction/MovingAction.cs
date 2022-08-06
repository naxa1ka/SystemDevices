using Source;

public readonly struct MovingAction
{
    public readonly float StartTime;
    public readonly float Duration;
    public readonly IMovingAction IMovingAction;

    public readonly bool IsInfinityAction;
    
    public MovingAction(IMovingAction movingAction, float duration, float startTime = 0)
    {
        IMovingAction = movingAction;
        StartTime = startTime;
        Duration = duration;
        IsInfinityAction = false;
    }
    
    public MovingAction(IMovingAction movingAction, float startTime = 0)
    {
        IMovingAction = movingAction;
        StartTime = startTime;
        Duration = -1;
        IsInfinityAction = true;
    }
}