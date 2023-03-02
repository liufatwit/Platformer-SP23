using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxSpeed;
    public LayerMask layerMask;

    private float direction; //1 or -1, right or left
    private Rigidbody2D rb;
    private Vector3 downRight = new Vector3(1f, -1f, 0f);
    private Vector3 downLeft = new Vector3(-1f, -1f, 0f);
    private RaycastHit2D hit;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = -1; //start moving left
        //downright and left have length of 1.414, so normalize them
        downRight.Normalize();
        downLeft.Normalize();

    }

    // Update is called once per frame
    void Update()
    {
        //change direction based on raycasts

        if (direction == 1)//moving to the right
        {
            hit = Physics2D.Raycast(this.transform.position, downRight, 2f,layerMask);
        } else
        {
            hit = Physics2D.Raycast(this.transform.position, downLeft, 2f,layerMask);
        }

        if (hit.collider == null) //not hitting anything
        {
            direction *= -1;
        }

        //visualize

        Color hitColor = Color.red;
        if (hit.collider == null)
        {
            hitColor = Color.green;
        }

        if (direction == 1)
        {
            Debug.DrawRay(this.transform.position, downRight * 2f, hitColor, 0.05f);
        } else
        {
            Debug.DrawRay(this.transform.position, downLeft * 2f, hitColor, 0.05f);
        }


    }

    private void FixedUpdate()
    {
        //actual movement
        Vector3 velocity = rb.velocity;
        velocity.x = direction * maxSpeed;
        rb.velocity = velocity;
    }
}
