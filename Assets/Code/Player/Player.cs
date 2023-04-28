using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    private PlayerController _playerController;

    public Inventory PlayerInventory { get; private set; }

    private void Awake()
    {
        PlayerInventory = GetComponent<Inventory>();
    }
    
    
    
    
}
