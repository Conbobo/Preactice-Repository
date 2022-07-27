using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death_Behavior : MonoBehaviour
{
    public string level;
    public Lives lifeManager;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            
            if(lifeManager.loseLife() == 0) {
                Destroy(other.gameObject);
                SceneManager.LoadScene(level); 
            }
        }
    }
}
