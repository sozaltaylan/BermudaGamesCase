using BermudaGamesCase.Managers;
using BermudaGamesCase.Signals;
using Dreamteck.Splines;
using UnityEngine;
using BermudaGamesCase.Others;
using System.Collections;
using DG.Tweening;

namespace BermudaGamesCase.Controllers
{

    public class PlayerController : MonoBehaviour
    {
        #region Variables

        private float movementXPosition;

        #region SerializedFields

        [SerializeField] private SplineFollower splineFollower;
        [SerializeField] private PlayerUIController moneyBarController;
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

            var rotateInput = InputManager.Instance.DistanceHorizontal * rotationAngle;
            var clampedRotate = Mathf.Clamp(rotateInput, -maxRotateAngle, maxRotateAngle);

            Quaternion lerpRot = Quaternion.Slerp(playerModel.transform.localRotation, Quaternion.AngleAxis(clampedRotate, playerModel.transform.up), Time.deltaTime * lerpSpeed);
            playerModel.transform.localRotation = lerpRot;

        }
        public void SetSplineFollower(bool active)
        {
            splineFollower.enabled = active;
        }

        private void OnTriggerEnter(Collider coll) // TODO : Optimize et
        {
            if (coll.gameObject.TryGetComponent(out CollectibleItem item))
            {
                moneyBarController.SetBarMoney(item.itemMoney);


                CoreGameSignals.onChangeTotalMoney?.Invoke(item.itemMoney);
                CoreGameSignals.upgradeTotalMoneyUI?.Invoke();

                item.Interaction();

                playerModel.CheckModelChange(GetMoney());
            }

            else if (coll.gameObject.TryGetComponent(out Gate gate))
            {
                moneyBarController.SetBarMoney(gate.money);

                CoreGameSignals.onChangeTotalMoney?.Invoke(gate.money);
                CoreGameSignals.upgradeTotalMoneyUI?.Invoke();

                playerModel.CheckModelChange(GetMoney());

                if (gate.money > 0)
                    playerAnimationController.SetJoy(true);
                else
                    playerAnimationController.SetSad(true);
                gate.SetParticle();
            }
            else if (coll.gameObject.TryGetComponent(out Machine machine))
            {
                moneyBarController.SetBarMoney(machine.money);


                CoreGameSignals.onChangeTotalMoney?.Invoke(machine.money);
                CoreGameSignals.upgradeTotalMoneyUI?.Invoke();

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

                SetFinal();

            }
        }

        private void SetFinal()
        {
            SetSplineFollower(false);
            transform.DORotate(Vector3.up * 180, .5f, RotateMode.LocalAxisAdd);
            moneyBarController.SetBarUI(false);

            CoreGameSignals.onChangeCameraTargetPosition?.Invoke();
            CoreGameSignals.onSetNextLevelButtonUI?.Invoke(true);
            
            if (!playerModel.IsPoor())
                playerAnimationController.SetDanceAnimation(true);
            else
                playerAnimationController.SetDefeatAnimation(true);
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