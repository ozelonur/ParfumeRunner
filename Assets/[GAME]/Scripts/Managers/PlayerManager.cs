using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Public Variables

        public static PlayerManager Instance;

        public PlayerOperator currentPlayer;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        #endregion

        #region Public Methods

        public void SetPlayer(PlayerOperator player)
        {
            currentPlayer = player;
        }

        #endregion
    }
}