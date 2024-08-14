using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !gameManager.bossAlive)
        {
            StartCoroutine(WinGame());
        }

        
    }
    IEnumerator WinGame()
    {
        // Musiquinha
        yield return new WaitForSeconds(0.5f);
        Debug.Log("You win");
        // Tela de Vitória
    }
}
