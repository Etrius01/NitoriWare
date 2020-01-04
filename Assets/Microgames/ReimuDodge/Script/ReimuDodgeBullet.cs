﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuDodgeBullet : MonoBehaviour {
    // A Unity in-editor variable
    [Header("The thing to fly towards")]
    [SerializeField]
    private GameObject target;

    [Header("BulletSpeed")]
    [SerializeField]
    private float speed;

    [Header("Firing delay in seconds")]
    [SerializeField]
    private float delay;

    [SerializeField]
    private float waitingTime;


    //Stores the direction of travel for the bullet
    private Vector2 trajectory;

	// Use this for initialization
	void Start () {
        // Invoke the setTrajectory method after the delay
        Invoke("SetTrajectory", delay);
    }

    // Update is called once per frame
    void Update()
    {
        // Only start moving after the trajectory has been set
        if (trajectory != null)
        {
            //Move the bullet a certain distance based on trajectory speed and time
            Vector2 newPosistion = (Vector2)transform.position + (trajectory * speed * Time.deltaTime);
            transform.position = newPosistion;
        }
    }
        void SetTrajectory(){
            // Calculate a trajectory towards the target
            trajectory = (target.transform.position - transform.position).normalized;
        }
	
}
/* Initial distance and speed
 * All bullet 8 sq away from target
 * speed 9*
 * delay 0.5 sec for each bullet
 * 
 * Current calculation
 * +2 sq for every circle on same line
 * -0.5 sec */