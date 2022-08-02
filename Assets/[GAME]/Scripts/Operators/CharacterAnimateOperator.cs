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
        public Animator animator;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        #endregion

        #region Interface Methods

        public void PlayAnimation(AnimationType animationType)
        {
            ((IAnimator) this).SetAnimation(animator, animationType);
        }

        #endregion
    }
}