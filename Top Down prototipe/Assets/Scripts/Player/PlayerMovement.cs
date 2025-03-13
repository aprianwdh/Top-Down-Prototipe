using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = speed * moveDirection;

       
    }

    public void Move(InputAction.CallbackContext context)
    {
        anim.SetBool("IsWalking", true);

        if (context.canceled)
        {
            anim.SetBool("IsWalking", false);
            anim.SetFloat("LastPositionX", moveDirection.x);
            anim.SetFloat("LastPositionY", moveDirection.y);
        }

        moveDirection = context.ReadValue<Vector2>();
        anim.SetFloat("InputX", moveDirection.x);
        anim.SetFloat("InputY", moveDirection.y);

    }
}
