using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject press;
    private bool PlayerInArea = false;

    public GameObject key;

    public GameObject dialogue;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object entered");
        if (other.gameObject.CompareTag("Player"))
        {
            press.SetActive(true);
            PlayerInArea = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            press.SetActive(false);
            PlayerInArea = false;
        }
    }

    void Update()
    {
        if (PlayerInArea)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                dialogue.SetActive(true);
                key.SetActive(true);
            }
        }
    }
}
