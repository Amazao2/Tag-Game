using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HidingSpots : MonoBehaviour {

    private Transform[] hidingSpots;

    public Transform[] getHidingSpots {       
        get {
            return hidingSpots;
        }
    }

	// Use this for initialization
	void Awake () {

       hidingSpots = GetComponentsInChildren<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
