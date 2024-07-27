using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    public enum ObjectType {HealthPotion, EXP, Key, Claymore, Plate, WarAxe,Food, RegenPotion};
    public ObjectType _object;
    public int pickupQuantity;
    public int HP = 40;
    public int HPReg = 1;
    public Player _playerRef;
    public LockedDoor door;
    [SerializeField]
    private GameObject press;
    private bool PlayerInArea = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object entered");
        if(other.gameObject.CompareTag("Player"))
        {
            press.SetActive(true);
            PlayerInArea = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            press.SetActive(false);
            PlayerInArea = false;
        }
    }

    void Update()
    {
        if (PlayerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (_object) {
                    case ObjectType.HealthPotion:
                        Debug.Log("Drinking...");
                        _playerRef.DrinkPotion(HP);
                        FindObjectOfType<AudioManager>().Play("Sip");
                        Destroy(gameObject);
                        break;
                    case ObjectType.Key:
                        FindObjectOfType<AudioManager>().Play("KeySound");
                        door.pickKey();
                        Destroy(gameObject);
                        break;
                    case ObjectType.Claymore:
                        _playerRef.IncDamage(25);
                        Destroy(gameObject);
                        FindObjectOfType<AudioManager>().Play("Equip");
                        break;
                    case ObjectType.WarAxe:
                        _playerRef.IncDamage(10);
                        Destroy(gameObject);
                        FindObjectOfType<AudioManager>().Play("Equip");
                        break;
                    case ObjectType.Plate:
                        _playerRef.IncMaxHealth(50);
                        Destroy(gameObject);
                        FindObjectOfType<AudioManager>().Play("Equip");
                        break;
                    case ObjectType.Food:
                        _playerRef.DrinkPotion(10);
                        Destroy(gameObject);
                        FindObjectOfType<AudioManager>().Play("Eat");
                        break;
                    case ObjectType.RegenPotion:
                        FindObjectOfType<HealthRegen>().incRegen(HPReg);
                        Destroy(gameObject);
                        FindObjectOfType<AudioManager>().Play("Sip");
                        break;
                }
            }
        }
    }
}
