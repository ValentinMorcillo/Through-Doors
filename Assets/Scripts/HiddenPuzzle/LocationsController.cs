using UnityEngine;

public class LocationsController : MonoBehaviour
{
    [SerializeField] GameObject[] possibleLocations;
    int unlockedLocations = 0;

    private void Start()
    {
        SetupLocations();
    }
    
    void SetupLocations()
    {
        possibleLocations[unlockedLocations].GetComponent<OutlineObjects>().enabled = true;
        possibleLocations[unlockedLocations].GetComponent<HiddenPuzzlePart>().enabled = true;
    }

    void TurnOffLocation()
    {
        possibleLocations[unlockedLocations].GetComponent<OutlineObjects>().enabled = false;
        possibleLocations[unlockedLocations].GetComponent<HiddenPuzzlePart>().enabled = false;
    }


    public void NewLocationEnabled()
    {
        TurnOffLocation();

        unlockedLocations++;

        SetupLocations();
    }


}
