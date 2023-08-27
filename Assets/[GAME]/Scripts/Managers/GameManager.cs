using UnityEngine;
using BermudaGamesCase.Exceptions;
using BermudaGamesCase.Signals;

namespace BermudaGamesCase.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        #region Variables

        [SerializeField] private float totalMoney;
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

      

        #endregion
    }
}
