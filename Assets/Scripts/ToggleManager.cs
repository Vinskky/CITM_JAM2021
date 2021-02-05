using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    [SerializeReference] private GameObject optionsMenu;

    public void MusicTgl()
    {

    }

    public void FxTgl()
    {

    }

    public void FullscreenTgl()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void AccessibilityTgl()
    {

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
