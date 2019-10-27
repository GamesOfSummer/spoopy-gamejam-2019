﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float zombieSpeed;
    public float lungeForce;

    private Rigidbody2D zombieRigidBody;

    public bool grounded;
    public LayerMask groundLayer;

    private Collider2D groundCollider;

    // Start is called before the first frame update
    void Start()
    {
        zombieRigidBody = GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(groundCollider, groundLayer);

        zombieRigidBody.velocity = new Vector2(zombieSpeed, zombieRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                zombieRigidBody.velocity = new Vector2(zombieRigidBody.velocity.x, lungeForce);

            }
        }
    }
}
