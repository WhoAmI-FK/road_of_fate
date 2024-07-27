using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite board;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;

    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointReached = true;
        }
    }
}
