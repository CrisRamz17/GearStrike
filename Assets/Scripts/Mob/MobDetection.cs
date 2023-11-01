using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDetection : MonoBehaviour
{
    [SerializeField] private float sphereRadius = 5.0f;
    [SerializeField] private float sphereDistance = 10.0f;
    [SerializeField] private LayerMask detectionLayer; // layer mask for the objects
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // if player is within range
        if (player != null)
        {
            Vector3 origin = transform.position;
            Vector3 direction = (player.transform.position - transform.position).normalized;

            bool hit = Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hitInfo, sphereDistance, detectionLayer);

            Color debugColor = hit ? Color.green : Color.red;
            Debug.DrawLine(origin, origin + direction * sphereDistance, debugColor);

            if (hit)
            {
                Debug.Log("Player detected: " + hitInfo.collider.gameObject.name);

                //Mob actions...
            }
        }
    }
}
