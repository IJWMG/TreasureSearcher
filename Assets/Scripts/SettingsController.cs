using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour
{
    [SerializeField] Image galkaMusic, galkaSound;
    private int music, sound;

    private void Start() {
        music = PlayerPrefs.GetInt("Music");
        sound = PlayerPrefs.GetInt("Sound");
        if (music != 0){
            galkaMusic.gameObject.SetActive(false);
        }
        if (sound != 0){
            galkaSound.gameObject.SetActive(false);
        }
        
    }
    public void OnMusicClick(){
        if (galkaMusic.gameObject.activeSelf){
            PlayerPrefs.SetInt("Music", 1);
            GameObject.FindWithTag("BG_music").GetComponent<AudioSource>().mute = true;
        }
        else {
            PlayerPrefs.SetInt("Music", 0);
            GameObject.FindWithTag("BG_music").GetComponent<AudioSource>().mute = false;
        }
        galkaMusic.gameObject.SetActive(!galkaMusic.gameObject.activeSelf);

    }
     public void OnSoundClick(){
        if (galkaSound.gameObject.activeSelf){
            PlayerPrefs.SetInt("Sound", 1);
        }
        else {
            PlayerPrefs.SetInt("Sound", 0);
        }
        galkaSound.gameObject.SetActive(!galkaSound.gameObject.activeSelf);

    }

}
