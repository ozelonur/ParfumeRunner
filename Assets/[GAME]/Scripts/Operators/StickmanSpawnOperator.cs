using _GAME_.Scripts.Managers;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GAME_.Scripts.Operators
{
    public class StickmanSpawnOperator : Operator
    {
        #region Private Variables

        private StickmanOperator _stickmanPrefab;
        private int _stickmanCount;

        #endregion

        #region Serialize Fields

        [SerializeField] private Transform stickmanTransform;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            _stickmanPrefab = StickmanManager.Instance.stickmanPrefab;
        }

        #endregion

        #region Event Methods

        private void OnEnable()
        {
            EventManager<object[]>.SpawnStickman += SpawnStickman;
            EventManager<object[]>.UpdatePriceUI += UpdatePriceUI;
        }

        private void OnDisable()
        {
            EventManager<object[]>.SpawnStickman -= SpawnStickman;
            EventManager<object[]>.UpdatePriceUI -= UpdatePriceUI;
        }

        private void UpdatePriceUI(object[] obj)
        {
            _stickmanCount = (int) obj[0];

            _stickmanCount /= 50;
        }

        private void SpawnStickman(object[] obj)
        {
            for (int i = 0; i < _stickmanCount; i++)
            {
                StickmanOperator stickman = Instantiate(_stickmanPrefab);

                Vector3 spawnPosition = Random.insideUnitSphere * 40;

                stickman.transform.position = stickmanTransform.position +
                                              new Vector3(spawnPosition.x, 0, Mathf.Abs(spawnPosition.z));

                stickman.StartMoving(stickmanTransform);
            }

            DOVirtual.DelayedCall(7f, () => { Announce(EventManager<object[]>.OnGameComplete, true); });
        }

        #endregion
    }
}