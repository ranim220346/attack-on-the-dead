using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim2;
    public float speed;
    public int maxHealth = 100;
    int currentHealth;
    public int damage;
    private SpriteRenderer sr;
    public Sprite explodedBlock;
    public bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim2 = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

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

        Object.Destroy(gameObject, .6f);

    }

}