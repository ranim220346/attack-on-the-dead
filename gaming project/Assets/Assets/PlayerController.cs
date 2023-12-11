using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movingspeed;
    public float jumpheight;
    public bool FacingRight;
    public KeyCode Spacebar;
    public KeyCode R;
    public KeyCode L;
    public KeyCode Space;
    //public KeyCode Sheild;
    //public bool sheilded;
    public Transform groundcheck;
    public LayerMask whatIsGround;
    public float groundcheckradius;
    private bool grounded;
    private Animator anim;
    public Transform AttackPart;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float attackRate = 2f;
    float NextAttackTime = 0f;
    public int totalkey = 0;

    // Start is called before the first frame update
    void Start()
    {
        //sheilded = false;
        FacingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(Spacebar) && grounded)
        {

            Jump();

        }

        anim.SetBool("Grounded", grounded);

        if (Input.GetKey(L))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(-movingspeed, GetComponent<Rigidbody2D>().velocity.y);
            if (FacingRight)
            {

                flip();
                FacingRight = false;

            }

        }

        if (Input.GetKey(R))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(movingspeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!FacingRight)
            {

                flip();
                FacingRight = true;

            }


        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        //if (Input.GetKey(Sheild))
        //{

        //    Sheild();
            
        //}

        //anim.SetBool("Sheild", sheilded);


        if (Time.time >= NextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Attack();
                NextAttackTime = Time.time + 1f / attackRate;

            }

        }
        

        void flip()
        {

            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }

        void Jump()
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpheight);
        }

        void Attack()
        {

            anim.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPart.position, attackrange, enemyLayers);

            //foreach(Collider2D other in hitEnemies)
            //{

            //    if(other.tag == "Sword")
            //    {

            //        FindObjectOfType<EnemyController>().TakeDamage(attackDamage);

            //    }

            //}

            foreach (Collider2D enemy in hitEnemies)
            {

                enemy.GetComponent<EnemyPatroll>().TakeDamage(attackDamage);

            }

        }

        //void Sheild()
        //{

        //    sheilded == true;

        //}

    }

    void OnDrawGizmosSelected()
    {

        if (AttackPart == null)
        {

            return;

        }

        Gizmos.DrawWireSphere(AttackPart.position, attackrange);

    }

    void Die()
    {

        Debug.Log("Player Died");

        anim.SetBool("Isdead", true);

        FindObjectOfType<LevelManager>().RespawnPlayer();

    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, whatIsGround);

    }

}