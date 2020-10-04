using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    public int minutes;
    public float seconds;
    
    //starting values
    void Start()
    {
        minutes = 0;
        seconds = 0.0f;
    }

    //every frame add to the timer. if the timer passes 60 seconds add to the minutes
    void Update()
    {
        if(gameManager.state == GameManager.State.playing)
        {
            seconds += Time.deltaTime;
            if(seconds >= 60.0f)
            {
                minutes++;
                seconds -= 60.0f;
            }
        }
    }
}
