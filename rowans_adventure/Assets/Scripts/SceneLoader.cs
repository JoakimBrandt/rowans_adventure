using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void triggerAnimation()
    {
        transition.SetTrigger("Start");
    }

    public void fadeOut()
    {
        transition.SetTrigger("FadeOUT");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation

        transition.SetTrigger("Start");

        // Wait for animation to finish

        yield return new WaitForSeconds(transitionTime);

        // Finally load scene

        SceneManager.LoadScene(levelIndex);
    }

}
