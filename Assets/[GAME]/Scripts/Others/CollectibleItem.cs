using UnityEngine;

namespace BermudaGamesCase.Others
{

    public class CollectibleItem : MonoBehaviour
    {
        #region Variables


        [HideInInspector] public float itemMoney;
        
        [SerializeField] private ItemData itemData;
        [SerializeField] private GameObject particle;

        #endregion
        #region Methods
        private void Start()
        {
            itemMoney = itemData.amount;
        }

        public void Interaction() 
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


        #endregion
    }

}