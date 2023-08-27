using UnityEngine;
using BermudaGamesCase.Exceptions;
using Dreamteck.Splines;
using BermudaGamesCase.Controllers;
using BermudaGamesCase.Signals;

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
            CoreGameSignals.onGameStart += StartGame;
        }
        private void EventUnsubscription()
        {
            CoreGameSignals.onGameStart -= StartGame;
        }
        #endregion

        #region Methods

        private void StartGame()
        {
            playerController.StartGame();
        }
       
        #endregion
    }
}