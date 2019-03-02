using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float dwellTime = 1f;
    [SerializeField] ParticleSystem selfDestructPS;
    [SerializeField] AudioClip selfDestructSFX;


    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(Patrol(path));
    }

    IEnumerator Patrol(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(selfDestructPS, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(selfDestructSFX, Camera.main.transform.position);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}
