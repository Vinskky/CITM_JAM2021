using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeReference] private GameObject pauseMenu;

    public void ResumeBtn()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
