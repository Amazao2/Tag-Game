using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public HidingSpots hidingSpots;
    public Vector3 currentDestination;

    private NavMeshAgent nav;

    private Transform[] AllHidingSpots;

    private Transform self;

    void Start ()
    {
        self = GetComponent<Transform>();
        nav = GetComponent <NavMeshAgent> ();
        AllHidingSpots = hidingSpots.getHidingSpots;

        // find a hiding spot right away
        currentDestination = FindClosestHidingSpot();
    }


    void Update ()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        nav.SetDestination(currentDestination);
            //nav.SetDestination (player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }

    Vector3 FindFurthestHidingSpot()
    {
        Vector3 furthest = AllHidingSpots.First().position;
        Vector3 currentPos = self.position;

        var distFurthest = Vector3.Distance(currentPos, furthest);

        foreach (Transform spot in AllHidingSpots)
        {
            var distSpot = Vector3.Distance(currentPos, spot.position);

            if ( distSpot> distFurthest)
            {
                furthest = spot.position;
                distFurthest = distSpot;
            }
        }

        return furthest;
    }

    Vector3 FindClosestHidingSpot()
    {
        Vector3 closest = AllHidingSpots.First().position;
        Vector3 currentPos = self.position;

        var distClosest = Vector3.Distance(currentPos, closest);

        foreach (Transform spot in AllHidingSpots)
        {
            var distSpot = Vector3.Distance(currentPos, spot.position);

            if (distSpot < distClosest)
            {
                closest = spot.position;
                distClosest = distSpot;
            }
        }

        return closest;
    }
}
