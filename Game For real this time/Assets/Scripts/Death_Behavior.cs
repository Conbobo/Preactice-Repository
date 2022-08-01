using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death_Behavior : MonoBehaviour
{
    public string level;
    public GameObject[] lives;
    public Transform[] checkpoints;
    public int currentLives = 3;
    private int currentCPIndex = 0;
    void Start(){
        transform.position = checkpoints[currentCPIndex].position;
    }
    void Update(){
        for(int i = 0; i < checkpoints.GetLength(0); i++) {
            Debug.Log("Checkpoint " + i + ": " + checkpoints[i].position);
        }
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
                transform.position = checkpoints[currentCPIndex].position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Checkpoint")){
            Transform CPPos = transform;
            currentCPIndex++;
            checkpoints[currentCPIndex] = CPPos;
            Destroy(other.gameObject);
        }
    }
    
}
