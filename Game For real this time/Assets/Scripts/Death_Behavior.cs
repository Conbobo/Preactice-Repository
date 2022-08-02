using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death_Behavior : MonoBehaviour
{
    public string level;
    public GameObject[] lives;

    public int currentLives = 3;

    public Transform start;
    private Vector3 lastCP;
    void Start(){
        transform.position = start.position;
        lastCP = start.position;
    }
    public int loseLife(){
        currentLives--;
        lives[currentLives].SetActive(false);
        return currentLives;
    } 
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Death")){

            if(loseLife() == 0) {
                Destroy(other.gameObject);
                SceneManager.LoadScene(level); 
            }else{
                transform.position = lastCP;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Checkpoint")){
            lastCP = other.gameObject.transform.position;
            Destroy(other.gameObject);
        }
    }
    
}
