using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{

    public int health;
    public int lives = 3;
    public float flickerDura1on = 0.1f;
    private float flickerTime = 0f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    public float immunityDura1on = 1.5f;
    public Slider healthUI;
    private float immunityTime = 0f;

    // public int coinsCollected = 0;
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDura1on)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0f)
                this.health = 0;
            if (this.lives > 0f && this.health == 0f)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("Gameover"); //add game over splash screen
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health : " + this.health.ToString());
            Debug.Log("Player Lives : " + this.lives.ToString());
        }
        PlayHitReac1on();
    }
    void PlayHitReac1on()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDura1on)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDura1on)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
}


