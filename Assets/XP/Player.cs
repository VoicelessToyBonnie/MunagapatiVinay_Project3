using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats:")]
    [SerializeField]
    private int _attack = 5;
    [SerializeField]
    private int _playerHealth = 100;

    public void IncreaseStats()
    {
        _attack += 2; 
        _playerHealth += 20;
    }
}
