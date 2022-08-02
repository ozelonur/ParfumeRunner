using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class FinishOperator : Operator, IFinish
    {
        #region Serialize Fields

        [SerializeField] private Transform jumpTransform;

        #endregion

        #region Private Variables

        private PlayerOperator _playerOperator;
        private Transform _playerTransform;

        #endregion

        #region MonoBehaviour Methods

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

            _playerTransform.parent = jumpTransform;

            _playerOperator.currentAnimator.animator.enabled = false;

            _playerTransform.DOLocalRotate(Vector3.zero, .6f)
                .SetEase(Ease.Linear)
                .SetLink(_playerTransform.gameObject);

            _playerTransform.DOLocalJump(Vector3.zero, 3, 1, .6f)
                .OnComplete(AnimateBottle)
                .SetEase(Ease.Linear)
                .SetLink(_playerTransform.gameObject);
        }

        private void AnimateBottle()
        {
            _playerTransform.DOLocalMove(Vector3.down / 4, .5f)
                .OnComplete(() =>
                {
                    Announce(EventManager<object[]>.SpawnStickman);
                    _playerTransform.DOScale(Vector3.zero, .3f)
                        .SetEase(Ease.OutBack).SetLink(_playerTransform.gameObject);
                })
                .SetEase(Ease.Linear)
                .SetLoops(4, LoopType.Yoyo)
                .SetLink(_playerTransform.gameObject);
        }

        #endregion
    }
}