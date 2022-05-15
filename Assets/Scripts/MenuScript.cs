using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Text highScore;
    [SerializeField] private GameObject settings, main;
    public void OnPlayClick(){
        SceneManager.LoadScene(1);
    }
    private void Awake() {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString() + "$";
    }
    public void OnExitClick(){
        Application.Quit();
    }
    public void OnSettingsClick(){
        settings.SetActive(true);
        main.SetActive(false);
    }
    public void OnBackClick(){
        settings.SetActive(false);
        main.SetActive(true);
    }
}
