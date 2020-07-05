using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] public int invulnerabilityTime;

    void Start()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
        invulnerabilityTime = 3000;
    }

    void increaseHealth()
    {
        currentHealth++;
    }

    void decreaseHealth()
    {
        currentHealth--;
    }

    void increaseMaxHealth()
    {
        maxHealth++;
    }

    void decreaseMaxHealth()
    {
        maxHealth--;
    }

    void restoreAllHealth()
    {
        currentHealth = maxHealth;
    }

    int getCurrenHealth()
    {
        return currentHealth;
    }

    int getCurrentMaxHealth()
    {
        return maxHealth;
    }
}
