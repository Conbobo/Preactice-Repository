using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward_Behavior : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Wifi");
        if(other.CompareTag("Player")){
            Destroy(gameObject);
            Vector3 playerScale = player.transform.localScale;
            playerScale *= 1.2f;
            player.transform.localScale = playerScale;
        }

    }
}
