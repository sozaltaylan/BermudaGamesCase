using BermudaGamesCase.Others;
using BermudaGamesCase.Signals;
using Unity.VisualScripting;
using UnityEngine;
using BermudaGamesCase.Enums;

namespace BermudaGamesCase.Controllers
{
    public class PlayerAnimationController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator animator;

        private const string _poor = "POOR";
        private const string _average = "AVERAGE";
        private const string _rich = "RICH";

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
            CoreGameSignals.onGameStart += GameStart;
        }
        private void EventUnsubscription()
        {
            CoreGameSignals.onGameStart -= GameStart;
        }
        #endregion
        #region Methods

        public void SetAnimation(string animatorParamater, bool active)
        {
            animator.SetBool(animatorParamater, active);
        }

        public void SetJoy(bool active)
        {
            animator.SetBool(AnimatorParameters.JOY.ToString(), active);
        }
        public void SetSad(bool active)
        {
            animator.SetBool(AnimatorParameters.SAD.ToString(), active);
        }
        public void SetDanceAnimation(bool active)
        {
            animator.SetBool(AnimatorParameters.DANCE.ToString(), active);
        }

        public void SetDefeatAnimation(bool active)
        {
            animator.SetBool(AnimatorParameters.DEFEAT.ToString(), active);
        }
        private void GameStart()
        {
            animator.SetBool(AnimatorParameters.ISMOVE.ToString(), true);
        }

        #endregion
    }
}
