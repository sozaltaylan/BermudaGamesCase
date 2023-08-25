using UnityEngine;

public class CollectableItemController : MonoBehaviour
{
    #region Variables

   [HideInInspector] public float itemMoney;

    [SerializeField] private ItemData itemData;

    #endregion
    #region Methods

    private void Start()
    {
        itemMoney = itemData.amount;
    }

   

    #endregion
}
