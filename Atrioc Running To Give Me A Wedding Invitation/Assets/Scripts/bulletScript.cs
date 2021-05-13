using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private float speed;
    //this is used to make sure that the bullet doesn't go on forever
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        speed = .5f;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //this object moves to the right at a speed set by a private variable that can be edited
        //also it gets destroyed when it hits something or goes too far away
        transform.position = transform.position + new Vector3(speed,0,0);
    }

    //a collision detection to see if the bullet hits another object
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
