using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyController
{

    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;
    private Vector3 temp_position;
    public float moveSpeed;
    private PlayerController player;
    private Animator anim4;

    // Start is called before the first frame update
    void Start()
    {

        temp_position = transform.position;
        anim4 = GetComponent<Animator>();
        anim4.SetBool("isWalking", true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        temp_position.x = HorizontalSpeed;
        temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
        transform.position = temp_position;

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

        }

    }

}