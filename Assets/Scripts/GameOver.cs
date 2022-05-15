using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    [SerializeField] private Finances finances;
    [SerializeField] private ShopController shopController;
    [SerializeField] private Text highScoreText, currentScoreText;
    private void Start() {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio !=null && PlayerPrefs.GetInt("Sound") !=0){
            audio.mute = true;
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            ReturnToStartScreen();
        }
    }

    public void GameOverCheck()
    {
        if (finances.GetShovel() == 0 && finances.GetMoney() < (100 + 100 * shopController.GetBuyCount())){
            HighScoreCheck();
            uIController.GameOverPannelOn();
            //Debug.Log("game is over");
        }
    }
    public void TryAgainButton(){
        SceneManager.LoadScene(1);
    }
    public void ReturnToStartScreen(){
        SceneManager.LoadScene(0);

    }
    private void HighScoreCheck(){
        if (PlayerPrefs.GetInt("HighScore") < finances.GetTotalMoney()){
            PlayerPrefs.SetInt("HighScore", finances.GetTotalMoney());
            highScoreText.text = "NEW HIGHSCORE! \n High Score is: " + finances.GetTotalMoney().ToString() + "$";
        }
        else{
            highScoreText.text = "High Score is: " + PlayerPrefs.GetInt("HighScore") + "$";
        }
        currentScoreText.text = "Your Score is: " + finances.GetTotalMoney() + "$";
    }

}
