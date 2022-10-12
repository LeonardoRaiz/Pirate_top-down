using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipUI : MonoBehaviour
{
    [SerializeField] private Image healthBarImage; 
    [SerializeField] private HealthManager healthManager; 
    // Start is called before the first frame update
    void Start()
    {
        healthManager.OnDamage += HealthManager_OnDamage;
        healthManager.OnAddLife += HealthManager_OnAddLife;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHealthBar()
    {
        healthBarImage.fillAmount = healthManager.GetHealthNormalized();
    }

    private void HealthManager_OnDamage(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }

    private void HealthManager_OnAddLife(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
}
