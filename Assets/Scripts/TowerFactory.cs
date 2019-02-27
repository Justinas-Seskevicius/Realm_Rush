using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> queue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int towerCount = queue.Count;

        if(towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        newTower.SetBaseWaypoint(baseWaypoint);
        queue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var oldTower = queue.Dequeue();
        oldTower.GetBaseWaypoint().isPlaceable = true;
        oldTower.SetBaseWaypoint(baseWaypoint);
        baseWaypoint.isPlaceable = false;
        oldTower.transform.position = baseWaypoint.transform.position;
        queue.Enqueue(oldTower);
    }
}
