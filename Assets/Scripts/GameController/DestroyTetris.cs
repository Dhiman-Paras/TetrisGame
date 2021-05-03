using UnityEngine;

public class DestroyTetris : MonoBehaviour
{

    void Update() {
        if (PlayMenuController.isGameOver || PauseMenuUI.isQuitGame ) Destroy(gameObject);
    
    }
}
