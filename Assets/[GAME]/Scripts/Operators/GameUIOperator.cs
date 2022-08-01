using TMPro;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class GameUIOperator : Operator
    {
        #region SerializeFields

        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text priceText;

        #endregion

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.GetLevelNumber += GetLevelNumber;
            EventManager<object[]>.UpdatePriceUI += UpdatePriceUI;
        }

        private void OnDisable()
        {
            EventManager<object[]>.GetLevelNumber -= GetLevelNumber;
            EventManager<object[]>.UpdatePriceUI -= UpdatePriceUI;
        }

        #endregion

        #region Event Methods

        private void GetLevelNumber(object[] obj)
        {
            levelText.text = "Level " + obj[0];
        }
        
        private void UpdatePriceUI(object[] obj)
        {
            priceText.text = "$" + obj[0];
        }

        #endregion
    }
}