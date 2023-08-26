using BermudaGamesCase.Enums;
using DG.Tweening;
using UnityEngine;


namespace BermudaGamesCase.Others
{
    public class ModelAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator animator;
        [SerializeField] private PlayerType playerType;

        #endregion

        #region Methods

        public void SetAnimationSpeed(float animationSpeed)
        {

            float currentSpeed = animator.GetFloat("MoveSpeed");
            DOVirtual.Float(currentSpeed, animationSpeed, .5f, SetAnimSpeed);

        }
        private void SetAnimSpeed(float x)
        {
            animator.SetFloat("MoveSpeed", x);

        }

        #endregion
    }
}