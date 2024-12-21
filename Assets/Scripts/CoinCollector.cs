using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int numberOfCoins = 0;
    public TMPro.TextMeshProUGUI counterText;
    void Start()
    {
        if (counterText != null)
        {
            counterText.text = "Монеты:0" ;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            numberOfCoins+=1;
            if (counterText != null)
            {
                counterText.text = "Монеты:" + numberOfCoins;
            }
            Destroy(collision.gameObject);
        }
    }
}