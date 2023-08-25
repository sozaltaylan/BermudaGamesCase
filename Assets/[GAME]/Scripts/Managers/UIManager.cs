using UnityEngine;
using BermudaGamesCase.Exceptions;
using UnityEngine.UI;
using TMPro;

namespace BermudaGamesCase.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI totalMoneyText;

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