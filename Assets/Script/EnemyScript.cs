using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform groundDec;
    public Transform wallCheck;
    public Transform aboveCheck;
    public player_death pb;
    public collector playerCollector;
    public Animator animator;
    private bool movingRight = true;
    public int damage;
    public float speed;
    public bool isDead = false;

    void Start()
    {
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);


        RaycastHit2D groundInfo = Physics2D.Raycast(groundDec.position, Vector2.down, 2f);
        RaycastHit2D frontInfo = Physics2D.Raycast(wallCheck.position, Vector2.right, 0.01f);
        if (groundInfo.collider == false || frontInfo.collider == true && !frontInfo.collider.CompareTag("Player"))
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;

            }
        }

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        RaycastHit2D upInfo = Physics2D.Raycast(aboveCheck.position, Vector2.up, 0.1f);
        if (col.CompareTag("Player") && upInfo.collider == false)
        {
            pb.TakeDamage(damage);
        }
    }
    public void EnemyDeath()
    {        
        Destroy(this.gameObject.GetComponent<Collider2D>());        
        speed = 0;
        playerCollector.point_count += 100;
        Destroy(this.gameObject,1);
    }
}
