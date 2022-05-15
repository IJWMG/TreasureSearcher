using UnityEngine;

public class TreasureController : MonoBehaviour
{
    [SerializeField] private GameObject hat1, hat2, hat3, can1, can2, shoe, ring, chest;
    [SerializeField] private Finances finances;
    private GameObject currentTreasure;
    private Treasures treasure;
    
    private Treasures [] treasures = new Treasures [] {
    new Treasures ("Cilindre hat", "OK", 120),   
    new Treasures ("Cowboy hat", "OK", 100),
    new Treasures ("Mexican hat", "Garbage", 50),
    new Treasures ("Metall can", "Garbage", 10),
    new Treasures ("Aluminium can", "Garbage", 5),
    new Treasures ("Old shoe", "Garbage", 15),
    new Treasures ("GoldenRing", "Treasure", 500),
    new Treasures ("Chest full of gold", "Treasure", 1000),
    };
    private int realTreasuresCounter;
    private void Start() {
        GameObject[] treasureList = new GameObject[] {hat1, hat2, hat3, can1, can2, shoe, ring, chest};
        for (int i = 0; i< treasures.Length; i++){
            treasures[i].SetGameObject(treasureList[i]);
        }
        CreateTreasure();
    }
    public void CreateTreasure (){
        treasure = treasures[Random.Range(0, treasures.Length)];
        if (treasure.trType != "Treasure"){
            Vector3 treasurePos = new Vector3 (treasure.trPrefab.transform.position.x, treasure.trPrefab.transform.position.y, treasure.trPrefab.transform.position.z);
            currentTreasure = Instantiate(treasure.trPrefab, treasurePos,  Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        }
        else if (treasure.trType == "Treasure" && realTreasuresCounter > 2){
            Vector3 treasurePos = new Vector3 (treasure.trPrefab.transform.position.x, treasure.trPrefab.transform.position.y, treasure.trPrefab.transform.position.z);
            currentTreasure = Instantiate(treasure.trPrefab, treasurePos,  Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            realTreasuresCounter = 0;
        }

        else{
            realTreasuresCounter++;
            Debug.Log("real Treasure Detected, counter is "+ realTreasuresCounter);
            CreateTreasure();
        }
    }
    public void SellTreasure(){
        int price = treasure.trPrice;
        //Debug.Log(price);
        finances.AddMoney(price);
    }
    public void DeleateTreasure(){
        Destroy(currentTreasure);
    }
}
