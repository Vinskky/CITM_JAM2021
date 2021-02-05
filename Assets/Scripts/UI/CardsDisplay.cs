using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardsDisplay : MonoBehaviour
{
    public TextMeshProUGUI cardsText;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cardsText.text = "Cards: " + player.GetComponent<PlayerController>().GetCardsNumber();
    }
}
