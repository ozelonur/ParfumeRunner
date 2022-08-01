using UnityEngine;
using UnityEngine.SceneManagement;
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

        private void OnEnable()
        {
            EventManager<object[]>.OnGameComplete += OnGameComplete;
        }

        private void OnDisable()
        {
            EventManager<object[]>.OnGameComplete -= OnGameComplete;
        }

        #endregion

        #region Event Methods

        private void OnGameComplete(object[] obj)
        {
            bool status = (bool) obj[0];

            ActivatePanel(status ? gameCompletePanel : gameFailPanel);
        }

        #endregion

        #region Private Methods

        private void NextLevel()
        {
            SceneManager.LoadScene("Main");
        }

        private void RetryGame()
        {
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