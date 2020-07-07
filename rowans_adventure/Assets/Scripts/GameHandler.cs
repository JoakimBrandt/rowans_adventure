using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
}
