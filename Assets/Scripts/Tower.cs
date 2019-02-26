using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float attackRange = 30f;
    [SerializeField] Transform objectToPan;


    Transform targetEnemy;
    ParticleSystem lasers;

    private void Start()
    {
        lasers = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        SetTargetEnemy();

        if(targetEnemy)
        {
            AttackEnemy();
        }
        else
        {
            ActivateLasers(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyCollider>();
        if(sceneEnemies.Length > 0)
        {
            Transform closestEnemy = sceneEnemies[0].transform;

            foreach(EnemyCollider enemy in sceneEnemies)
            {
                closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
            }
            targetEnemy = closestEnemy;
        }
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        float distanceA = Vector3.Distance(transform.position, transformA.position);
        float distanceB = Vector3.Distance(transform.position, transformB.position);

        if (distanceA < distanceB)
        {
            return transformA;
        }

        return transformB;
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
