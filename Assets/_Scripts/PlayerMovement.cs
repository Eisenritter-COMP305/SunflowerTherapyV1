using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    public PlayerAnimState playerAnimState;

    public Animator animator;

    public GameController gameController;

    public AudioManager audioManager;

    public Rigidbody2D rb2d;

    public Vector2 force;
    private float waterforce;
    private float normalforce;

    public float distance;
    public LayerMask whatIsLadder;

    //private Animator anim;
    private bool direction;
    private bool jump;

    [SerializeField] private float jumpForce;
    [SerializeField] private Transform[] groundPoints;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask whatIsGround;


    public bool isTalking;
    public bool isInPortal;
    private bool isGrounded;
    private bool isClimbing;

    public static bool airborne;


    // Start is called before the first frame update
    void Start()
    {
        // rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        direction = true;
        playerAnimState = PlayerAnimState.IDLE;
        normalforce = jumpForce;
        waterforce = jumpForce / 2;
    }
    // Update is called once per frame
    void Update()
    {

        JumpControl();

        float horizontal = Input.GetAxis("Horizontal");

        if (isTalking) animator.SetInteger("AnimState", (int)PlayerAnimState.IDLE);
        //if (horizontal == 0)
        //{
        //    animator.SetInteger("AnimState", (int)PlayerAnimState.IDLE);
        //}

        //if (horizontal != 0 && (!onladder || IsGrounded()))
        //{
        //    animator.SetInteger("AnimState", (int)PlayerAnimState.RUN);
        //    Flip(Input.GetAxis("Horizontal"));
        //    // rb2d.AddForce(Vector2.right * force);
        //    rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
        //    MovementControl(horizontal);
        //}



        //if (Input.GetAxis("Jump") > 0 && IsGrounded())
        //{
        //    animator.SetInteger("AnimState", (int)PlayerAnimState.JUMP);
        //    rb2d.AddForce(new Vector2(0, jumpForce));
        //}

    }

    private void FixedUpdate()
    {
        if (isTalking) return;

        float horizontal = Input.GetAxis("Horizontal");



        // =============== Climbing ================== 
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        if (hitInfo.collider)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) isClimbing = true;
     
            //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            //{
            //    isClimbing = false;
            //    MovementControl(horizontal);
            //}  
        }



        if (isClimbing && hitInfo.collider)
        {
            float inputVertical = Input.GetAxisRaw("Vertical");
            rb2d.velocity = new Vector2(0, inputVertical * 2.0f);
            rb2d.gravityScale = 0;
        }
        else
            rb2d.gravityScale = 10;
        // ==========================================





        isGrounded = IsGrounded();
        if (isGrounded)
            MovementControl(horizontal);

        Flip(horizontal);
        ResetValues();
    }

    private void MovementControl(float horizontal)
    {

        if ((isClimbing || isGrounded) && jump)
        {
            animator.SetInteger("AnimState", (int)PlayerAnimState.JUMP);
            isGrounded = false;
            // isClimbing = false;
            rb2d.AddForce(new Vector2(0, jumpForce));
            // airborne = true;

        }

        if (isGrounded)
        {
            if (horizontal == 0)
                animator.SetInteger("AnimState", (int)PlayerAnimState.IDLE);
            else
            {
                audioManager.Play("Running");
                animator.SetInteger("AnimState", (int)PlayerAnimState.RUN);
            }

            rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);


            //animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }
            


    }

    private void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !direction || horizontal < 0 && direction)
        {
            direction = !direction;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private bool IsGrounded()
    {
        foreach (Transform point in groundPoints)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
                if (colliders[i].gameObject != gameObject)
                    return true;
        }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                gameController.Hp -= 10;
                break;
            case "Coin":
                gameController.Mp += 20; // TODO: Testing
                gameController.Hp += 10;
                audioManager.Play("Collect");
                Destroy(other.gameObject);
                break;
            case "Death":
                gameController.Hp = 0;
                break;
            //case "Tutorial":
                //Debug.Log("enter tut: " + isTalking);
                //if (!isTalking)
                //{
                //    Debug.Log("starting to set");
                //    other.gameObject.GetComponent<Spwaner>().SetActive(true);
                //    // Destroy(other.gameObject);
                //}

                //break;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            gameController.Hp -= 0.1f;
            jumpForce = waterforce;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            jumpForce = normalforce;
        }
    }







    private void ResetValues()
    {
        jump = false;
    }
}
