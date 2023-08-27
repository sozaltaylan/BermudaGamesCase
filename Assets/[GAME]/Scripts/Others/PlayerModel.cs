using BermudaGamesCase.Enums;
using BermudaGamesCase.Signals;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.TextCore.Text;
using BermudaGamesCase.Controllers;

namespace BermudaGamesCase.Others
{
    public class PlayerModel : MonoBehaviour
    {
        #region Variables

        public List<ModelState> listModelStates;

        private ModelState _selectedModel;

        [SerializeField] private PlayerAnimationController playerAnimationController;
        [SerializeField] private MoneyBarController moneyBarController;


        private bool isMove;
        #endregion

        #region Methods

        private void Start()
        {
            _selectedModel = listModelStates[0];
        }

        private void SwitchModel(PlayerType playerType, int playerIndex, Color color)
        {
            if (_selectedModel.playerType != playerType)
            {
                if (_selectedModel.index < playerIndex)
                {
                    DOTurn();
                    moneyBarController.CreateStatuTextAnimation();
                }
                else
                {
                    playerAnimationController.SetSad(true);
                    moneyBarController.CreateStatuTextAnimation();
                }
            }

        }

        private void DOTurn()
        {

            Sequence s = DOTween.Sequence();
            s.Append(transform.DOLocalRotate(Vector3.up * 360, .5f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine));
            s.Join(transform.DOLocalJump(Vector3.zero, .2f, 1, .35f).SetEase(Ease.Linear));

        }

        public void CheckModelChange(float currentMoney)
        {
            for (int i = 0; i < listModelStates.Count; i++)
            {
                if (i != (listModelStates.Count - 1))
                {
                    if (currentMoney >= listModelStates[i].upgradeMoney && currentMoney < listModelStates[i + 1].upgradeMoney)
                    {
                        SwitchModel(listModelStates[i].playerType, listModelStates[i].index, listModelStates[i].color);
                        _selectedModel = listModelStates[i];
                        listModelStates[i].model.SetActive(true);
                        playerAnimationController.SetAnimation(listModelStates[i].animatorParamater.ToString(), true);

                    }
                    else
                    {
                        listModelStates[i].model.SetActive(false);
                        playerAnimationController.SetAnimation(listModelStates[i].animatorParamater.ToString(), false);
                    }
                }
                else
                {
                    if (currentMoney >= listModelStates[i].upgradeMoney)
                    {
                        SwitchModel(listModelStates[i].playerType, listModelStates[i].index, listModelStates[i].color);
                        _selectedModel = listModelStates[i];
                        listModelStates[i].model.SetActive(true);
                        playerAnimationController.SetAnimation(listModelStates[i].animatorParamater.ToString(), true);

                    }
                    else
                    {
                        listModelStates[i].model.SetActive(false);
                        playerAnimationController.SetAnimation(listModelStates[i].animatorParamater.ToString(), false);
                    }
                }


            }
        }

        public PlayerType GetModel()
        {
            for (int i = 0; i < listModelStates.Count; i++)
            {
                if (listModelStates[i].model.activeInHierarchy)
                {
                    return listModelStates[i].playerType;
                }
            }
            return default;
        }

        public bool IsPoor()
        {
            bool isPoor = _selectedModel.playerType == PlayerType.POOR ? true : false;
            return isPoor;
        }
        #endregion

    }

    [Serializable]
    public struct ModelState
    {
        public PlayerType playerType;
        public GameObject model;
        public float upgradeMoney;
        public AnimatorParameters animatorParamater;
        public int index;
        public Color color;
    }

}
