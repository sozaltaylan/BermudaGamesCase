using UnityEngine;
using BermudaGamesCase.Exceptions;

namespace BermudaGamesCase.Managers
{
    public class InputManager : MonoSingleton<InputManager>
    {
        #region Variables

        private bool isInput;

        #endregion

        #region Methods


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetFirstTouch();
            }
            if (Input.GetMouseButton(0))
            {

            }

        }

        private void SetFirstTouch()
        {
            if (!isInput)
            {
                CoreGameSignals.OnGameStarted?.Invoke(true);
                isInput = true;
            }
        }
        #endregion
    }
}