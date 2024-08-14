using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dissapear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().currentHealth--;
            Destroy(gameObject);
        }
    }
}
