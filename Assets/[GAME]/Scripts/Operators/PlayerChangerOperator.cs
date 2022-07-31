using _GAME_.Scripts.Managers;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class PlayerChangerOperator : Operator
    {
        #region Serialize Fields

        [SerializeField] private CharacterAnimateOperator[] bottles;

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

            for (int i = 0; i < bottles.Length; i++)
            {
                bottles[i].gameObject.SetActive(i == index);
                PlayerManager.Instance.currentPlayer.currentAnimator = bottles[index];
            }
        }

        #endregion
    }
}