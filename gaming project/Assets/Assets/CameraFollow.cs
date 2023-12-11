using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Target;
    public float CameraSpeed;
    public float minY, maxY;
    public float minX, maxX;
    
    
    // Start is called before the first frame update
    void Start()
    {

        //offset = transform.position - Target.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        if (Target != null)
        {

            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed);
            Vector3 TempVect3 = new Vector3(newCamPosition.x, newCamPosition.y, -10f);

            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);

            transform.position = new Vector3(ClampX, ClampY, -10f);

        }

    }

}