using _GAME_.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class PriceCanvasOperator : Operator
    {
        #region Serialized Fields

        [SerializeField] private TMP_Text priceText;
        [SerializeField] private Transform tagTransform;

        #endregion

        #region Private Variables

        private PlayerManager _playerManager;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            priceText.text = "$0";
        }

        private void Start()
        {
            _playerManager = PlayerManager.Instance;
        }

        #endregion

        #region Event Methods

        private void OnEnable()
        {
            EventManager<object[]>.UpdatePriceTagPosition += UpdatePriceTagPosition;
            EventManager<object[]>.UpdatePriceUI += UpdatePriceUI;
        }


        private void OnDisable()
        {
            EventManager<object[]>.UpdatePriceTagPosition -= UpdatePriceTagPosition;
            EventManager<object[]>.UpdatePriceUI -= UpdatePriceUI;
        }

        private void UpdatePriceTagPosition(object[] obj)
        {
            CharacterAnimateOperator currentAnimatorOperator = _playerManager.currentPlayer.currentAnimator;

            tagTransform.parent = currentAnimatorOperator.priceTagTransform;
            tagTransform.localPosition = currentAnimatorOperator.priceTagPosition;
            tagTransform.localEulerAngles = Vector3.forward * 90;
        }

        private void UpdatePriceUI(object[] obj)
        {
            priceText.text = "$" + obj[0];
        }

        #endregion
    }
}