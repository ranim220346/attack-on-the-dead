using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public bool isFacingRight = false;
    public float maxspeed = 3f;
    public int damage;
    private Rigidbody2D rb;
    private Animator anim2;
    public float jumpheight;
    public Transform groundcheck;
    public LayerMask whatIsGround;
    public float groundcheckradius;
    private bool grounded;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim2 = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxspeed * Time.deltaTime);

        }

        else
        {

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -maxspeed * Time.deltaTime);
        }

        anim2.SetBool("isWalking", true);
    }

    void Jump()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpheight);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Jump")
        {

            Jump();
            
        }

        anim2.SetBool("Grounded", grounded);

    }

}