using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int numOfKeysReq;

    public void pickKey()
    {
        numOfKeysReq--;
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfKeysReq==0)
        {
            FindObjectOfType<AudioManager>().Play("DoorOpen");
            Destroy(gameObject);
        }
        
    }
}
