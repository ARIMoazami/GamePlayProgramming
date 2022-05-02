using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : Collectable
{
    public GameObject coin_text_go;

    private Collectable_ collectable_class_script;

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
        collectable_class_script = gameObject.GetComponent<Collectable_>();
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
        player_script.setCoins(player_script.getCoins() + collectable_class_script.coin_value);

        current_number_of_coins = player_script.getCoins();
        updateCoinText();

        Destroy(gameObject);

    }

    private void updateCoinText()
    {
        coin_text_full_string = "Coins Collected: " + current_number_of_coins.ToString();

        coin_text_UI.text = coin_text_full_string;
    }
    
}
