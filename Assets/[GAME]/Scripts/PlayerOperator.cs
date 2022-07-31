#region Header

// Developed by Onur ÖZEL
// onur.ozel@triflesgames.com

#endregion

using System;

namespace _GAME_.Scripts
{
    public class PlayerOperator : Operator
    {
        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.OnGameStart += OnGameStart;
        }

        private void OnDisable()
        {
            EventManager<object[]>.OnGameStart -= OnGameStart;
        }

        #endregion

        #region Event Methods

        private void OnGameStart(object[] obj)
        {
            Announce(EventManager<object[]>.CanFollowPath, true);
        }

        #endregion
    }
}