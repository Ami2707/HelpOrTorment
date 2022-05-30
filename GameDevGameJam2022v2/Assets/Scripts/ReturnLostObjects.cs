using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnLostObjects : MonoBehaviour
{
    [Header("Return lost stuff")]
    [SerializeField] GameObject returnLostObjectsBtn;
    [SerializeField] int lostObjects;
    [HideInInspector] int numOfAllObjectsFound = 0;

    private void Awake()
    {
            returnLostObjectsBtn.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (numOfAllObjectsFound >= lostObjects)
        {
            returnLostObjectsBtn.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            returnLostObjectsBtn.SetActive(false);
        }
    }

    public int lostObjectsFound(int numOfObjectsFound)
    {
        numOfAllObjectsFound = numOfAllObjectsFound + numOfObjectsFound;

        return numOfAllObjectsFound;
    }
}
