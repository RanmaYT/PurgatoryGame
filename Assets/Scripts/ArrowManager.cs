using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;

    private Vector3[] arrowPos = new Vector3[6];
    private Vector3[] arrowDirection = new Vector3[2];

    public float arrowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        arrowPos[0] = new Vector3(-50, 30, 0);
        arrowPos[1] = new Vector3(-45, 30, 0);
        arrowPos[2] = new Vector3(-40, 30, 0);
        arrowPos[3] = new Vector3(-59, 25, 0);
        arrowPos[4] = new Vector3(-59, 20, 0);
        arrowPos[5] = new Vector3(-59, 15, 0);

        arrowDirection[0] = new Vector3(0, -1, 0);
        arrowDirection[1] = new Vector3(1, 0, 0);
    }

    private void ShootArrows()
    {
        for(int i = 0; i < arrowPos.Length; i++)
        {
            if(i <= 2)
            {
                GameObject arrow = Instantiate(arrowPrefab, arrowPos[i], Quaternion.identity) as GameObject;
                arrow.transform.Rotate(0, 0, -90);
                arrow.GetComponent<Rigidbody2D>().velocity = arrowDirection[0] * arrowSpeed;        
            }
            else
            {
                GameObject arrow = Instantiate(arrowPrefab, arrowPos[i], Quaternion.identity) as GameObject;
                arrow.GetComponent<Rigidbody2D>().velocity = arrowDirection[1] * arrowSpeed;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("ShootArrows", 0.5f, 1.5f);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CancelInvoke("ShootArrows");
        }
    }
}
