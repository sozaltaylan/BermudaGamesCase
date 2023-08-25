using DG.Tweening;
using UnityEngine;


namespace BermudaGamesCase.Controllers
{
    public class AnimationController : MonoBehaviour
    {
        #region Variables

        private Animator anim;

        #endregion

        #region Methods

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void SetAnimationSpeed(float animationSpeed)
        {

            float currentSpeed = anim.GetFloat("MoveSpeed");
            if (currentSpeed == animationSpeed) return;
            DOVirtual.Float(currentSpeed, animationSpeed, .5f, SetAnimSpeed);

        }
        private void SetAnimSpeed(float x)
        {
            anim.SetFloat("MoveSpeed", x);

        }

        #endregion
    }
}