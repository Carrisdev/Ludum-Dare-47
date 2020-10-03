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
        angle = 360.0f;
        radius = 500.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        float y;
        angle -= 0.0005f;
        x = Mathf.Cos(angle) * radius;
        y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, -10.0f);
    }

    void findPosition()
    {

    }


}
