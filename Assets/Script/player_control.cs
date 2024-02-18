using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public int speed;
    public int jump;
    private Rigidbody2D rb;
    private float i;
    public int side;
    public float move;
    public Character character;
    public Animator animator;
    public bool isJumping;
    public bool isGrounded;
    public Transform grounddecfront;
    public Transform grounddecback;
    public RaycastHit2D groundInfoFront;
    public RaycastHit2D groundInfoBack;
    public LayerMask mask;
    Vector2 playerSize;


    void Awake()
    {
        playerSize = GetComponent<CapsuleCollider2D>().size;
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", Mathf.Abs(move));

        animator.SetBool("AnimJump", (!groundInfoFront.collider && !groundInfoBack.collider));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            animator.SetBool("onWall", false);
            animator.SetBool("AnimJump", true);
        }

    }

    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal") * speed;
        groundInfoFront = Physics2D.Raycast(grounddecfront.position, Vector2.down, 0.01f, mask);
        groundInfoBack = Physics2D.Raycast(grounddecback.position, Vector2.down, 0.01f, mask);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, 64);


        if (move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (move < 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);          
        }
        rb.velocity = new Vector3(move, rb.velocity.y, 0);

        if (isJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isJumping = false;
        }

        if (groundInfoFront.collider == true || groundInfoBack.collider == true)
        {
           
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }

       // if (wallHit && groundInfoBack.collider == false)
       //{
       //     animator.SetBool("onWall", true);
       //}

        if (hit && isGrounded == false)
        {

            hit.collider.gameObject.GetComponent<EnemyScript>().EnemyDeath();            

        }


    }
}
