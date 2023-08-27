using BermudaGamesCase.Enums;
using BermudaGamesCase.Signals;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.TextCore.Text;

namespace BermudaGamesCase.Others
{
    public class PlayerModel : MonoBehaviour
    {
        #region Variables

        public List<ModelAnimation> listModelAnimation;

        private ModelAnimation _selectedModel;



        private bool isMove;
        #endregion

        #region Methods

        private void Start()
        {
            _selectedModel = listModelAnimation[0];
        }

        public void SetAnimation()
        {
            _selectedModel.SetAnimation(1);
        }

        private void SwitchModel(int modelIndex)
        {
            foreach (var model in listModelAnimation)
            {
                model.gameObject.SetActive(false);
            }

            listModelAnimation[modelIndex].gameObject.SetActive(true);
        }

        public void CheckModelChange(float currentMoney)
        {
            int modelIndex;

            if (currentMoney <= 33)
            {
                modelIndex = 0;
            }
            else if (currentMoney <= 66)
            {
                modelIndex = 1;
            }
            else
            {
                modelIndex = 2;
            }

            _selectedModel = listModelAnimation[modelIndex];
            SwitchModel(modelIndex);
        }

        #endregion

    }


}