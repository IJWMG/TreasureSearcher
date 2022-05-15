using UnityEngine;

public class Finances : MonoBehaviour
{
    private int shovel = 3;
    private int money = 100, totalMoney = 100;

    public void SetMoney (int value){
        if (value >= 0)
        money = value;
        else
        money = 0;
    }
    public int GetMoney (){
        return money;
    }
    public void SetShovel (int shovelValue){
        if (shovelValue >= 0)
        shovel = shovelValue;
        else
        shovel = 0;
    }
    public int GetShovel (){
        return shovel;
    }
   
    public void UseShovel(){
        SetShovel(shovel - 1);
    }
    public void AddMoney(int moneyValue){
        SetMoney(money + moneyValue);
        if (moneyValue > 0){
        AddTotalMoney(moneyValue);
        }
    }
    private void AddTotalMoney(int totalMoneyValue){
        totalMoney += totalMoneyValue;
    }
    public int GetTotalMoney(){
        return totalMoney;
    }
}
