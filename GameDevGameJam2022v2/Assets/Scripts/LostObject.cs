using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostObject : MonoBehaviour
{
    [SerializeField] GameObject npc;
    ReturnLostObjects returnLostObjects;

    private void Awake()
    {
        returnLostObjects = npc.GetComponent<ReturnLostObjects>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            returnLostObjects.lostObjectsFound(1);
        }
    }

    

}
