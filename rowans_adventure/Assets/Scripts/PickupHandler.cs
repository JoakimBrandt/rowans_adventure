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

    public int getCurrentAmountOfGems()
    {
        return currentAmountOfGems;
    }

    public int getCurrentAmountOfCherries()
    {
        return currentAmountOfCherries;
    }

    public void increaseAmountOfCherries()
    {
        currentAmountOfCherries++;
    }

    public void increaseAmountOfGems()
    {
        currentAmountOfGems++;
    }
}
