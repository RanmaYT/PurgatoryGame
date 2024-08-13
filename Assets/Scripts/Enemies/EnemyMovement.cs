using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyRange range;

    Rigidbody2D enemyRb;
    Transform target;
    Vector3 initialPos;

    float speed = 1f;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        range = GetComponentInChildren<EnemyRange>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(transform.position.x < target.transform.position.x)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            MoveEnemy();
        }
    }

    void MoveEnemy()
    {
        if(range.withinRange)
        {
            enemyRb.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            enemyRb.transform.position = Vector3.MoveTowards(transform.position, initialPos, speed * Time.deltaTime);
        }
    }
}
