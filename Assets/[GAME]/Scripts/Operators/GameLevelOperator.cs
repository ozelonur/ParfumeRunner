
using PathCreation;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class GameLevelOperator : Operator
    {
        #region SerializeFields

        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private EndOfPathInstruction endOfPathInstruction;
        
        [SerializeField] private Transform followTransform;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            Announce(EventManager<object[]>.GetPath, pathCreator, endOfPathInstruction);
            Announce(EventManager<object[]>.GetFollowTransform, followTransform);
        }

        #endregion
    }
}