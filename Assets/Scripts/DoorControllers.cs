using DG.Tweening;
using UnityEngine;


public class DoorControllers : MonoBehaviour
{
    [SerializeField] float angle = 90.0f;
    [SerializeField] float openDuration = 1.0f;
    private bool isOpen = false;

    [SerializeField] AudioSource openDoorAS;


    private void Start()
    {
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            transform.DOLocalRotate(new Vector3(0, angle, 0), openDuration);
            isOpen = true;

            openDoorAS.Play();
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            transform.DOLocalRotate(Vector3.zero, openDuration);
            isOpen = false;
        }
    }
}
