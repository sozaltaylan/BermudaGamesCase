using UnityEngine;
using BermudaGamesCase.Exceptions;

namespace BermudaGamesCase.Managers
{
    public class InputManager : MonoSingleton<InputManager>
    {
        #region Variables

        private bool isInput;

        private Vector3 _mousefirstPosition;
        private Vector3 _mouseHoldPosition;
        private Vector3 _remoteControl;

        [SerializeField] private float xMinumumClamp;
        [SerializeField] private float xMaximumClamp;

        [SerializeField] private float InputSpeed;
        private float _xValue;


        #endregion

        #region Methods


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetFirstTouch();
            }
            else if (Input.GetMouseButton(0))
            {
                SetHoldClick();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                UpPosition();
            }

        }

        private void SetFirstTouch()
        {
            if (!isInput)
            {
                CoreGameSignals.OnGameStarted?.Invoke(true);
                isInput = true;
            }

            _mousefirstPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        private void SetHoldClick()
        {
            _mouseHoldPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            var dist = (_mouseHoldPosition - _mousefirstPosition) * InputSpeed;
            var value = _xValue - dist.x;
            _remoteControl.x = Mathf.Clamp(value, xMinumumClamp, xMaximumClamp);
        }
        private void UpPosition()
        {
            _xValue = _remoteControl.x;
        }
        #endregion
    }
}