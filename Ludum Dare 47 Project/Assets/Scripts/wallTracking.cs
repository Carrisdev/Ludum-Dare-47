using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTracking : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mainCamera.transform.position.x-0.77f, mainCamera.transform.position.y-1.34f, -10);
    }
}
