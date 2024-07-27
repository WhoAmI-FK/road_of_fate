using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _prefabBullet;

    [SerializeField]
    private Transform _respawnBullet;

    [SerializeField]
    private float _fireRate = 1;

    private float _fireTime = 0;

    [SerializeField]
    private float _power = 100f;


    private GameObject _player;

    private bool Shoot = true;

    void Start()
    {
        Shoot = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("YA EBAL V ROT UNITY");
            _player = col.gameObject;
            Shoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("Xuynya");
            Shoot = false;
        }
    }

    void Update()
    {

        if (Shoot)
        {
            _fireTime += Time.deltaTime;

            if (_fireTime > _fireRate)
            {
                _fireTime = 0;

                Rigidbody2D prefab = Instantiate(_prefabBullet, _respawnBullet.position, _respawnBullet.rotation);
              //  Vector3 pos = new Vector3(_player.transform.position.x, _player.transform.position.y);
              //  prefab.AddForce(_player.transform.forward * _power * Time.deltaTime, ForceMode2D.Impulse);

                Vector3 direction = _respawnBullet.position - _player.transform.position;
//                prefab.AddForceAtPosition(direction.normalized, _player.transform.position);
                prefab.AddForce(direction.normalized * _power, ForceMode2D.Impulse);

                Destroy(prefab.gameObject, 2);
            }
        }
    }
}
