using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private EnemyMovement enemyMove;
    private EnemyHealth enemyHealth;

    private Animator enemyAnim;
    private SpriteRenderer enemySR;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();

        enemyMove = GetComponent<EnemyMovement>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        AnimationsSet();
    }

    void Flip()
    {
        if (enemyMove.facingRight)
        {
            enemySR.flipX = false;
        }
        else
        {
            enemySR.flipX = true;
        }
    }
    void AnimationsSet()
    {
        if (enemyHealth.isDead)
        {
            enemyAnim.SetBool("Dead", enemyHealth.isDead);
        }
    }
}
