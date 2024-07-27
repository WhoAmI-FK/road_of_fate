using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject pressedState;

    [SerializeField]
    private GameObject water;

    [SerializeField]
    private GameObject bridge;

   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<AudioManager>().Play("PanelPress");
            pressedState.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(water);
            bridge.SetActive(true);
            FindObjectOfType<AudioManager>().Play("BridgeUpWater");
            Destroy(gameObject);

        }
    }
}
