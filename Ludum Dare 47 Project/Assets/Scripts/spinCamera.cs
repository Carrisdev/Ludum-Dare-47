using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCamera : MonoBehaviour
{
    float angle;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Main Camera")
        {
            angle = 0.0f;
        } else if(gameObject.name == "KillScreen")
        {
            angle = 0.15f;
        } else if(gameObject.name == "SpawnPoint")
        {
            angle = -0.05f;
        }
        
        radius = 500.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x;
        float y;
        angle -= 0.00005f;
        x = Mathf.Cos(angle) * radius;
        y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, -10.0f);
    }
}
