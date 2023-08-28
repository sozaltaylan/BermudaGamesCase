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

        [SerializeField] private CinemachineVirtualCamera playerCamera;

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

        private void ChangeCameraTargetPosition( )
        {

            playerCamera.Follow = null;
            playerCamera.LookAt = null;
        }
        
        #endregion
    }
}