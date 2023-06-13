using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySprites : MonoBehaviour
{
    //[SerializeField] Dictionary<string, GameObject> sprites;
    [SerializeField] List<GameObject> sprites;
    [SerializeField] GameObject SpritePrefab;
    [SerializeField] Sprite Sprite;


    public void AddNewInventorySprites(Sprite sprite, string name)
    {
        SpritePrefab.GetComponent<Image>().sprite = sprite;

        GameObject gameObjectSprite = GameObject.Instantiate(SpritePrefab, transform);
        sprites.Add(gameObjectSprite);
    }
}
