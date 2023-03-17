using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static int PlayerScene = 4;
    public void MoveToScene(int sceneID) // Changes scene based on the sceneID
    {
        SceneManager.LoadScene(sceneID);
    }
    [SerializeField] GameObject pauseMenu;
    public void PlayerSceneDetector()
    {
        SceneManager.LoadScene(PlayerScene);
    }
    public void Pause()
    {
        //pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Makes it so nothing can move
    }
    public void Resume()
    {
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Goes to pause menu when clicking escape
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Resume();
        }
    }
}
