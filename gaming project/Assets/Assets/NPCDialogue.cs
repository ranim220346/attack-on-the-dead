using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    public Dialogue dialogueManager;

    // Start is called before the first frame update
    void Start()
    {

        flip();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void flip()
    {

        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            string[] dialogue = {
                "Eva : Their are four artifact scattered around the world.",
                "Eva: Each is protected by a guradin to keep it safe from the people like us.",
                "Arthur: Alright , and where is the first one?",
                "Eva : According to my knowledge, is near here , deep in the forest.",
                "Eva : But be careful , zombies and monsters are luring all around here and on alert",
                "Arthur: Dont worry , we are used to the danger , let go Kate.",
                "Kate: I am right beside you brother."
                
            };

            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
            
        }

        //Object.Destroy(gameObject, 0.1f);
    }

}