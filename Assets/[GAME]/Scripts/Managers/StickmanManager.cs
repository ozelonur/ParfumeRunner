using _GAME_.Scripts.Operators;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class StickmanManager : MonoBehaviour
    {
        public static StickmanManager Instance;
        public StickmanOperator stickmanPrefab;
        public StickmanOperator finishStickman;

        public Material[] stickmanMaterials;

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        #endregion
    }
}