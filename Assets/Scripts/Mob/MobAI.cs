using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerLoc;
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float acceleration = 8f;
    [SerializeField] private float stunTime = 3f;
    bool follow = false;
    [SerializeField] private Transform[] waypoints;
    public AudioSource[] idleList;
    public AudioSource sound1; public AudioSource sound2; public AudioSource sound3;
    int waypointIndex;
    Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
        idleList = new AudioSource[] { sound1, sound2, sound3 };
        // Find Player location
        playerLoc = GameObject.FindWithTag("Player").transform;

        // Get NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Set NavMeshAgent speed/acceleration
        agent.speed = walkSpeed;
        agent.acceleration = acceleration;

        UpdateDestination();

        StartCoroutine(RandomTime());
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
            TriggerNormalSpeed();
        }
        else
        {
            TriggerChaseSpeed();
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

    public void TriggerChaseSpeed()
    {
        agent.speed = chaseSpeed;
    }

    public void TriggerNormalSpeed()
    {
        agent.speed = walkSpeed;
    }
    IEnumerator RandomTime()
    {
        Debug.Log("balls");
        float randomDelay = Random.Range(2f, 20f);
        yield return new WaitForSeconds(randomDelay);

        RandomIdle();
    }

    void RandomIdle()
    {
        if (idleList.Length > 0)
        {
            int randomIndex = Random.Range(0, idleList.Length);
            AudioSource sound = idleList[randomIndex];
            if (!sound.isPlaying)
            {
                Instantiate(sound);
            }


            StartCoroutine(RandomTime());
        }
        else
        {
            Debug.LogError("No sounds assigned to idleList");
        }
    }
}
