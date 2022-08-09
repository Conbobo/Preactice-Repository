using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{

    public Rigidbody2D fishBody;
    public float speed;
    private GameObject player;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(transform.position.x > player.transform.position.x){
            speed *= -1;
        }
        fishBody.velocity = new Vector2(speed, fishBody.velocity.y);
        StartCoroutine("DeathTimer");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") || other.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }
    IEnumerator DeathTimer(){
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    
}
