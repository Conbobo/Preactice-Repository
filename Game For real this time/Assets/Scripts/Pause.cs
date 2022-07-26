using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public void OnPause(){
        isPaused = !isPaused;
        if(isPaused){
            Time.timeScale = 0f;
        }else {
            Time.timeScale = 1f;
        }
        
    }
}
