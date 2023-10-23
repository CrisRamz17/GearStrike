using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move, mouseLook;
    private Vector3 rotationTarget;

    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void onMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mouseLook);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Physics.Raycast(ray, out hit))
        {
            rotationTarget = hit.point;
        }
        movePlayerWithAim();
        
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x,0f,move.y);
        if (movement != Vector3.zero){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void movePlayerWithAim()
    {
        var lookPos = rotationTarget - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);

        Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);

        if(aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }

        Vector3 movement = new Vector3(move.x, 0f, move.y);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}