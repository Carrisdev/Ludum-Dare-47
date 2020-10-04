using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    [SerializeField]
    GameObject leftBlaster;
    [SerializeField]
    GameObject rightBlaster;
    [SerializeField]
    GameObject shot;
    bool shootRight;
    // Start is called before the first frame update
    void Start()
    {
        shootRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (shootRight)
            {
                Instantiate(shot, rightBlaster.transform.position, rightBlaster.transform.rotation);
            } else
            {
                Instantiate(shot, leftBlaster.transform.position, leftBlaster.transform.rotation);
            }
            shootRight = !shootRight;
        }
    }
}
