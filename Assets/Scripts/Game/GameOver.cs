using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverSequence;

    private static GameObject gameOverSequenceObject;

    void Start(){
        gameOverSequenceObject = gameOverSequence;
    }
    public static void GameOverSequence(){
        gameOverSequenceObject.SetActive(true);
    }
}
