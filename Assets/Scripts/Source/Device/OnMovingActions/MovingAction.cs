using Source;

public readonly struct MovingAction
{
    public readonly float StartTime;
    public readonly float Duration;
    public readonly IOnMovingAction OnMovingAction;

    public readonly bool IsInfinityAction;
    
    public MovingAction(IOnMovingAction movingAction, float duration, float startTime = 0)
    {
        OnMovingAction = movingAction;
        StartTime = startTime;
        Duration = duration;
        IsInfinityAction = false;
    }
    
    public MovingAction(IOnMovingAction movingAction, float startTime = 0)
    {
        OnMovingAction = movingAction;
        StartTime = startTime;
        Duration = -1;
        IsInfinityAction = true;
    }
}