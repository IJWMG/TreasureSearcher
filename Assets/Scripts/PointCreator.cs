using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCreator : MonoBehaviour
{
   [SerializeField] private GameObject pointPrefab;
   private GameObject currentPoint;
   public List<GameObject> points = new List<GameObject>();

    public void CreatePoint(Vector3 positionPoint)
    {
        currentPoint = Instantiate(pointPrefab, new Vector3 (positionPoint.x, positionPoint.y, -3), Quaternion.identity) as GameObject;
        points.Add(currentPoint);
        //Debug.Log("point created, list lenth is "+ points.Count);

    }
    public void DestroyEveryPoint(){
        foreach (GameObject point in points){
            Destroy(point);
        }
        points.Clear();
    }
}
