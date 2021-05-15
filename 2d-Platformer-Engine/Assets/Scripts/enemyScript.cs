using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    //different gameobjects for different places to go
    public GameObject[] movementPoints;
    //which gameobject are you heading twoards
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementPoints[count].transform.position, 1f*Time.deltaTime);
        if (Vector3.Distance(transform.position, movementPoints[count].transform.position) < 1f)
        { 
            if (count >= movementPoints.Length)
            {
                count = 0;
            }
            else
            {
                count++;
            }
        }

    }
}
