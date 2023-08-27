using BermudaGamesCase.Managers;
using BermudaGamesCase.Signals;
using Dreamteck.Splines;
using UnityEngine;
using BermudaGamesCase.Others;
using System.Collections;

namespace BermudaGamesCase.Controllers
{

    public class PlayerController : MonoBehaviour
    {
        #region Variables

        private float movementXPosition;

        #region SerializedFields

        [SerializeField] private SplineFollower splineFollower;
        [SerializeField] private MoneyBarController moneyBarController;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private PlayerAnimationController playerAnimationController;

        [SerializeField] private float rotationAngle;
        [SerializeField] private float maxRotateAngle;
        [SerializeField] private float lerpSpeed;

        #endregion

        #endregion

        #region Methods


        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var xPosition = InputManager.Instance.Horizontal;

            movementXPosition = xPosition;
            movementXPosition = Mathf.Clamp(movementXPosition, playerData.HorizontalClamp.x, playerData.HorizontalClamp.y);

            var offsetPos = splineFollower.offsetModifier.keys[0].offset.x;
            var lerpOffset = Mathf.Lerp(offsetPos, movementXPosition, Time.deltaTime * lerpSpeed);

            splineFollower.offsetModifier.keys[0].offset.x = lerpOffset;
            CoreGameSignals.onChangeCameraTargetPosition?.Invoke(movementXPosition);

            var rotateInput = InputManager.Instance.DistanceHorizontal * rotationAngle;
            var clampedRotate = Mathf.Clamp(rotateInput, -maxRotateAngle, maxRotateAngle);

            Quaternion lerpRot = Quaternion.Slerp(playerModel.transform.localRotation, Quaternion.AngleAxis(clampedRotate, playerModel.transform.up), Time.deltaTime * lerpSpeed);
            playerModel.transform.localRotation = lerpRot;

        }
        public void SetSplineFollower(bool active)
        {
            splineFollower.enabled = active;
        }

        private void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.TryGetComponent(out CollectibleItem item))
            {
                moneyBarController.SetMoney(item.itemMoney);

                CoreGameSignals.onChangeTotalMoney?.Invoke(item.itemMoney);
                CoreGameSignals.UpgradeTotalMoneyUI?.Invoke();

                item.Interaction();

                playerModel.CheckModelChange(GetMoney());
            }

            else if (coll.gameObject.TryGetComponent(out Gate gate))
            {
                moneyBarController.SetMoney(gate.money);
                CoreGameSignals.onChangeTotalMoney?.Invoke(gate.money);
                CoreGameSignals.UpgradeTotalMoneyUI?.Invoke();

                playerModel.CheckModelChange(GetMoney());

                if (gate.money > 0)
                    playerAnimationController.SetJoy(true);
                else
                    playerAnimationController.SetSad(true);
                gate.SetParticle();
            }
            else if (coll.gameObject.TryGetComponent(out Machine machine))
            {
                moneyBarController.SetMoney(machine.money);

                CoreGameSignals.onChangeTotalMoney?.Invoke(machine.money);
                CoreGameSignals.UpgradeTotalMoneyUI?.Invoke();

                machine.Interaction();
                playerModel.CheckModelChange(GetMoney());
                SetSplineFollower(false);
                CoreGameSignals.onInputToggle?.Invoke(false);

                if (machine.money > 0)
                    playerAnimationController.SetJoy(true);
                else
                    playerAnimationController.SetSad(true);
                StartCoroutine(SetAtmWait());
            }
            else if (coll.gameObject.TryGetComponent(out FinishLine finish))
            {
                SetSplineFollower(false);
                // TODO : final paray? sorgula
                playerAnimationController.SetDanceAnimation(true);
            }
        }

        IEnumerator SetAtmWait()
        {
            yield return new WaitForSeconds(.5f);
            CoreGameSignals.onInputToggle?.Invoke(true);
            SetSplineFollower(true);
        }
        private float GetMoney()
        {
            return moneyBarController.CurrentMoney;
        }
        public void StartGame()
        {
            SetSplineFollower(true);
        }

        #endregion
    }
}