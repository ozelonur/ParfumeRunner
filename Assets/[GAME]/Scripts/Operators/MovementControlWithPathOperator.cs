using System;
using _GAME_.Scripts.Models;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class MovementControlWithPathOperator : Operator
    {
        #region Public Variables

        public MovementProperties movementProperties;

        #endregion

        #region SerializeFields

        [Header("Movement Settings")] [SerializeField]
        private float horizontalClampRage;

        [Header("Rotation Settings")] [SerializeField]
        private bool canRotate;

        [SerializeField] private float rotationPower = 1f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float rotationClampRange = 1f;

        [Header("Pivot References")] [SerializeField]
        private Transform rotationPivot;

        [SerializeField] private Transform positionPivot;

        #endregion

        #region Private Variables

        private float _firstClick;
        private float _delta;
        private float _newRotY;

        private Quaternion _currentRotation;

        private Vector3 _newPosition;
        private Vector3 _newDirection;

        private bool _canMove;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            Announce(EventManager<object[]>.GetMovementControlWithPath, this);
        }

        private void OnEnable()
        {
            EventManager<object[]>.CanMoveHorizontal += CanMoveHorizontal;
        }

        private void OnDisable()
        {
            EventManager<object[]>.CanMoveHorizontal -= CanMoveHorizontal;
        }


        private void Update()
        {
            if (!_canMove)
            {
                return;
            }

            movementProperties.ForwardValue = 0;

            #region Slider

            movementProperties.ForwardValue = movementProperties.VerticalSpeed * Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                movementProperties.DeltaHorizontalValue = 0;
                _firstClick = Input.mousePosition.x;
            }

            if (Input.GetMouseButton(0))
            {
                _delta = Input.mousePosition.x - _firstClick;

                movementProperties.DeltaHorizontalValue =
                    (_delta * movementProperties.HorizontalSpeed) * Time.fixedDeltaTime;

                _firstClick = Input.mousePosition.x;
            }

            if (Input.GetMouseButtonUp(0))
            {
                movementProperties.DeltaHorizontalValue = 0;
            }

            #endregion

            #region Rotation

            _newDirection = Vector3.zero;

            if (canRotate)
            {
                _currentRotation.y = _newRotY;
                _newRotY = Math.Clamp(_currentRotation.y + (movementProperties.DeltaHorizontalValue * rotationPower),
                    -rotationClampRange, rotationClampRange);
                _currentRotation.y = _newRotY;

                GetModelRotationPivot().localRotation = Quaternion.Lerp(GetModelRotationPivot().localRotation,
                    _currentRotation, Time.deltaTime * rotationSpeed);
            }

            #endregion

            #region Movement

            _newDirection = Vector3.zero;
            if (_canMove)
            {
                _newDirection.x = movementProperties.DeltaHorizontalValue;
            }

            _newDirection.y = 0;

            _newPosition = GetModelPositionPivot().localPosition + _newDirection;
            GetModelPositionPivot().localPosition = Vector3.Lerp(
                new Vector3(Mathf.Clamp(_newPosition.x, -horizontalClampRage, horizontalClampRage),
                    _newPosition.y, 0f), GetModelPositionPivot().localPosition, 30 * Time.fixedDeltaTime);

            #endregion
        }

        #endregion

        #region Event Methods

        private void CanMoveHorizontal(object[] obj)
        {
            _canMove = true;
        }

        #endregion

        #region Private Methods

        private Transform GetModelPositionPivot()
        {
            return positionPivot;
        }

        private Transform GetModelRotationPivot()
        {
            return rotationPivot;
        }

        #endregion
    }
}