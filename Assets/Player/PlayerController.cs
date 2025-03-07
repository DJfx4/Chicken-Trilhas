using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput inputAction;
    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rb;

    public float speed = 2.7f;
    public float jumpForce = 5.0f;

    public GameObject shotPrefab;
    public float shotForce = 10f;

    bool canJump = true;
    bool canAttack = true;
    void Awake()
    {
        inputAction = new PlayerInput();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }


    void Update()
    {
        var movementInput = inputAction.Player_map.Movement.ReadValue<Vector2>();

 

        transform.position += new Vector3(movementInput.x, 0, 0) * Time.deltaTime *speed;

        animator.SetBool("b_isWalking", movementInput.x !=0 );
        if (movementInput.x != 0)
        {
            sprite.flipX = movementInput.x < 0;
        }

        canJump = Mathf.Abs(rb.velocity.y) <= 0.001f;
        HandlerJumpAction();
        HandleAttack();
    
    }

    void HandlerJumpAction()
    {
        var jumpPressed = inputAction.Player_map.Jump.triggered;

        if (canJump && jumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void HandleAttack()
    {
        var attackPressed = inputAction.Player_map.Attack.IsPressed();
        if ( canAttack && attackPressed)
        {
            canAttack = false;

            animator.SetTrigger("t_attack");

        }
    }
   public  void ShotNewEgg()
    {
        var newShot = GameObject.Instantiate(shotPrefab);
        newShot.transform.position = transform.position;

        var isLookRight = !sprite.flipX;
        Vector2 shotDirection = shotForce * new Vector2(isLookRight ? -1 : 1, 0);
        newShot.GetComponent<Rigidbody2D>().AddForce(shotDirection, ForceMode2D.Impulse);
        newShot.GetComponent<SpriteRenderer>().flipY = !isLookRight;
    }
    public void SetCanAttack()
    {
        canAttack = true;
    }
}
