using UnityEngine;
public class TetrisObject : MonoBehaviour{
    float lastFall = 0f;
    short position = 0;
    short startPos = 0;

    
    private void Start()
    {
        startPos = (short)transform.position.y;
    }
    void Update(){
        if (MainMenuUI.isPlayMode) { // when game starts then it works
            if (Input.GetKeyDown(KeyCode.LeftArrow) || PlayMenuController.buttonChoice=="Left")
            {
                
                PlayMenuController.buttonChoice = "";
                transform.position += new Vector3(-1, 0, 0);
                if (IsValidGridPosition())
                {
                    UpdateMatrixGrid();
                }
                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || PlayMenuController.buttonChoice == "Right")
            {
                
                PlayMenuController.buttonChoice = "";
                transform.position += new Vector3(1, 0, 0);
                if (IsValidGridPosition())
                {
                    UpdateMatrixGrid();
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || PlayMenuController.buttonChoice == "Rotate")
            {
              
                PlayMenuController.buttonChoice = "";
                transform.Rotate(new Vector3(0, 0, -90));
                if (IsValidGridPosition())
                {
                    UpdateMatrixGrid();
                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, 90));
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || 
                Time.time - lastFall >= 1|| 
                 PlayMenuController.buttonChoice == "Down")
            {
                
                PlayMenuController.buttonChoice = "";
                transform.position += new Vector3(0, -1, 0);
                if (IsValidGridPosition())
                {
                    UpdateMatrixGrid();
                }
                else
                {
                    transform.position += new Vector3(0, 1, 0);
                    MatrixGrid.DeleteWholeRows();
                    FindObjectOfType<Spawner>().SpawnRandom();
                    enabled = false;
                }
               
                    lastFall = Time.time;
               
                // to getect the game over
                position = (short)transform.position.y;
                if (position == startPos){
                    MainMenuUI.isPlayMode = false;
                    PlayMenuController.isGameOver = true;
                } // detect the game is over
            }


        }// end of isPlayMode checker 


        // reset all the tetris objects when game is over
        
    }
    
    bool IsValidGridPosition() {
        foreach (Transform child in transform) {
            Vector2 v = MatrixGrid.RoundVector(child.position);
            if (!MatrixGrid.IsInsideBorder(v))
                return false;
            if (MatrixGrid.grid[(int)v.x, (int)v.y] != null && MatrixGrid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    void UpdateMatrixGrid() {
        for (int y = 0; y < MatrixGrid.column; ++y){
            for (int x = 0; x < MatrixGrid.row; ++x){
                if (MatrixGrid.grid[x, y] != null){
                    if (MatrixGrid.grid[x, y].parent == transform) {
                        MatrixGrid.grid[x, y] = null;
                    }
                }
            }
        }
        foreach (Transform child in transform) {
            Vector2 v = MatrixGrid.RoundVector(child.position);
            MatrixGrid.grid[(int)v.x, (int)v.y]=child;
        }
    }
}
