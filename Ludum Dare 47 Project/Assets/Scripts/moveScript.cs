﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 playerPosition;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = transform.position;
        speed = 3f;
        transform.position = Camera.main.transform.position;
        StartCoroutine(attachPlayerToCamera());
    }


    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = transform.position;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, AngleBetweenTwoPoints(mousePosition, playerPosition) - 90);
        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y) * speed;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    IEnumerator attachPlayerToCamera()
    {
        yield return new WaitForEndOfFrame();
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }

}