using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    [SerializeField]
    private int spawnAmount;
    [SerializeField]
    private GameObject collectiblePrefab;
    [SerializeField]
    private List<GameObject> Positions;


    private List<GameObject> PositionsTemp;
    void Start(){
        PositionsTemp = Positions;
        for(int i = 0; i < spawnAmount; i++){
            GetPosition();
        }
    }

    void GetPosition(){
        int randomPosition = Random.Range(0,Positions.Count);
        Transform spawnPosition = PositionsTemp[randomPosition].transform;
        Instantiate(collectiblePrefab, spawnPosition);
        PositionsTemp.RemoveAt(randomPosition);
    }
    
}
