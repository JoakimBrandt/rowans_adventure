using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    [SerializeField] int currentAmountOfGems;
    [SerializeField] int currentAmountOfCherries;

    // Start is called before the first frame update
    void Start()
    {
        currentAmountOfCherries = 0;
        currentAmountOfGems = 0;
    }

    int getCurrentAmountOfGems()
    {
        return currentAmountOfGems;
    }

    int getCurrentAmountOfCherries()
    {
        return currentAmountOfCherries;
    }

    void increaseAmountOfCherries()
    {
        currentAmountOfCherries++;
    }

    void increaseAmountOfGems()
    {
        currentAmountOfGems++;
    }
}
