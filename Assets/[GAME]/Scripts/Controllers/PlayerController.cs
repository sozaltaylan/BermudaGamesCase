using BermudaGamesCase.Managers;
using Dreamteck.Splines;
using UnityEngine;

namespace BermudaGamesCase.Controllers
{

    public class PlayerController : MonoBehaviour
    {
        #region Variables

        private float movementXPosition;

        #region SerializedFields

        [SerializeField] private SplineFollower splineFollower;
        [SerializeField] private AnimationController animationController;
        [SerializeField] private MoneyBarController moneyBarController;
        [SerializeField] private PlayerData playerData;

        [SerializeField] private float lerpSpeed;
        #endregion

        #endregion

        #region Methods


        private void Update()
        {
            var xPosition = InputManager.Instance.Horizantal;
            movementXPosition += xPosition;
            movementXPosition = Mathf.Clamp(movementXPosition, playerData.HorizontalClamp.x, playerData.HorizontalClamp.y);

            var offsetPos = splineFollower.offsetModifier.keys[0].offset.x;
            var lerpOffset = Mathf.Lerp(offsetPos, movementXPosition, Time.deltaTime * lerpSpeed);

            splineFollower.offsetModifier.keys[0].offset.x = lerpOffset;

            animationController.SetAnimationSpeed(splineFollower.followSpeed);
        }
        public void SetSplineFollower(bool active)
        {
            splineFollower.enabled = active;
        }

        private void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.TryGetComponent(out CollectableItemController item))
            {
                Debug.Log("0");
                moneyBarController.SetMoney(item.itemMoney);
            }
        }
        #endregion
    }
}