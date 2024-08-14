using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    GameManager gameManager;
    EnemyHealth health;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.currentHealth <= 0)
        {
            gameManager.bossAlive = false;
        }
    }
}
