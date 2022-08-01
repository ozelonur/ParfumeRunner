using _GAME_.Scripts.Enums;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class PlayerPriceOperator : Operator
    {
        #region Private Variables

        private int _price;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            Announce(EventManager<object[]>.ChangePlayer, _price);
            Announce(EventManager<object[]>.UpdatePriceUI, _price);
        }

        private void OnEnable()
        {
            EventManager<object[]>.GateInteracted += GateInteracted;
        }

        private void OnDisable()
        {
            EventManager<object[]>.GateInteracted -= GateInteracted;
        }

        #endregion

        #region Event Methods

        private void GateInteracted(object[] obj)
        {
            GateType gateType = (GateType) obj[0];
            int worth = (int) obj[1];

            ProcessPrice(gateType, worth);
        }

        #endregion

        #region Private Methods

        private void ProcessPrice(GateType gateType, int worth)
        {
            switch (gateType)
            {
                case GateType.Sum:
                    _price += worth;
                    break;
                case GateType.Subtract:
                    _price -= worth;
                    break;
                case GateType.Multiply:
                    _price *= worth;
                    break;
                case GateType.Divide:
                    _price /= worth;
                    break;
                default:
                    Debug.Log("Invalid gate type");
                    break;
            }

            if (_price < 0)
            {
                _price = 0;
            }

            Announce(EventManager<object[]>.UpdatePriceUI, _price);

            HandlePlayerChange();
        }

        private void HandlePlayerChange()
        {
            int index = _price switch
            {
                < 100 => 0,
                >= 100 and < 200 => 1,
                >= 200 and < 300 => 2,
                >= 300 and < 400 => 3,
                >= 400 and < 500 => 4,
                >= 500 and < 600 => 5,
                >= 600 and < 700 => 6,
                _ => 6
            };

            Announce(EventManager<object[]>.ChangePlayer, index);
        }

        #endregion
    }
}