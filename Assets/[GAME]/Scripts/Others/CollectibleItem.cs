using DG.Tweening;
using UnityEngine;

namespace BermudaGamesCase.Others
{

    public class CollectibleItem : MonoBehaviour
    {
        #region Variables

        public float rotationSpeed = 180f;
        public float shakeDuration = 0.5f;
        public float shakeStrength = 0.2f;

        [HideInInspector] public float itemMoney;

        [SerializeField] private ItemData itemData;
        [SerializeField] private GameObject particle;

        #endregion
        #region Methods
        private void Start()
        {
            itemMoney = itemData.amount;
            transform.DORotate(new Vector3(0f, 360f, 0f), rotationSpeed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
        }

        public void Interaction()
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


        #endregion
    }

}