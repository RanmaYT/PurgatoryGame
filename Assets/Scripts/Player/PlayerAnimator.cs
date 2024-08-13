using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement playerMove;
    private PlayerHealth playerHealth;
    private PlayerAttack playerAttack;

    private Animator playerAnim;

    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();

        playerMove = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = playerMove.hMove != 0 || playerMove.vMove != 0;

        AnimationChange();
    }

    private void AnimationChange()
    {
        // Movement script checking

        playerAnim.SetBool("Walking", isWalking);

        playerAnim.SetFloat("X", playerMove.hMove);
        playerAnim.SetFloat("Y", playerMove.vMove);

        // Health script checking

        if(playerHealth.isDead)
        {
            playerAnim.SetBool("Dead", playerHealth.isDead);
        }

        // Attack script checking

        if(playerAttack.attacked)
        {
            playerAnim.SetTrigger("Attacked");
            playerAttack.attacked = false;
        }

        playerAnim.SetBool("Recharging", playerAttack.recharging);
    }
}
