using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public enum Scene {
        Level01, 
        Level02,
        Level03
    }

    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
