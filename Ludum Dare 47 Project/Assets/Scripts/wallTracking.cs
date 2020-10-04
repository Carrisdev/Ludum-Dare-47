using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTracking : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    void Start()
    {
        
    }

    void Update()
    {
        //keep the walls in line with the camera
        transform.position = new Vector3(mainCamera.transform.position.x-0.77f, mainCamera.transform.position.y-1.34f, -10);
    }
}
