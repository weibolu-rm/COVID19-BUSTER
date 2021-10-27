using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{

    [SerializeField] private FloatValue pickupCounter;
    public FloatValue activePickupCounter;

    private void Start()
    {
        activePickupCounter.runTimeValue++;
    }

    private void Pickup(Player player)
    {
        activePickupCounter.runTimeValue--;
        player.ReloadItem(pickupCounter);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        var player = other.GetComponent<Player>();
        Pickup(player);

    }
}
