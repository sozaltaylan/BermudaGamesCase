using UnityEngine;
using BermudaGamesCase.Exceptions;
using Dreamteck.Splines;
using BermudaGamesCase.Controllers;
using BermudaGamesCase.Signals;
using Cinemachine;

namespace BermudaGamesCase.Managers
{
    public class CameraManager : MonoSingleton<CameraManager>
    {
        #region Variables

        [SerializeField] private SplineFollower cameraSplineTarget;
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        [SerializeField] private float splineSpeed;

        [Header("Follow Ref ")]
        [SerializeField] private Vector2 clampPosition;

        #endregion

        #region Events

        private void OnEnable()
        {
            EventSubscription();
        }
        private void OnDisable()
        {
            EventUnsubscription();
        }

        private void EventSubscription()
        {
            CoreGameSignals.onChangeCameraTargetPosition += ChangeCameraTargetPosition;
        }
        private void EventUnsubscription()
        {
            CoreGameSignals.onChangeCameraTargetPosition -= ChangeCameraTargetPosition;
        }
        #endregion

        #region Methods

        private void ChangeCameraTargetPosition(float xPosition)
        {
            xPosition = Mathf.Clamp(xPosition, clampPosition.x, clampPosition.y);
            cameraSplineTarget.offsetModifier.keys[0].offset.x = xPosition;
        }
        public void StopFollow()
        {
            playerCamera.Follow = null;
            playerCamera.LookAt = null;
        }
        #endregion
    }
}