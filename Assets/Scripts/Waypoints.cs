using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] waypoint;
    public int target;
    [SerializeField] private float speed;
    void Start()
    {
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == waypoint[target].position)
        {
            increaseTarget();
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoint[target].position, speed*Time.deltaTime);
        transform.LookAt(waypoint[target]);
    }

    void increaseTarget() 
    { 
        target++; 
        if (target >= waypoint.Length)
        {
            target = 0;
        }
    }
}
