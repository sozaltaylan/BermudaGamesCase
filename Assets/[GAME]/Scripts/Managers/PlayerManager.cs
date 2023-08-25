using UnityEngine;
using BermudaGamesCase.Exceptions;
using Dreamteck.Splines;
using BermudaGamesCase.Controllers;

namespace BermudaGamesCase.Managers
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        #region Variables

        [SerializeField] private PlayerController playerController;

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
        }
        private void EventUnsubscription()
        {
        }
        #endregion

        #region Methods

        private void SetSplineFollower(bool active)
        {
            playerController.SetSplineFollower(active);
        }
        #endregion
    }
}