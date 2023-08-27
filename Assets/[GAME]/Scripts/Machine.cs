using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [HideInInspector] public float money;

    [SerializeField] private ItemData itemData;
    [SerializeField] private GameObject particle;

    private void Start()
    {
        money = itemData.amount;
    }

    public void Interaction()
    {
        particle.SetActive(true);
        Destroy(this.gameObject,.5f);
    }
}
