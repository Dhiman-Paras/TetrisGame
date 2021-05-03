using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public static bool isQuitGame=false;


    public GameObject playMenuUI;
    public GameObject mainMenuUI;
    // Start is called before the first frame update
    public void Resume() {
        playMenuUI.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
  
    public void Quit()
    {
        isQuitGame = true;
        Time.timeScale = 1f;
        FindObjectOfType<Spawner>().SpawnRandom();
        MainMenuUI.isPlayMode = false;
        gameObject.SetActive(false);
        mainMenuUI.SetActive(true);
        PlayMenuController.score = 0;
    }
}
