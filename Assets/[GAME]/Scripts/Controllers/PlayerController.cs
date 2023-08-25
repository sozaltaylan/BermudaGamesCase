using Dreamteck.Splines;
using UnityEngine;

namespace BermudaGamesCase.Controllers
{

    public class PlayerController : MonoBehaviour
    {
        #region Variables

        #region SerializedFields

        [SerializeField] private SplineFollower splineFollower;
        [SerializeField] private AnimationController animationController;
        [SerializeField] private MoneyBarController moneyBarController;

        #endregion

        #endregion

        #region Methods


        private void Update()
        {
            animationController.SetAnimationSpeed(splineFollower.followSpeed);
        }
        public void SetSplineFollower(bool active)
        {
            splineFollower.enabled = active;
        }


        private void Movement()
        {

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