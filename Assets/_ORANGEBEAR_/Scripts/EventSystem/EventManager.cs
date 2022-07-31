using System;

public class EventManager<T>
{
    #region General Game Events

    public static Action<T> OnGameStart;
    public static Action<T> OnGameComplete;
    public static Action<T> GetLevelNumber;

    #endregion

    #region Level Events

    public static Action<T> GetPath;
    public static Action<T> GetMovementControlWithPath;
    public static Action<T> CanFollowPath;
    public static Action<T> CanMoveHorizontal;

    #endregion
}