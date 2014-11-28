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
    private Taggable taggable;

    private float hidingTime = 5f; // hide in a spot for up to 5 seconds
    private float hidingTimer;

    private System.Random random = new System.Random();

    void Start ()
    {
        self = GetComponent<Transform>();
        nav = GetComponent <NavMeshAgent> ();
        taggable = GetComponent<Taggable>();
        AllHidingSpots = hidingSpots.getHidingSpots;

        // find a hiding spot right away
        currentDestination = FindClosestHidingSpot();
        nav.SetDestination(currentDestination);
    }


    void Update ()
    {
        

        if (taggable.isIt)
        {
            currentDestination = (player.position);
            nav.SetDestination(player.position);
        }
        else if (taggable.isImmune)
        {
            currentDestination = FindFurthestHidingSpot();
            nav.SetDestination(currentDestination);
            hidingTimer = 0f; // reset hiding timer
        }
        else
        {
            // Add the time since Update was last called to the timer.
            hidingTimer += Time.deltaTime;

            Vector3 currentXandZ = gameObject.transform.position;
            currentXandZ.y = currentDestination.y;

            if (currentXandZ == currentDestination && hidingTimer > hidingTime)
            {
                currentDestination = ChooseRandomHidingSpot();
                nav.SetDestination(currentDestination);
                hidingTimer = 0f; // reset hiding timer
            }
        }
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

    Vector3 ChooseRandomHidingSpot()
    {
        return AllHidingSpots[random.Next(AllHidingSpots.Length)].position;
    }
}
