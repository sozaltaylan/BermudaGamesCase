using UnityEngine;
using BermudaGamesCase.Exceptions;

namespace BermudaGamesCase.Managers
{
    public class InputManager : MonoSingleton<InputManager>
    {
        #region Variables

        [SerializeField] private float multiplier = 17f;
        [SerializeField] private float sensibility = 17f;

        private Vector3 _currentPos;
        private Vector3 _lastPos;

        #endregion
        #region Property
        public float Horizontal { get; private set; }
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
                SetHoldClick();

            }
            if (Input.GetMouseButtonUp(0))
            {
                UpPosition();
            }

        }

        private void SetFirstTouch()
        {
            _currentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        private void SetHoldClick()
        {
            _lastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            var dist = (_lastPos.x - _currentPos.x) * multiplier;
            Horizontal = dist;
        }
        private void UpPosition()
        {
            Horizontal = 0;
        }


        #endregion
    }
}