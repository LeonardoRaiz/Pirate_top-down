using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private float stopDistance;

    [SerializeField] private float attackTime;
    [SerializeField] private Transform enemyBullet;
    [SerializeField] private Transform enemyFirePoint;
    [SerializeField] private int bulletForce;


    private void Update()
    {
        if (player != null)
        {
            RotateToPlayer();

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            if (Time.time >= attackTime)
            {
                FindObjectOfType<AudioManager>().Play("BulletFront");
                Rigidbody2D bullet = RangedAttack(enemyFirePoint);
                bullet.AddForce(enemyFirePoint.up * bulletForce, ForceMode2D.Impulse);
                attackTime = Time.time + timeBetweenAttacks;
            }
        }
    }


    private void RotateToPlayer()
    {
        Vector3 toTarget = player.position - transform.position;
        float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRotation);
    }

    public Rigidbody2D RangedAttack(Transform firePoint)
    {
        Transform bullet = Instantiate(enemyBullet, firePoint.position, Quaternion.identity);
        Rigidbody2D theRB = bullet.GetComponent<Rigidbody2D>();
        return theRB; 
    }
}
