using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    [SerializeField] int currentAmountOfGems;
    [SerializeField] int currentAmountOfCherries;
    [SerializeField] int currentAmountOfParchments;

    // Start is called before the first frame update
    void Start()
    {
        currentAmountOfCherries = 0;
        currentAmountOfGems = 0;
        currentAmountOfParchments = 0;
    }

    public int getCurrentAmountOfGems()
    {
        return currentAmountOfGems;
    }

    public int getCurrentAmountOfCherries()
    {
        return currentAmountOfCherries;
    }

    public int getCurrentAmountOfParchments()
    {
        return currentAmountOfParchments;
    }

    public void increaseAmountOfCherries()
    {
        currentAmountOfCherries++;
    }

    public void increaseAmountOfGems()
    {
        currentAmountOfGems++;
    }

    public void increaseAmountOfParchments()
    {
        currentAmountOfParchments++;
    }
}
