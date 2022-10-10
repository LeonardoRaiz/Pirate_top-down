using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private Transform deathEffect;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Transform effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect.gameObject, 1);
            Destroy(gameObject);
        }
    }
}
