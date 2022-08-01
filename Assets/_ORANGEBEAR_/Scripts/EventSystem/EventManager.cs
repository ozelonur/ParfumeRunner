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
    public static Action<T> GetFollowTransform;
    public static Action<T> ChangePlayer;

    #endregion

    #region Price Events

    public static Action<T> GateInteracted;
    public static Action<T> UpdatePriceUI;

    #endregion

    #region Camera Events

    public static Action<T> DetachCamera;

    #endregion
}