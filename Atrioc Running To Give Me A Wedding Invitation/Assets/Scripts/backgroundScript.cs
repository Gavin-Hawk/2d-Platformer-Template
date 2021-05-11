using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public Vector3 start;
    public float speed;
    private int time;
    public int timeCap;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        transform.position = transform.position + new Vector3( speed, 0, 0);

        if (time >= timeCap)
        {
            transform.position = start;
            time = 0;
        }
    }
}
