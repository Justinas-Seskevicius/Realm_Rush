using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] int baseHitpoints = 5;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    private void Start()
    {
        UpdateHealthText();
    }

    private void OnTriggerEnter(Collider other)
    {
        baseHitpoints -= healthDecrease;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = baseHitpoints.ToString();
    }
}
