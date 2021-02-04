using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayBtn(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void QuitBtn()
    {
        Application.Quit();
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
