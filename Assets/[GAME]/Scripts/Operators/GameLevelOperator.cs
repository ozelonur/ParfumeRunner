
using _GAME_.Scripts.Managers;
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
        
        [SerializeField] private StickmanOperator finishStickman;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            Announce(EventManager<object[]>.GetPath, pathCreator, endOfPathInstruction);
            Announce(EventManager<object[]>.GetFollowTransform, followTransform);
            
            StickmanManager.Instance.finishStickman = finishStickman;
        }

        #endregion
    }
}