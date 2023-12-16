using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed;
    public float minX, maxX;
    public float minY, maxY;

    void Start()
    { 
    }

    void Updaet() 
    {
    }
       void FixedUpdate(){
            if (Target != null)
            {
                Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Cameraspeed * Time.deltaTime);
                float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
                float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
                transform.position = new Vector3(ClampX, ClampY, -10f);
            }
        }
    }
