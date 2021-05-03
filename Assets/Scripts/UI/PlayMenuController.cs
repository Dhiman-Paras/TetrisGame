using UnityEngine;
using UnityEngine.UI;
public class PlayMenuController : MonoBehaviour{

    public static ulong score = 0;
    public Text scoreText;
    public Text finalScoreText;
    public static bool isGameOver = false;

    public GameObject scoreBordUI;
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;

    public static string buttonChoice="";
    public AudioManager audioManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
        finalScoreText.text = "Total Score\n " + score.ToString();
        if (isGameOver) {
            scoreBordUI.SetActive(true);
            gameObject.SetActive(false);
        
        }
    }

    public void Left() {
        buttonChoice = "Left";
        audioManager.Play("Sound");
    }
    public void Right() {
        buttonChoice = "Right";
        audioManager.Play("Sound");
    }
    public void Down() {
        buttonChoice = "Down";
        audioManager.Play("Sound");

    }
    public void Rotate() {
        buttonChoice = "Rotate";
        audioManager.Play("Sound");
    }

    public void PlayAgain() {// for Play Again which is in the Score Boad UI
        FindObjectOfType<Spawner>().SpawnRandom();
        isGameOver = false;
        MainMenuUI.isPlayMode = true;
        scoreBordUI.SetActive(false);
        gameObject.SetActive(true);
        score = 0;
    }

    public void GotoHome() {
        isGameOver = false;
        scoreBordUI.SetActive(false);
        mainMenuUI.SetActive(true);
       
        MainMenuUI.isPlayMode = false;
        score = 0;
    }
    public void GotoPauseMenuUI() {
        Time.timeScale = 0f;
        gameObject.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
