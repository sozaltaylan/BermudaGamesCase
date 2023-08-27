using UnityEngine;
using BermudaGamesCase.Exceptions;
using UnityEngine.UI;
using TMPro;
using BermudaGamesCase.Signals;
using DG.Tweening;

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
            CoreGameSignals.UpgradeTotalMoneyUI += UpgradeTotalMoneyUI;
        }
        private void EventUnsubscription()
        {
            CoreGameSignals.UpgradeTotalMoneyUI -= UpgradeTotalMoneyUI;
        }

        #endregion
        #region Methods

        private void UpgradeTotalMoneyUI()
        {
            var totalMoney = GameManager.Instance.GetTotalMoney();
            totalMoneyText.text = totalMoney.ToString();
            totalMoneyText.transform.DOScale(1, 1);
        }

        #endregion

    }
}