using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGmeMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel; 
    private static bool menuIsActive;
    [SerializeField] private Text highScore;

private void Start(){
    menuIsActive = false;
    highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString() + "$";

}

   public void OpenMenu (){
    if (!menuIsActive){
    menuPanel.SetActive(true);
    menuIsActive = true;
   }
   }
   public void CloseMenu(){
    menuPanel.SetActive(false);
    menuIsActive = false;
   }
}
