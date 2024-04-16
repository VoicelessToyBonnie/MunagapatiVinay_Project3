using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private string _name;

    [SerializeField]
    private int _health;
    [SerializeField]
    private int _XPpoints = 10;
}
