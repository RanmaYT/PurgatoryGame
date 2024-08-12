using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    private float hMove;
    private float vMove;

    public bool isWalking;
    public float xMove;
    public float yMove;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");

        xMove = hMove * speed;
        yMove = vMove * speed;

        isWalking = xMove != 0 || yMove != 0;

        playerAnim.SetBool("Walking", isWalking);
        playerAnim.SetFloat("X", hMove);
        playerAnim.SetFloat("Y", vMove);
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(xMove, yMove);
    }
}
