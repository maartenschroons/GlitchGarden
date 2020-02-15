using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    float timeToWait = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Option Screen");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
