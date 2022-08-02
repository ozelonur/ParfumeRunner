using TMPro;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class GameUIOperator : Operator
    {
        #region SerializeFields

        [SerializeField] private TMP_Text levelText;

        #endregion

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.GetLevelNumber += GetLevelNumber;
        }

        private void OnDisable()
        {
            EventManager<object[]>.GetLevelNumber -= GetLevelNumber;
        }

        #endregion

        #region Event Methods

        private void GetLevelNumber(object[] obj)
        {
            levelText.text = "Level " + obj[0];
        }

        #endregion
    }
}