using PathCreation;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class PathFollowerOperator : Operator
    {
        #region Private Variables

        private PathCreator _pathCreator;
        private EndOfPathInstruction _endOfPathInstruction;

        private MovementControlWithPathOperator _movementControlWithPathOperator;
        
        private bool _canFollowPath;
        private float _distanceTravelled;

        #endregion

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.GetPath += GetPath;
            EventManager<object[]>.GetMovementControlWithPath += GetMovementControlWithPath;
        }

        private void GetMovementControlWithPath(object[] obj)
        {
            _movementControlWithPathOperator = (MovementControlWithPathOperator)obj[0];
        }

        private void OnDisable()
        {
            EventManager<object[]>.GetPath -= GetPath;
        }

        private void Update()
        {
            if (_pathCreator == null)
            {
                return;
            }

            if (!_canFollowPath)
            {
                return;
            }
            
            _distanceTravelled += _movementControlWithPathOperator.movementProperties.VerticalSpeed * Time.deltaTime;
            transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
            transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
        }

        #endregion

        #region Event Methods

        private void GetPath(object[] args)
        {
            _pathCreator = (PathCreator) args[0];
            _endOfPathInstruction = (EndOfPathInstruction) args[1];

            if (_pathCreator != null)
            {
                _pathCreator.pathUpdated += OnPathChanged;
            }
        }

        #endregion

        #region Private Methods

        private void OnPathChanged()
        {
            _distanceTravelled = 0;
            transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
        }

        #endregion
    }
}