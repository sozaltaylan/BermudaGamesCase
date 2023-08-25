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

        #endregion
    }
}