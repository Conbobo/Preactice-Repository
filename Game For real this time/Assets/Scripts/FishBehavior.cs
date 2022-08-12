using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{

    public Rigidbody2D fishBody;
    public float speed;
    private GameObject player;
    private Quaternion playerZaiNaLi;
    


    void Start()
    {
        Vector2 enemyPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        if(transform.position.x > player.transform.position.x){
            speed *= -1;
        }
        if(transform.position.x < player.transform.position.x){
            speed *= -1;
        }
        float step = speed * Time.deltaTime;
        // playerZaiNaLi = Quaternion.RotateTowards(transform.rotation, player.transform.rotation, step);
        Vector2 direction = enemyPos - (Vector2)player.transform.position;
        fishBody.velocity = speed*direction;
        Debug.Log(direction);
        // transform.rotation = Quaternion.Euler(0, 0, direction);
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
