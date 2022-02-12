using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D mySurfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySurfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mySurfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            mySurfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody2D.AddTorque(-torqueAmount);
        }
    }
}
