using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] public int invulnerabilityTime;

    public HealthBar healthBar;


    void Start()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
        invulnerabilityTime = 3000;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void increaseHealth()
    {
        currentHealth++;
        healthBar.IncreaseHealth();
    }

    public void decreaseHealth()
    {
        currentHealth--;
        healthBar.DecreaseHealth();
    }

    public void restoreAllHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(5);
    }

    public int getCurrenHealth()
    {
        return currentHealth;
    }

    public int getCurrentMaxHealth()
    {
        return maxHealth;
    }
}
