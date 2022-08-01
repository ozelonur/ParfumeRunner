using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class FinishOperator : Operator, IFinish
    {
        #region Serialize Fields

        [SerializeField] private Transform finishTransform;

        #endregion

        #region Private Variables

        private PlayerOperator _playerOperator;
        private Transform _playerTransform;
        private Camera _camera;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            DOVirtual.DelayedCall(.01f, () =>
            {
                _playerOperator = PlayerManager.Instance.currentPlayer;
                _playerTransform = _playerOperator.transform;
            });
        }

        #endregion

        #region Interface Methods

        public void FinishHit(params object[] args)
        {
            Announce(EventManager<object[]>.CanFollowPath, false);
            Announce(EventManager<object[]>.CanMoveHorizontal, false);

            _playerTransform.parent = finishTransform;

            _playerTransform.DOLookAt(finishTransform.position, .3f)
                .SetEase(Ease.Linear)
                .SetLink(_playerTransform.gameObject);

            _playerTransform.DOLocalJump(Vector3.zero, 2, 1, .3f)
                .OnComplete(LookAtCameraAndDance)
                .SetEase(Ease.Linear)
                .SetLink(_playerTransform.gameObject);
        }

        #endregion

        #region Private Variables

        private void LookAtCameraAndDance()
        {
            _playerOperator.currentAnimator.PlayAnimation(AnimationType.Idle);

            Announce(EventManager<object[]>.DetachCamera);

            Vector3 lookAt = _camera.transform.position;
            lookAt.y = _playerTransform.position.y;

            _playerTransform.DOLookAt(lookAt, .3f)
                .OnComplete(() => { Announce(EventManager<object[]>.OnGameComplete, true); })
                .SetEase(Ease.Linear)
                .SetLink(_playerTransform.gameObject);
        }

        #endregion
    }
}