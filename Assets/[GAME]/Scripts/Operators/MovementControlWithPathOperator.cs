using _GAME_.Scripts.Models;

namespace _GAME_.Scripts.Operators
{
    public class MovementControlWithPathOperator : Operator
    {
        #region Public Variables

        public MovementProperties movementProperties;

        #endregion
        
        #region MonoBehaviour Methods

        private void Start()
        {
            Announce(EventManager<object[]>.GetMovementControlWithPath, this);
        }

        #endregion
    }
}