using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField]
    private GameObject parent;
    public Transform firePoint;
    public float fireForce = 1f;
    public Rigidbody2D rb;

    [SerializeField]
    private float _fireRate = 2;

    private float _fireTime = 0;

    private bool Shoot = false;

    void Start()
    {
        Shoot = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            Shoot = true;
            Debug.Log("Shoot true");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            Debug.Log("Shoot false");
            Shoot = false;
        }
    }

    public void Fire()
    {
        parent.GetComponent<Animator>().SetTrigger("Attack");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Does it work?");
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        if(Shoot)
        {
            _fireTime += Time.deltaTime;
            if (_fireTime > _fireRate)
            {
                _fireTime = 0;
                Fire();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 aimDirection = playerPos - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

}
