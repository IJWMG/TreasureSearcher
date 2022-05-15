using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TipsController : MonoBehaviour
{
    [SerializeField] private Text firstTip, secondTip, thirdTip;
    private int firstLounch;
    private bool secondTipWatched, thirdTipWatched;
    private void Awake() {
        firstLounch = PlayerPrefs.GetInt("firstLounch");
        if (firstLounch == 0){
            PlayerPrefs.SetInt("firstLounch", 1);
            Debug.Log("first session");
        }
        else{
            Destroy(this.gameObject);
        }
    }
    private void Start() {
        if (SceneManager.GetActiveScene().buildIndex == 1){
            firstTip.gameObject.SetActive(true);
        }
        secondTipWatched = false;
        thirdTipWatched = false;
    }
    private void Update() {
        
        if (Input.GetAxis("Horizontal") != 0 && !secondTipWatched){
            secondTip.gameObject.SetActive(true);
            Destroy(firstTip.gameObject);
            secondTipWatched = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && secondTipWatched && !thirdTipWatched){
            thirdTip.gameObject.SetActive(true);
            thirdTipWatched = true;
            Destroy(secondTip.gameObject);
        }
        if (Input.GetMouseButtonDown(0) && secondTipWatched && thirdTipWatched){
            Destroy(thirdTip.gameObject);
            Destroy(this.gameObject);
        }
    }
}
