using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerLoc;
    bool follow = false;
    [SerializeField] private float stunTime = 3f;
    [SerializeField] private Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find Player location
        playerLoc = GameObject.FindWithTag("Player").transform;

        // Get NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLoc != null)
        {
            if (follow)
            {
                //Debug.Log("Following");
                agent.SetDestination(playerLoc.position);
            }
            else
            {
                //Invoke(nameof(UpdateDestination), stunTime);
                
                // when Mob gets to waypoint
                if (Vector3.Distance(transform.position, target) < 1)
                {
                    IterateWaypointIndex();
                    UpdateDestination();
                }
            }
        }

    }

    public void SetFollow(bool set)
    {
        follow = set;

        if (!follow)
        {
            // Mob will return to waypoints
            Invoke(nameof(UpdateDestination), stunTime);
        }
    }

    public bool GetFollow()
    {
        return follow;
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;

        // when the last waypoint is reached, go back to the first
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
