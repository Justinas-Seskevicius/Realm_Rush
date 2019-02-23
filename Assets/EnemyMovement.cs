using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] float dwellTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        Debug.Log("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            Debug.Log("Visiting block " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
        Debug.Log("Ending patrol");
    }
}
