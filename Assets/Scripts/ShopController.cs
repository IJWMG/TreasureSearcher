using UnityEngine;
using UnityEngine.UI;


public class ShopController : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    [SerializeField] private Finances finances;
    [SerializeField] private GameObject xImagine;
    [SerializeField] private Text oneShovel, threeShovels;
    private static int buyingCount;

    private void Start() {
        buyingCount = 0;
    }
    private void Update() {
        if (buyingCount<9) {
            oneShovel.text = (100 + (buyingCount * 100) +"$");
        }
        else {
            oneShovel.text = ("1000$");
        }
        if (buyingCount > 3){
            xImagine.SetActive(true);
         }
        else{
            threeShovels.text = (300 + (buyingCount * 100) +"$");
         }
    }

     public void OnThreeShovels (){
        if (finances.GetMoney() >= (300 + buyingCount*100) && buyingCount <= 3){
            BuyAnyShovel(300);
        }
        else
        Debug.Log("not enough money");
   }
    public void OnOneSovel (){
       if (finances.GetMoney() >= 100 + (buyingCount * 100) && buyingCount <=9){
           BuyAnyShovel(100);
        }
        else if (finances.GetMoney() >=1000 && buyingCount > 9){
            BuyAnyShovel(100);
        }
        else
        Debug.Log("not enough money");
    }
    public void LeftShop(){
        uIController.ExitShop();

        Debug.Log("You left Shop");

    }
    private void BuyAnyShovel(int shovelPrice){
            
            finances.AddMoney ( buyingCount > 9? -1000 : - (shovelPrice + buyingCount * 100));
            uIController.ShowMoney(finances.GetMoney());
            finances.SetShovel(finances.GetShovel() + shovelPrice/100);
            uIController.ShowShovels();
            Debug.Log("You bought "+ shovelPrice/100  +" Shovels");
            buyingCount++;
    }
    public int GetBuyCount(){
        return buyingCount;
    }
}
