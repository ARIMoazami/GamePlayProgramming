using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : Collectable
{
    public GameObject coin_text_go;
    public int default_pickup_amount = 1;

    private Text coin_text_UI;

    private string coin_text_full_string;

    private int current_number_of_coins;
    

    private GameObject player;
    private PlayerMovement player_script;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        player_script = player.GetComponent<PlayerMovement>();
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
        player_script.setCoins(player_script.getCoins() + default_pickup_amount);
        current_number_of_coins = player_script.getCoins();
        updateCoinText();

    }

    private void updateCoinText()
    {
        coin_text_full_string = "Coins Collected: " + current_number_of_coins.ToString();

        coin_text_UI.text = coin_text_full_string;
    }
    
}
