using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Button StartButton;
    public Button QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        QuitButton.onClick.AddListener(StopGame);
    }
    public void StartGame()
    {
        Debug.Log("tesxt");
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
