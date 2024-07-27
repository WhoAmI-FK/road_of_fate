using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int golden_coins = 0;
    [SerializeField] private Text goldenCoinsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("golden_coin"))
        {
            Destroy(collision.gameObject);
            golden_coins++;
            goldenCoinsText.text = "Coins: " + golden_coins;
        }
    }
}
