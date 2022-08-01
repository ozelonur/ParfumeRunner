using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class GateOperator : Operator, IGate
    {
        #region Serialize Fields

        [Title("Gate Configuration")]
        [field: SerializeField]
        public GateType GateType { get; set; }

        [field: SerializeField] public int Worth { get; set; }


        [Title("Gate References")] [SerializeField]
        private TMP_Text worthText;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            InitGate();
        }

        #endregion

        #region Private Methods

        private void InitGate()
        {
            switch (GateType)
            {
                case GateType.Sum:
                    worthText.text = "+" + Worth;
                    break;
                case GateType.Subtract:
                    worthText.text = "-" + Worth;
                    break;
                case GateType.Multiply:
                    worthText.text = "x" + Worth;
                    break;
                case GateType.Divide:
                    worthText.text = "/" + Worth;
                    break;
                default:
                    Debug.Log("Gate type not found");
                    return;
            }
        }

        #endregion

        #region Interface Methods

        public void GateHit(params object[] args)
        {
            Announce(EventManager<object[]>.GateInteracted, GateType, Worth);
        }

        #endregion
    }
}