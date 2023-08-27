using BermudaGamesCase.Enums;
using DG.Tweening;
using UnityEngine;


namespace BermudaGamesCase.Others
{
    public class ModelAnimation : MonoBehaviour
    {
        #region Variables

        public Animator animator;
        public PlayerType playerType;
        public float money;

        #endregion
        #region Methods

        public void SetAnimation(float animSpeed)
        {
            animator.SetFloat(AnimatorParameters.speed,animSpeed);
        }

        #endregion
    }
}