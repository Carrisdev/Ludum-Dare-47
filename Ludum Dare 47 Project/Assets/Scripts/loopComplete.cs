using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loopComplete : MonoBehaviour
{
    //once the player completes the loop, add a lot of points and speed up by a lot
    IEnumerator completedLoop()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        for(int i = 0; i < 4; i++)
        {
            gameObject.GetComponent<Text>().text = "LOOP\nCOMPLETE";
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    public void startFlash()
    {
        StartCoroutine(completedLoop());
    }
}
