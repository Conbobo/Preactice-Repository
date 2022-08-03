using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{

    public Rigidbody2D fishBody;
    public float speed;

    
    void Start()
    {
        fishBody.velocity = new Vector2(speed * -1, fishBody.velocity.y);
        StartCoroutine("DeathTimer");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
    IEnumerator DeathTimer(){
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    
}
