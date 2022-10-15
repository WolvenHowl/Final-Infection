using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button MainMenuAfterDeath;
    public Button restartAfterDeathButton;
    public Button QuitGame;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuAfterDeath.onClick.AddListener(MainMenu);
        restartAfterDeathButton.onClick.AddListener(RestartGameAfterDeath);
        QuitGame.onClick.AddListener(QuiteGameAfterDeath);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    public void RestartGameAfterDeath()
    {
        Debug.Log("tesxt");
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    public void QuiteGameAfterDeath()
    {
        Application.Quit();
    }
}
