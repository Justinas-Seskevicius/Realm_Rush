using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] GameObject deathVFX;

    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if(hitPoints <= 0)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
