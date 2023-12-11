using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    private Vector2 move, mouseLook;
    private Vector3 rotationTarget;
    private Animator animator;

    public void onMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)
        {
            animator.SetBool("isWalking", true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            animator.SetBool("isWalking", false);
        }

        move = context.ReadValue<Vector2>(); // read the value of the input
    }

    public void onMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>(); // read the value of the input
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

        transform.Translate(speed * Time.deltaTime * movement, Space.World);
    }

    public void movePlayerWithAim()
    {
        var lookPos = rotationTarget - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);

        Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);

        if (aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }

        movePlayer();

        //Vector3 movement = new Vector3(move.x, 0f, move.y);

        //transform.Translate(speed * Time.deltaTime * movement, Space.World);
    }
}
