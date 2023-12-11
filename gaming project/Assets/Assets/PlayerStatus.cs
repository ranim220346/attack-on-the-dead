using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public int MaxHealth = 400;
    public int Lives = 3;

    public Image healthbar;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    public int keyCollected = 0;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

    }

    void SpriteFlicker()
    {

        if(this.flickerTime < this.flickerDuration)
        {

            this.flickerTime = this.flickerTime + Time.deltaTime;

        }
        else if (this.flickerTime >= this.flickerDuration)
        {

            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;

        }

    }

    public void TakeDamage(int damage)
    {

        if(this.isImmune == false)
        {

            this.MaxHealth = this.MaxHealth - damage;
            healthbar.fillAmount = this.MaxHealth/400f;
            if (this.MaxHealth < 0)
                this.MaxHealth = 0;

            if(this.Lives > 0 && this.MaxHealth == 0)
            {

                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.MaxHealth = 400;
                this.Lives--;

            }

            else if(this.Lives == 0 && this.MaxHealth == 0)
            {

                Debug.Log("Gameover");
                Destroy(this.gameObject);

            }

            Debug.Log("Player Health:" + this.MaxHealth.ToString());
            Debug.Log("Player Lives:" + this.Lives.ToString());

        }

        PlayerReaction();

    }

    void PlayerReaction()
    {

        this.isImmune = true;
        this.immunityTime = 0f;

    }

    public void CollectKey(int keyValue)
    {

        this.keyCollected = this.keyCollected + keyValue;

    }

    void Update()
    {

        if(this.isImmune == true)
        {

            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;

            if(immunityTime >= immunityDuration)
            {

                this.isImmune = false;
                this.spriteRenderer.enabled = true;

            }

        }

    }

}