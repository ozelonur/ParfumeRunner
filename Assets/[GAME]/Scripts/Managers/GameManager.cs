#region Header

// Developed by Onur ÖZEL
// onur.ozel@triflesgames.com

#endregion

using UnityEngine;
using UnityEngine.UI;

namespace _GAME_.Scripts.Managers
{
    public class GameManager : Operator
    {
        #region Serialize Fields

        #region Panels

        [Header("Panels")] [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject gameFailPanel;
        [SerializeField] private GameObject gameCompletePanel;

        #endregion

        #region Buttons

        [Header("Buttons")] [SerializeField] private Button startButton;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button nextButton;

        #endregion

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            ActivatePanel(mainMenuPanel);
            
            startButton.onClick.AddListener(StartGame);
            retryButton.onClick.AddListener(RetryGame);
            nextButton.onClick.AddListener(NextLevel);
        }

        #endregion

        #region Private Methods

        private void NextLevel()
        {
            ActivatePanel(gameCompletePanel);
        }

        private void RetryGame()
        {
            ActivatePanel(gameFailPanel);
        }

        private void StartGame()
        {
            Announce(EventManager<object[]>.OnGameStart);
            ActivatePanel(gamePanel);
        }
        
        private void ActivatePanel(GameObject panel)
        {
            mainMenuPanel.SetActive(false);
            gamePanel.SetActive(false);
            gameFailPanel.SetActive(false);
            gameCompletePanel.SetActive(false);
            
            panel.SetActive(true);
        }

        #endregion
    }
}