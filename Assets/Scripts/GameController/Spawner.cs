using UnityEngine;
public class Spawner : MonoBehaviour{
    public GameObject[] tetrisobjects;
    public void SpawnRandom() {
        int index = Random.Range(0, tetrisobjects.Length);
        Instantiate(tetrisobjects[index], transform.position, Quaternion.identity);
    } 
}
