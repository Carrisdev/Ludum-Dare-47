using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCamera : MonoBehaviour
{
    float angle;
    float radius;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Main Camera")
        {
            angle = 0.0f;
        } else if(gameObject.name == "KillScreen")
        {
            angle = 0.20f;
        } else if(gameObject.name == "SpawnPoint")
        {
            angle = -0.15f;
        }
        
        radius = 300.0f;
        speed = 0.0001f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x;
        float y;
        angle -= speed;
        x = Mathf.Cos(angle) * radius;
        y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, -10.0f);
    }

    public void increaseSpeed(float increase)
    {
        speed += increase;
    }
}
