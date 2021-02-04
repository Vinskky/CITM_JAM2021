using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeReference] private GameObject generalMenu;
    [SerializeReference] private GameObject credits;

    public void CreditsBtn()
    {
        generalMenu.SetActive(false);
        credits.SetActive(true);
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
            credits.SetActive(false);
            generalMenu.SetActive(true);
        }
    }
}
