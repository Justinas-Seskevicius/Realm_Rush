using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float attackRange = 30f;
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    ParticleSystem lasers;

    private void Start()
    {
        lasers = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(targetEnemy)
        {
            AttackEnemy();
        }
        else
        {
            ActivateLasers(false);
        }
    }

    private void AttackEnemy()
    {
        float distance = Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position);
        if(distance <= attackRange)
        {
            objectToPan.LookAt(targetEnemy);
            ActivateLasers(true);
        }
        else
        {
            ActivateLasers(false);
        }
    }

    private void ActivateLasers(bool isActive)
    {
        var emision = lasers.emission;
        emision.enabled = isActive;
    }
}
