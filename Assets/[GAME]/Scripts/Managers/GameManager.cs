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
            CoreGameSignals.onChangeTotalMoney += SetTotalMoney;
        }
        private void EventUnsubscription()
        {
            CoreGameSignals.onChangeTotalMoney -= SetTotalMoney;

        }

        #endregion

        #region Methods

        private void SetTotalMoney(float amount)
        {
            totalMoney += amount;
        }
        public float GetTotalMoney()
        {
            return totalMoney;
        }


        #endregion
    }
}
