using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasures : MonoBehaviour
{
    public GameObject trPrefab;
    public string trName;
    public string trType;
    public int trPrice;


    public Treasures (string treasureName, string treasureType, int treasurePrice)
    { 
        trName = treasureName; trType = treasureType; trPrice = treasurePrice; 
        }
    public void SetGameObject (GameObject givenGO){
        trPrefab = givenGO;
    }
}
