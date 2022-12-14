using Cinemachine;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class CameraOperator : Operator
    {
        #region SerializeFields

        [SerializeField] private CinemachineVirtualCamera mainVirtualCamera;

        #endregion

        #region Private Variables

        private Transform _followTransform;

        #endregion

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            EventManager<object[]>.GetFollowTransform += GetFollowTransform;
            EventManager<object[]>.DetachCamera += DetachCamera;
        }

      

        private void OnDisable()
        {
            EventManager<object[]>.GetFollowTransform -= GetFollowTransform;
            EventManager<object[]>.DetachCamera -= DetachCamera;
        }
        
        #endregion

        #region Event Methods

        private void GetFollowTransform(object[] obj)
        {
            _followTransform = (Transform) obj[0];

            mainVirtualCamera.Follow = _followTransform;
            mainVirtualCamera.Priority = 11;
        }
        
        private void DetachCamera(object[] obj)
        {
            mainVirtualCamera.Follow = null;
        }

        #endregion
    }
}