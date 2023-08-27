using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [HideInInspector] public float money;

    [SerializeField] private ItemData itemData;
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        money = itemData.amount;
    }

    public void Interaction()
    {
        particle.Play(true);
        Destroy(this.gameObject,.5f);
    }
}
