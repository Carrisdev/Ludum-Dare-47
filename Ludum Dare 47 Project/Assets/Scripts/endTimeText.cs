using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endTimeText : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    //read the final time from the game manager, and display that at the game over screen
    private void Start()
    {
        int minutes = gameManager.minutes;
        float seconds = gameManager.seconds;
        gameObject.GetComponent<Text>().text = "TIME\n\n" + minutes.ToString() + ":" + seconds.ToString("F2");
    }
}