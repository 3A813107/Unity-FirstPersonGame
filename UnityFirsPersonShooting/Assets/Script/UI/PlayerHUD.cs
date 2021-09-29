using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ShieldBar shieldBar;

    public void UpdateHealth(int currentHealth,int maxHealth)
    {
        healthBar.SetValue(currentHealth,maxHealth);
    }
    public void UpdateShield(int currentShield,int maxShield)
    {
        shieldBar.SetValue(currentShield,maxShield);
    }
}
