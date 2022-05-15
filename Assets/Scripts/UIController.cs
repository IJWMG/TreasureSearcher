using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] private Finances finances;
    [SerializeField] private GameObject coverSprite, shopPanel, gameOverPanel;
    [SerializeField] private PointCreator pointCreator;
    [SerializeField] private TreasureController treasureController;
    [SerializeField] private GameOver gameOver;
    public Text moneyCount, shovel, totalMoneyCount;
    private static bool isShovelDown, isSkipButtonOn;
    
    void Start()
    {
        isShovelDown =false;
        isSkipButtonOn = false;
        ShowMoney(finances.GetMoney());
        ShowShovels();
        GameObject audio = GameObject.FindWithTag("BG_music");
        if (audio.GetComponent<AudioSource>().mute && PlayerPrefs.GetInt("Music") == 0){
            audio.GetComponent<AudioSource>().mute = false;
        }
    }

    public void ShowMoney(int moneyValue){
        moneyCount.text = moneyValue.ToString() + "$";
        totalMoneyCount.text = "Total money: " + finances.GetTotalMoney().ToString() + "$";
    }
    public void ShowShovels(){
        shovel.text = "x" + finances.GetShovel().ToString();
        //Debug.Log("this is it");
    }
    public void DownTheShovel() {
        if (finances.GetShovel() >= 1){
            Debug.Log("u trying to dig it out, skip is " + isSkipButtonOn + "shovel is " + isShovelDown);

            if ((!isSkipButtonOn) && (!isShovelDown)){
                isShovelDown = true;
                StartCoroutine(ShovelIsDown());
            }
        }
        else{
        OpenUpShopWindow();
        }
    }
    public void OpenUpShopWindow(){
        shopPanel.SetActive(true);
    }
    public void SkipButtonOn(){
        //Debug.Log("u trying to skip it, shovei is " + isShovelDown);

        if(!isShovelDown && !isSkipButtonOn){
        isSkipButtonOn = true;
        //Debug.Log("skip is coming babe " + isSkipButtonOn);

        StartCoroutine(TreasureSkiped());
        }
    }
    private IEnumerator ShovelIsDown(){
        coverSprite.SetActive(false);
        pointCreator.DestroyEveryPoint();
        finances.UseShovel();
        ShowShovels();
        treasureController.SellTreasure();
        ShowMoney(finances.GetMoney());
        gameOver.GameOverCheck();
        yield return new WaitForSeconds (1.5f);
        treasureController.DeleateTreasure();
        //Debug.Log("Item selled");
        yield return new WaitForSeconds (0.5f);

        coverSprite.SetActive(true);
        treasureController.CreateTreasure();
        //Debug.Log("treasure created, coroutine stoped");
        isShovelDown = false;
        StopCoroutine(ShovelIsDown());
    }
    private IEnumerator TreasureSkiped(){
       // Debug.Log("treasure skipped, isSkipButtonOn = " + isSkipButtonOn);

        coverSprite.SetActive(false);
        pointCreator.DestroyEveryPoint();

        yield return new WaitForSeconds (1.5f);
        treasureController.DeleateTreasure();
        yield return new WaitForSeconds (0.3f);

        coverSprite.SetActive(true);
        treasureController.CreateTreasure();
        isSkipButtonOn = false;
        //Debug.Log("treasure skiped, skip is " + isSkipButtonOn);
        StopCoroutine(TreasureSkiped());

    }
    public void ExitShop(){
        shopPanel.SetActive(false);
    }
    public void GameOverPannelOn(){
        gameOverPanel.SetActive(true);
        GameObject.FindWithTag("BG_music").GetComponent<AudioSource>().mute = true;
        StopAllCoroutines();
    }
}
