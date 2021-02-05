using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    [SerializeReference] private GameObject optionsMenu;
    [SerializeReference] private GameObject music;

    public void MusicTgl()
    {
        if (music.activeSelf == true)
        {
            music.SetActive(false);
        }
        else
        {
            music.SetActive(true);
        }
    }

    public void FxTgl()
    {
        // TODO
    }

    public void FullscreenTgl()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void AccessibilityTgl()
    {
        // TODO

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            optionsMenu.SetActive(false);
        }
    }
}
