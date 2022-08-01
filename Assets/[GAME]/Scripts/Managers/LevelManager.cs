using _GAME_.Scripts.GlobalVariables;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class LevelManager : Operator
    {
        #region Private Variables

        private Level _level;

        #endregion

        #region Public Variables

        private int LevelIndex
        {
            get => PlayerPrefs.GetInt(GlobalStrings.LevelIndex, 1);
            set => PlayerPrefs.SetInt(GlobalStrings.LevelIndex, value);
        }

        #endregion

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.OnGameComplete += LevelComplete;
        }

        private void Start()
        {
            _level = Resources.Load<Level>("Levels/Level" + LevelIndex);

            if (_level != null)
            {
                Instantiate(_level.LevelPrefab);
            }

            else
            {
                LevelIndex = 1;
                _level = Resources.Load<Level>("Levels/Level" + LevelIndex);
                Instantiate(_level.LevelPrefab);
            }

            Announce(EventManager<object[]>.GetLevelNumber, LevelIndex);
        }

        private void OnDisable()
        {
            EventManager<object[]>.OnGameComplete += LevelComplete;
        }

        #endregion

        #region Private Methods

        private void LevelComplete(object[] args)
        {
            bool status = (bool) args[0];

            if (status)
            {
                LevelIndex++;
            }
        }

        #endregion
    }
}