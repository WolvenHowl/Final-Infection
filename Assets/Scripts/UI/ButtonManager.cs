using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button restartAfterDeathButton;

    // Start is called before the first frame update
    void Start()
    {
        restartAfterDeathButton.onClick.AddListener(RestartGame);
    }
    public void RestartGame()
    {
        Debug.Log("tesxt");
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
