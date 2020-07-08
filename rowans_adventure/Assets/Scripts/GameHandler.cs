﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    GameHandler instance;
    public SceneLoader sceneLoader;
    public HealthScript healthScript;
    public PickupHandler pickupHandler;
    public UIManager uiManager;
    public AudioSource audioSource;
    public Player player;
    public bool gameHasEnded = false;

    private void Awake() {

        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void LoadNextLevel()
    {
        sceneLoader.LoadNextLevel();
    }

    public void addGem()
    {
        pickupHandler.increaseAmountOfGems();
        uiManager.updateGemText(pickupHandler.getCurrentAmountOfGems().ToString());
    }

    public void addCherry()
    {
        pickupHandler.increaseAmountOfCherries();
        uiManager.updateCherryText(pickupHandler.getCurrentAmountOfCherries().ToString());
    }

    public void takeDamage()
    {
        healthScript.decreaseHealth();

        if(healthScript.isPlayerDead())
        {
            GameOver();
        } else
        {
            return;
        }
    }
    public void GameOver()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            sceneLoader.LoadGameOver();
        }
    }

    public void DestroyGameHandler()
    {
        Destroy(gameObject);
    }

    void Restart()
    {

    }
}
