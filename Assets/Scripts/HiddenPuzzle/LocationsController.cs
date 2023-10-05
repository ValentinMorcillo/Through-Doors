using UnityEngine;

public class LocationsController : MonoBehaviour
{
    [SerializeField] GameObject[] possibleLocations;
    int unlockedLocations = 0;

    private void Start()
    {
        for (int i = 0; i < possibleLocations.Length; i++)
        {
            TurnOffLocation(i);
    
            possibleLocations[i].GetComponentInChildren<HiddenPuzzlePart>().interactCorrectPart = NewLocationEnabled;
        }

        SetupLocations();
    }

    void SetupLocations()
    {
        possibleLocations[unlockedLocations].GetComponentInChildren<OutlineObjects>().enabled = true;
        possibleLocations[unlockedLocations].GetComponentInChildren<HiddenPuzzlePart>().enabled = true;
    }

    void TurnOffLocation(int locationOff)
    {
        possibleLocations[locationOff].GetComponentInChildren<OutlineObjects>().enabled = false;
        possibleLocations[locationOff].GetComponentInChildren<HiddenPuzzlePart>().enabled = false;
    }


    public void NewLocationEnabled()
    {
        TurnOffLocation(unlockedLocations);

        if (unlockedLocations < possibleLocations.Length - 1)
        {
            unlockedLocations++;

            SetupLocations();
        }
    }
}
