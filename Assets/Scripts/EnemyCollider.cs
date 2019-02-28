using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticleSystem;
    [SerializeField] ParticleSystem deathVFX;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
        else
        {
            hitParticleSystem.Play();
        }
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}
