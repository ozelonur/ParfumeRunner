using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Managers;
using _GAME_.Scripts.Operators;

namespace _GAME_.Scripts
{
    public class PlayerOperator : Operator
    {
        #region Public Variables

        public CharacterAnimateOperator currentAnimator;

        #endregion

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.OnGameStart += OnGameStart;
        }

        private void OnDisable()
        {
            EventManager<object[]>.OnGameStart -= OnGameStart;
        }

        private void Start()
        {
            PlayerManager.Instance.SetPlayer(this);
        }

        #endregion

        #region Event Methods

        private void OnGameStart(object[] obj)
        {
            Announce(EventManager<object[]>.CanFollowPath, true);
            Announce(EventManager<object[]>.CanMoveHorizontal, true);
            
            currentAnimator.PlayAnimation(AnimationType.Walk);
        }

        #endregion
    }
}