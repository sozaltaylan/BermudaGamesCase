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
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private GameObject nextLevelButton;

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
            CoreGameSignals.upgradeTotalMoneyUI += UpgradeTotalMoneyUI;
            CoreGameSignals.onSetNextLevelButtonUI += SetNextLevelButton;
            CoreGameSignals.onSetLevelText += ChangeLevelTxt;

        }
        private void EventUnsubscription()
        {
            CoreGameSignals.upgradeTotalMoneyUI -= UpgradeTotalMoneyUI;
            CoreGameSignals.onSetNextLevelButtonUI -= SetNextLevelButton;
            CoreGameSignals.onSetLevelText += ChangeLevelTxt;
        }

        #endregion
        #region Methods

        private void UpgradeTotalMoneyUI()
        {
            var totalMoney = GameManager.Instance.GetTotalMoney();
            totalMoneyText.text = totalMoney.ToString();

            totalMoneyText.transform.DOKill(true);
            totalMoneyText.transform.DOPunchScale(Vector3.one * .3f, .15f);


        }

        public void ChangeLevelTxt(int level)
        {
            levelText.text = "LEVEL " + level;
        }

        public void SetNextLevelButton(bool active)
        {
            nextLevelButton.SetActive(active);
        }
        #endregion

    }
}