using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 20;
    
    public int currentHealth;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }

        
    }

    private void Die()
    {
        isDead = true;

        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerAttack>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
    }
}
