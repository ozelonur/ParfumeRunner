using System;
using UnityEngine;

public class Operator : MonoBehaviour
{
    protected void Announce(Action<object[]> eventName, params object[] args)
    {
        eventName?.Invoke(args);
    }
}
