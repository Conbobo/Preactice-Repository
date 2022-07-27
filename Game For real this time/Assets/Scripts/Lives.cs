using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject[] lives;

    public int currentLives = 3;
    
    public int loseLife(){
        currentLives--;
        lives[currentLives].SetActive(false);
        return currentLives;
    }
}
