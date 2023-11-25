using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDetection : MonoBehaviour
{
    [SerializeField] private float sphereRadius = 1.0f;
    [SerializeField] private float sphereDistance = 4.0f;
    [SerializeField] private LayerMask detectionLayer; // layer mask for the objects
    private GameObject player;
    private MobAI mobAI;

    private bool hit;
    private bool wasHitLastFrame;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get Player
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 origin = transform.position;
            Vector3 direction = (player.transform.position - transform.position).normalized;
            hit = Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hitInfo, sphereDistance, detectionLayer);
            wasHitLastFrame = !hit;
        }
        
        //Get MobAI
        mobAI = GetComponent<MobAI>();

        if (mobAI == null)
        {
            Debug.LogError("Mob oject with MobAI script not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if player is alive
        if (player != null)
        {
            Vector3 origin = transform.position;
            Vector3 direction = (player.transform.position - transform.position).normalized;

            hit = Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hitInfo, sphereDistance, detectionLayer);

            Color debugColor = hit ? Color.green : Color.red;
            Debug.DrawLine(origin, origin + direction * sphereDistance, debugColor);

            /*
            if (hit)
            {
                mobAI.SetFollow(hit);
            }
            else
            {
                mobAI.SetFollow(hit);
            }
            */

            //Debug.Log("Player detected: " + hitInfo.collider.gameObject.name);

            
            if (hit != wasHitLastFrame)
            {
                mobAI.SetFollow(hit);
                wasHitLastFrame = hit;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = hit ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}
