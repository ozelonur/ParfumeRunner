using System;

public class EventManager <T>
{
    #region General Game Events

    public static  Action<T> OnGameStart;
    public static  Action<T> OnGameComplete;

    #endregion
}
