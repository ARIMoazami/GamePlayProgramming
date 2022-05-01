using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : Collectable
{
    public GameObject coin_text_go;

    private Text coin_text_UI;

    private string coin_text_full_string;

    private int current_number_of_coins;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Coin Test");
        coin_text_go = GameObject.FindWithTag("CoinText");
        current_number_of_coins = 0;
        coin_text_UI = coin_text_go.GetComponent<Text>();
        updateCoinText();
    }

    private void Update()
    {
        
    }

    public void pickupCoin()
    {
        current_number_of_coins++;
        updateCoinText();

    }

    private void updateCoinText()
    {
        coin_text_full_string = "Coins Collected: " + current_number_of_coins.ToString();

        coin_text_UI.text = coin_text_full_string;
    }
    
}
