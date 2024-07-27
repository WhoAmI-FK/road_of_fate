using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private int _damage = 15;

//    public Player _player;

/*    public void setPlayer(Player player)
    {
        _player = player;
    }
*/
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Enemy") && !col.gameObject.CompareTag("Turret") && !col.gameObject.CompareTag("Lava")) {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<Player>().TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
    }

}
