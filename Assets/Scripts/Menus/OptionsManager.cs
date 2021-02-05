using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    [SerializeReference] private GameObject optionsMenu;
    [SerializeReference] private GameObject generalMenu;

    public void OptionsBtn()
    {
        generalMenu.SetActive(false);
        optionsMenu.SetActive(true);
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
            optionsMenu.SetActive(false);
            generalMenu.SetActive(true);
        }
    }
}
