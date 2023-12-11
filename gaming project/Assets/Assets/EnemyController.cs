using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool isFacingRight = false;
    public float maxspeed = 3f;
    public int damage;
    public int maxHealth;
    int currentHealth;
    private Rigidbody2D rb;
    private Animator anim2;
    private SpriteRenderer sr;
    public Sprite explodedBlock;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim2 = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //anim2.SetBool("isWalking", true);

    }


    // Update is called once per frame
    void Update()
    {
        

    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        anim2.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {

            Die();

        }

        Debug.Log("Enemy Health:" + this.currentHealth.ToString());

    }

    void Die()
    {

            Debug.Log("Enemy Died");

            anim2.SetBool("Isdead", true);

            sr.sprite = explodedBlock;

            Object.Destroy(gameObject, .5f);

    }

    public void Flip()
    {

        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {

            FindObjectOfType<PlayerStatus>().TakeDamage(damage);
                
        }

    }

}