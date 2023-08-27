using UnityEngine;

namespace BermudaGamesCase.Others
{
    public class Gate : MonoBehaviour
    {
        #region Variables

        [HideInInspector] public float money;

        [SerializeField] private ItemData itemData;

        #endregion
        #region Methods

        private void Start()
        {
            money = itemData.amount;
        }

        #endregion
    }

}