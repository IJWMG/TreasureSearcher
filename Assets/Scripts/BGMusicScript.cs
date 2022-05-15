using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string createdTag;

    private void Awake() {
        if (PlayerPrefs.GetInt("Music") != 0){
            GetComponent<AudioSource>().mute = true;
        }
        GameObject obj = GameObject.FindWithTag(this.createdTag);
        if (obj != null){
            Destroy(this.gameObject);
        }
        else{
            this.gameObject.tag = this.createdTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
