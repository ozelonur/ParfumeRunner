using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Interfaces;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class CharacterAnimateOperator : Operator, IAnimator
    {
        #region Public Variables

        public Transform priceTagTransform;
        public Vector3 priceTagPosition;

        #endregion
        
        #region Private Fields

        private Animator _animator;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion

        #region Interface Methods

        public void PlayAnimation(AnimationType animationType)
        {
            ((IAnimator) this).SetAnimation(_animator, animationType);
        }

        #endregion
    }
}