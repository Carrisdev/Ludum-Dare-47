using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScoreText : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    //get the final score from the game manager, and display that on the game over screen
    private void Start()
    {
        int score = gameManager.score;
        gameObject.GetComponent<Text>().text = "SCORE\n\n" + score.ToString();
    }

}
