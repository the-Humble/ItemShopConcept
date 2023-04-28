using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    private Inventory _inventory;
    private PlayerController _playerController;
    
    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }
    
    
    
    
}
