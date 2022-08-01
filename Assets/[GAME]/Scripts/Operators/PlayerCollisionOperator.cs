using _GAME_.Scripts.Interfaces;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class PlayerCollisionOperator : Operator
    {
        #region MonoBehaviour Methods

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<IGate>()?.GateHit();
        }

        #endregion
    }
}