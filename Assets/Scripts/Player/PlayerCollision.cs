using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private bool ableToTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && ableToTakeDamage)
        {
            playerHealth.currentHealth--;
            StartCoroutine(TimerUntilNextDamage());
        }

        if(other.gameObject.CompareTag("Lava") && ableToTakeDamage)
        {
            playerHealth.currentHealth--;
            StartCoroutine(TimerUntilNextDamage());
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && ableToTakeDamage)
        {
            playerHealth.currentHealth--;
            StartCoroutine(TimerUntilNextDamage());
        }

        if (other.gameObject.CompareTag("Lava") && ableToTakeDamage)
        {
            playerHealth.currentHealth--;
            StartCoroutine(TimerUntilNextDamage());
        }
    }

    IEnumerator TimerUntilNextDamage()
    {
        ableToTakeDamage = false;
        yield return new WaitForSeconds(2f);
        ableToTakeDamage = true;
    }
}
