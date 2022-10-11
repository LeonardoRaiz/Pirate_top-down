using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float stopDistance;
    [SerializeField] private float attackSpeed;
    private float attackTime;
    private void Update()
    {

        if (player != null)
        {
            RotateToPlayer();

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
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

    private IEnumerator Attack()
    {
        
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            player.GetComponent<HealthManager>().TakeDamage(damageAmount);
            gameObject.GetComponent<HealthManager>().TakeDamage(3);
        }
    }
    
}   
