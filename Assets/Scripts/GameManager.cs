using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    [SerializeField] GameObject Victory;

    public int keyCount;
    public bool bossAlive;

    private void Start()
    {
        Victory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCount == 3)
        {
            barrier.SetActive(false);
        }

        if (!bossAlive)
        {
            Victory.SetActive(true);
        }
    }
}
