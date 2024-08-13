using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;

    public float hMove;
    public float vMove;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        PlayerWalk();
    }

    private void PlayerWalk()
    {
        // Add velocity to playerRb to make he walk;
        playerRb.velocity = new Vector2(hMove, vMove).normalized * speed;

    }
}
