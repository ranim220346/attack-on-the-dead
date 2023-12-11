using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite explodedBlock;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            sr.sprite = explodedBlock;

            //Object.Destroy(gameObject, 1.0f);

        }

    }

}