using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private Transform smokeEffect;
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damageAmount);
            Transform impactEffect = Instantiate(smokeEffect, transform.position, Quaternion.identity);
            Destroy(impactEffect.gameObject, .3f);
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damageAmount);
            Transform impactEffect = Instantiate(smokeEffect, transform.position, Quaternion.identity);
            Destroy(impactEffect.gameObject, .3f);
            Destroy(gameObject);
        }
    }

}
