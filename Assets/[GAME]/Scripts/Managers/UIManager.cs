using UnityEngine;
using BermudaGamesCase.Exceptions;
using UnityEngine.UI;
using TMPro;
using BermudaGamesCase.Signals;
using DG.Tweening;
using System.Collections;
using System.ComponentModel.Design;

namespace BermudaGamesCase.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI totalMoneyText;

        private Transform firstUITransform;

        #endregion

        #region Events

        private void Start()
        {
            firstUITransform = totalMoneyText.transform;
        }
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

            totalMoneyText.transform.DOKill(true);
            totalMoneyText.transform.DOPunchScale(Vector3.one * .3f,.15f);

        }

        #endregion

    }
}