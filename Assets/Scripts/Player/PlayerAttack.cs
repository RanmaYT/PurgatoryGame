using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject fire;

    private Vector3[] fireOffsets = new Vector3[4];

    public float cooldown = 2f;
    public bool attacked;
    public bool recharging;

    // Start is called before the first frame update
    void Start()
    {
        fireOffsets[0] = new Vector3(0.65f, 0.75f, 0);
        fireOffsets[1] = new Vector3(0.65f, -0.75f, 0);
        fireOffsets[2] = new Vector3(-0.65f, 0.75f, 0);
        fireOffsets[3] = new Vector3(-0.65f, -0.75f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !recharging)
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Invoke a little fireball
        Invoke("LaunchFire", 0.3f);

        // Trigger the Attack Animation
        attacked = true;

        // AttackCooldown
        StartCoroutine(AttackCooldown());
    }

    private void LaunchFire()
    {
        for(int i = 0; i <= 3; i++)
        {
            GameObject bullet = Instantiate(fire, transform.position + fireOffsets[i], Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = fireOffsets[i] * 3;
        }

    }

    private IEnumerator AttackCooldown()
    {
        recharging = true;   
        yield return new WaitForSeconds(cooldown);
        recharging = false;
    }
}
