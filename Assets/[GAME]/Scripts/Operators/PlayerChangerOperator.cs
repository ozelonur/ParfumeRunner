using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Managers;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class PlayerChangerOperator : Operator
    {
        #region Serialize Fields

        [SerializeField] private CharacterAnimateOperator[] bottles;

        #endregion

        #region Private Variables

        private int _currentIndex = -1;

        #endregion

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.ChangePlayer += ChangePlayer;
        }

        private void OnDisable()
        {
            EventManager<object[]>.ChangePlayer -= ChangePlayer;
        }

        private void ChangePlayer(object[] obj)
        {
            int index = (int) obj[0];

            if (index == _currentIndex)
            {
                return;
            }

            for (int i = 0; i < bottles.Length; i++)
            {
                bottles[i].gameObject.SetActive(i == index);
                PlayerManager.Instance.currentPlayer.currentAnimator = bottles[index];
            }

            if (_currentIndex != -1)
            {
                PlayerManager.Instance.currentPlayer.currentAnimator.PlayAnimation(AnimationType.Walk);
            }

            _currentIndex = index;
        }

        #endregion
    }
}