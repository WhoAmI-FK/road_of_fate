using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingv2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    [SerializeField]
    private float _fireRate = 1;

    private float _fireTime = 0;

    // Update is called once per frame
    void Update()
    {
        
    }
}
