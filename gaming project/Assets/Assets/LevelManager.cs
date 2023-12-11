using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject CurrentCheckpoint;
    public Transform player;
    public Transform player2;
    public Transform Block;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {

        FindObjectOfType<PlayerController>().transform.position = CurrentCheckpoint.transform.position;

    }

    public void RespawnBlock()
    {

        Instantiate(Block, transform.position, transform.rotation);

    }

}