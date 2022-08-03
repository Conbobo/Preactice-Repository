﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    public Transform edgeOne;
    public Transform edgeTwo;
    public Transform enemyBody;
    private bool movingLeft = true;
    public float enemySpeed;
    private GameObject player;
    public float sightDistance;
    public GameObject fish;
    public Transform unconsumer;
    // Start is called before the first frame update
    void Start()
    {
        FishFling();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Vector3.Distance(player.transform.position, enemyBody.position)); 
        if(Vector3.Distance(player.transform.position, enemyBody.position) <= sightDistance){
           
        }else{
            IdleEnemy();
        }
    }
    void IdleEnemy(){
        if(enemyBody.position.x >= edgeTwo.position.x){
            movingLeft = true;
            Vector3 currentScale = enemyBody.localScale;
            currentScale.x *= -1;
            enemyBody.localScale = currentScale;
        }else if(enemyBody.position.x <= edgeOne.position.x){
            movingLeft = false;
            Vector3 currentScale = enemyBody.localScale;
            currentScale.x *= -1;
            enemyBody.localScale = currentScale;
        }
        Vector3 currentPos = enemyBody.position;
        if(movingLeft){
            currentPos.x -= enemySpeed/100;
        }else{
            currentPos.x += enemySpeed/100;
        }
        enemyBody.position = currentPos;
    }
    void FishFling(){
        Instantiate(fish, unconsumer.position, transform.rotation);
    }
}
