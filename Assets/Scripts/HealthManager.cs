using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event EventHandler OnDamage; 
    public event EventHandler OnAddLife; 

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Transform deathEffect;


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        OnDamage?.Invoke(this, EventArgs.Empty);

        if (_currentHealth <= 0)
        {
            Transform effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Enemy>().Drop();
                ScoreUI.scoreValue += gameObject.GetComponent<Enemy>().GetPoints();
            }
            Destroy(effect.gameObject, 1);
            Destroy(gameObject);
        }
    }

    public float GetHealthNormalized()
    {
        return  (float)_currentHealth / _maxHealth;
    }

    public int maxHealth
    {
        get { return _maxHealth; }
    }

    public int currentHealth
    {
        get { return _currentHealth; }
    }

    public void AddLife()
    {
        _currentHealth += 1;
        OnAddLife?.Invoke(this, EventArgs.Empty);
    }

}
