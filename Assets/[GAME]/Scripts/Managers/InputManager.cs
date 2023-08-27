using UnityEngine;
using BermudaGamesCase.Exceptions;
using BermudaGamesCase.Signals;

namespace BermudaGamesCase.Managers
{
    public class InputManager : MonoSingleton<InputManager>
    {
        #region Variables

        [SerializeField] private float multiplier = 17f;
        [SerializeField] private float sensibility = 17f;
        [SerializeField] private float clampValue = 2.1f;
        private float _lastDistance;

        private Vector3 _currentPos;
        private Vector3 _lastPos;

        private Vector3 _lastTouchPosition;

        private bool isActive = false;
        #endregion
        #region Property
        public float Horizontal { get; private set; }
        public float DistanceHorizontal { get; private set; }
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
            CoreGameSignals.onInputToggle += SetInputActive;
        }
        private void EventUnsubscription()
        {
            CoreGameSignals.onInputToggle -= SetInputActive;
        }
        #endregion


        #region Methods
        private void Update()
        {
            if (!isActive) return;

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
            var dist = (_currentPos.x - _lastPos.x) * multiplier;

            var newDist = (_lastDistance - dist);

           
            Horizontal = newDist;
            ClampControl();
        }
        private void UpPosition()
        {
          _lastDistance = Horizontal;
            DistanceHorizontal = 0;
        }

        private void SetInputActive(bool active) 
        {
            isActive = active;
        }

        float timer;
        float lastDist;
        private void ClampControl()
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                if (Mathf.Abs(_lastTouchPosition.x - _lastPos.x) < lastDist)
                {
                    if (Horizontal < -clampValue)
                        _lastDistance = -clampValue;

                    else if (Horizontal > clampValue)
                        _lastDistance = clampValue;
                    else
                        _lastDistance = Horizontal;

                    _currentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                }

                DistanceHorizontal = _lastPos.x - _lastTouchPosition.x;


                lastDist = Mathf.Abs(_lastTouchPosition.x - _lastPos.x);
                _lastTouchPosition = _lastPos;
                timer = .15f;
            }
        }
        
        #endregion
    }
}