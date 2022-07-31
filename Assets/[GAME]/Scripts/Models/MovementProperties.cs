#region Header
// Developed by Onur ÖZEL
// onur.ozel@triflesgames.com
#endregion

using System;
using UnityEngine;

namespace _GAME_.Scripts.Models
{
    [Serializable]
    public class MovementProperties
    {
        [SerializeField] private float verticalSpeed = 5f;
        [SerializeField] private float horizontalSpeed = 1f;
        private float _deltaHorizontalValue;
        private float _forwardValue;

        public float VerticalSpeed { get => verticalSpeed; set => verticalSpeed = value; }
        public float HorizontalSpeed { get => horizontalSpeed; set => horizontalSpeed = value; }
        

        public float DeltaHorizontalValue { get => _deltaHorizontalValue; set => _deltaHorizontalValue = value; }
        public float ForwardValue { get => _forwardValue; set => _forwardValue = value; }
    }
}