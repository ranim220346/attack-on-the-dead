using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyController
{
    
    private Animator anim3;

    // Start is called before the first frame update
    void Start()
    {

        anim3 = GetComponent<Animator>();
        
        anim3.SetBool("isWalking", true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        if (this.isFacingRight == true)
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxspeed, this.GetComponent<Rigidbody2D>().velocity.y);

        }

        else
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxspeed, this.GetComponent<Rigidbody2D>().velocity.y);

        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Wall")
        {

            Flip();

        }

        else if (collider.tag == "Enemy")
        {

            Flip();

        }

        if (collider.tag == "Player")
        {

            FindObjectOfType<PlayerStatus>().TakeDamage(damage);
            Flip();

            anim3.SetTrigger("Attack");
        }

    }

}