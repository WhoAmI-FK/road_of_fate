using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        if (player.position.y <= -6.11f)
        {
            transform.position = new Vector3(player.position.x, -6.11f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
