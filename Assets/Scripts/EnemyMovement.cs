using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyMovement : MonoBehaviour
{
    public HidingSpots hidingSpots;
    public Vector3 currentDestination;

    private NavMeshAgent nav;

    private Animation animation;

    private Transform[] AllHidingSpots;
    public Transform[] allPlayers;

    private Transform self;
    private Taggable taggable;

    private float hidingTime = 5f; // hide in a spot for up to 5 seconds
    private float hidingTimer;

    private float defaultSpeed;

    private System.Random random = new System.Random();

    void Start ()
    {
        self = GetComponent<Transform>();
        nav = GetComponent <NavMeshAgent> ();
        animation = GetComponent<Animation>();
        taggable = GetComponent<Taggable>();

        defaultSpeed = nav.speed;

        AllHidingSpots = hidingSpots.getHidingSpots;

        var taggables = GameObject.Find("TagPlayers").GetComponentsInChildren<Taggable>();
        var transformsOfTaggables = taggables.Select(t => { return t.gameObject.transform; }).ToArray();
        var removeSelf = transformsOfTaggables.Where(t => { return t.gameObject != this.gameObject; });
        allPlayers = removeSelf.ToArray();

        // find a hiding spot right away
        currentDestination = FindClosestHidingSpot();
        nav.SetDestination(currentDestination);
    }


    void Update ()
    {
        if (taggable.isIt)
        {
            nav.speed = defaultSpeed;

            currentDestination = ClosestTagTarget();
            nav.SetDestination(currentDestination);
            animation.Play("Run");
        }
        else if (taggable.isImmune)
        {
            // boost of speed to escape and hide
            nav.speed = defaultSpeed * 1.5f; ;

            currentDestination = FindFurthestHidingSpot();
            nav.SetDestination(currentDestination);
            hidingTimer = 0f; // reset hiding timer
            animation.Play("Run");
        }
        else
        {
            nav.speed = defaultSpeed;

            Vector3 currentXandZ = gameObject.transform.position;
            currentXandZ.y = currentDestination.y;

            animation.Play("Run");

            // hide if you found your spot
            if (currentXandZ == currentDestination)
            {
                hidingTimer += Time.deltaTime;
                animation.Play("Idle_01");

                // hiding for too long
                if (hidingTimer > hidingTime)
                {
                    currentDestination = ChooseRandomHidingSpot();
                    nav.SetDestination(currentDestination);
                    hidingTimer = 0f; // reset hiding timer
                }
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

    Vector3 ClosestTagTarget()
    {
        Vector3 closest = allPlayers.First().position;
        Vector3 currentPos = self.position;

        var distClosest = Vector3.Distance(currentPos, closest);

        foreach (Transform player in allPlayers)
        {
            var distPlayer = Vector3.Distance(currentPos, player.position);
            var taggablePlayer = player.gameObject.GetComponent<Taggable>();

            // closest player that is not immune
            if (distPlayer < distClosest && !taggablePlayer.isImmune)
            {
                closest = player.position;
                distClosest = distPlayer;
            }
        }

        return closest;
    }
}
