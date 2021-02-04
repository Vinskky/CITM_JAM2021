using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayBtn(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
        Time.timeScale = 1;
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void MainMenuBtn(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
