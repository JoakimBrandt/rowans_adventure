using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    public static GameHandler instance;
    public static SceneLoader sceneLoader;
    public static HealthScript healthScript;
    public static PickupHandler pickupHandler;
    [SerializeField] public Player player;

    public bool gameStart = false;

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
        if (Input.GetKeyDown("1"))
        {
            SceneLoader.Load(SceneLoader.Scene.Level01);
        }

        if (Input.GetKeyDown("2"))
        {
            SceneLoader.Load(SceneLoader.Scene.Level02);
        }

        if (Input.GetKeyDown("3"))
        {
            SceneLoader.Load(SceneLoader.Scene.Level03);
        }
    }
}
