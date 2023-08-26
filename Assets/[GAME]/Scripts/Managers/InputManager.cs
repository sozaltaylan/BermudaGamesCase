using UnityEngine;
using BermudaGamesCase.Exceptions;

namespace BermudaGamesCase.Managers
{
    public class InputManager : MonoSingleton<InputManager>
    {
        #region Variables

        [SerializeField] private Vector3 _mousefirstPosition;
        [SerializeField] private Vector3 _mouseHoldPosition;
     

        [SerializeField] private float InputSpeed;

        private float inputTimer;
        [SerializeField] private float inputMultiplier;
        private float _horizontal;

        #region Properties
        public float Horizantal
        {
            get { return _horizontal; }
        }

        #endregion
        #endregion

        #region Methods

        private void Start()
        {
            //_camera = Camera.main;
        }

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
            var mousePos = Input.mousePosition;
            _mousefirstPosition = Camera.main.ScreenToViewportPoint(mousePos);
        }

        private void SetHoldClick()
        {
            inputTimer += Time.deltaTime;
            if (inputTimer > inputMultiplier)
            {
                SetFirstTouch();
                inputTimer = 0;
            }

            var mousePos = Input.mousePosition;
            _mouseHoldPosition = Camera.main.ScreenToViewportPoint(mousePos);
            var dist = (_mouseHoldPosition - _mousefirstPosition) * InputSpeed;
            _horizontal = dist.x;

        }
        private void UpPosition()
        {

        }
        #endregion
    }
}