using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] int baseHitpoints = 5;

    private void OnTriggerEnter(Collider other)
    {
        baseHitpoints--;
        Debug.Log("Base Hitpoints decreased -> " + baseHitpoints);
    }
}
