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

            if (possibleLocations[i].TryGetComponent(out HiddenPuzzlePart hiddenPuzzlePart))
            {
                hiddenPuzzlePart.interactCorrectPart += NewLocationEnabled;
            }
        }

        SetupLocations();
    }

    void SetupLocations()
    {
        possibleLocations[unlockedLocations].GetComponent<OutlineObjects>().enabled = true;
        possibleLocations[unlockedLocations].GetComponent<HiddenPuzzlePart>().enabled = true;
    }

    void TurnOffLocation(int locationOff)
    {
        possibleLocations[locationOff].GetComponent<OutlineObjects>().enabled = false;
        possibleLocations[locationOff].GetComponent<HiddenPuzzlePart>().enabled = false;
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
