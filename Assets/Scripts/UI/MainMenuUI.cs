using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject playMenuUI;
    public static bool isPlayMode = false;

    public AudioManager audioManager;



    public void SoundController(bool s)
    {
        if (s) audioManager.sounds[0].source.pitch = 1f;
        else audioManager.sounds[0].source.pitch = 0f;
    }
    public void MusicController(bool s) {
        if(s)audioManager.sounds[1].source.pitch = 1f;
        else audioManager.sounds[1].source.pitch = 0f;
    }
    // Start is called before the first frame update
    private void Awake()
    {
       // Time.timeScale = 0f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play() {
        playMenuUI.SetActive(true);
        gameObject.SetActive(false);
       // Time.timeScale = 1f;
        isPlayMode = true;
        PauseMenuUI.isQuitGame = false;
        FindObjectOfType<Spawner>().SpawnRandom();
    }
}
