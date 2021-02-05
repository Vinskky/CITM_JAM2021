using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifesDisplay : MonoBehaviour
{
    public TextMeshProUGUI lifesText;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifesText.text = "Lifes: " + player.GetComponent<PlayerController>().GetLifesNumber();
    }
}
