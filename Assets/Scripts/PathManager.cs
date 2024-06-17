using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Short Singleton destinada para encargarse de la activacion/desactivación de objetos que bloquean el camino.
/// </summary>
public class PathManager : MonoBehaviour
{
    public static PathManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Method in charge of removing any blocking object by his name.
    /// </summary>
    internal void RemoveBlockingObject(string objectName)
    {
        GameObject blockingObject= GameObject.Find(objectName);
        blockingObject.SetActive(false);
    }
}
