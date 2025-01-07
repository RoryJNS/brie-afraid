using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    public bool movementLocked;
    Animator animator;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementLocked = false;
    }

    void Update()
    {
        if (!movementLocked)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetKey(KeyCode.W))
                transform.eulerAngles = new Vector3(0, 0, 0f);
            if (Input.GetKey(KeyCode.A))
                transform.eulerAngles = new Vector3(0, 0, 90f);
            if (Input.GetKey(KeyCode.S))
                transform.eulerAngles = new Vector3(0, 0, 180f);
            if (Input.GetKey(KeyCode.D))
                transform.eulerAngles = new Vector3(0, 0, 270f);

            if (movement.sqrMagnitude == 0)
            {
                animator.speed = 0;
            }

            else
            {
                animator.speed = 1;
            }
        }
    }

    void FixedUpdate()
    {
        if (!movementLocked)
        {
            rb.MovePosition(rb.position + 4f * Time.fixedDeltaTime * movement);
        }
    }
}