using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Solid"))
        {
            Destroy(gameObject);    
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().currentHealth -= damage;

            Destroy(gameObject);
        }
    }
}
