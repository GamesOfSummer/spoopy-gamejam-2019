using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimRunning : MonoBehaviour
{

    public float escapeSpeed;

    public float speedDecreaser;
    public float speedDecreaseMilestone;
    private float speedMilestoneCount;

    public bool grounded;
    public LayerMask groundLayer;

    private Collider2D groundCollider;

    private Rigidbody2D victimRigidBody;

    private GameObject theZombie;
    private Vector2 zombiePosition;
    private Vector3 victimPosition;

    // Start is called before the first frame update
    void Start()
    {
        victimRigidBody = GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<Collider2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        theZombie = GameObject.Find("Zombie");
        zombiePosition = theZombie.transform.position;
        victimPosition = transform.position;
        if ((victimPosition.x - zombiePosition.x) < 10)
        {
            Runaway();
        }
    }

    void Runaway()
    {
        grounded = Physics2D.IsTouchingLayers(groundCollider, groundLayer);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedDecreaseMilestone;
            escapeSpeed = escapeSpeed * speedDecreaser;
        }

        victimRigidBody.velocity = new Vector2(escapeSpeed, victimRigidBody.velocity.y);
    }

    
}
