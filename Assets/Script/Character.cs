using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb;
    public float fallMultiplayerl = 2.5f;
    public float lowJumpMultiplayer = 2f;
    private Vector2 facingRight;
    public bool isFacingRight;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        facingRight = new Vector2(transform.localScale.x, transform.localScale.y);
        isFacingRight = true;
    }
    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplayerl;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplayer;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }
    public void Flip(int x)
    {
        if (x==1 && !isFacingRight)
        {
            transform.localScale = facingRight;
            isFacingRight = true;
        }
       else if (x==-1 && isFacingRight)
        {

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isFacingRight = false ;
        }
    }
    
}
