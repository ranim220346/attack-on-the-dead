using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    public Transform[] backgrounds;
    public float parallaxscale;
    public float parallaxreductionfactor;
    public float smoothing;
    private Vector3 lastposition;
    // Start is called before the first frame update
    void Start()
    {
        lastposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var parallax = (lastposition.x - transform.position.x) * parallaxscale; 

        for(int i = 0; i < backgrounds.Length; i++)
        {
            var backgroundTargetPosition = backgrounds[i].position.x + parallax * (i * parallaxreductionfactor + 1);
            backgrounds[i].position = Vector3.Lerp(
                backgrounds[i].position,
                new Vector3(backgroundTargetPosition,backgrounds[i].position.y,backgrounds[i].position.z),
                smoothing * Time.deltaTime);
        }
        lastposition = transform.position;
    }
}