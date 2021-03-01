using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    private Waypoints wPoints;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        //enemy find waypoints script in scene
        wPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position, wPoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        //if the distance between enemy and waypoint is < 0.1f; increase waypoint index (so enemy focuses next waypoint)
        if(Vector2.Distance(transform.position, wPoints.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
        }
        //if enemy reaches last waypoint aka the players base
        if(waypointIndex == wPoints.waypoints.Length)
        {
            //get the "Enemy" component, call the "DealDamage" method and get from the same component the damage variable
            GetComponent<Enemy>().DealDamage(GetComponent<Enemy>().damage);

            //lastly, destroy this gameObject aka this Enemy
            Destroy(gameObject);
        }
    }
}
