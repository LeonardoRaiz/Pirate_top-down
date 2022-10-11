using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event EventHandler OnDamage; 
    public event EventHandler OnAddLife; 

    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private Transform deathEffect;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        OnDamage?.Invoke(this, EventArgs.Empty);

        if (currentHealth <= 0)
        {
            Transform effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Enemy>().Drop();
            }
            Destroy(effect.gameObject, 1);
            Destroy(gameObject);
        }
    }

    public float GetHealthNormalized()
    {
        return  (float)currentHealth / maxHealth;
    }

    public void AddLife()
    {
        currentHealth += 1;
        OnAddLife?.Invoke(this, EventArgs.Empty);
    }

}
