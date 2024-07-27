using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Direction
{
    Left,
    Right
}

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private string _targetName = "";
    [SerializeField] private Direction _direction;
    [SerializeField] private float _distance = 0.5f;
    [SerializeField] private Transform _target;
    [SerializeField] private LayerMask _mask;

    public static float _speed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        /*
        RaycastHit2D _hit2D = Physics2D.Raycast(transform.position, 
            (_direction==Direction.Left ? Vector2.left : Vector2.right),
            _distance, _mask);
        if (_hit2D)
        {
            _targetName = _hit2D.collider.name;
        }
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    */
        }
}

