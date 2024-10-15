using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeOut;

    private static GameObject fadeOutObject;

    void Start(){
        fadeOutObject = fadeOut;
    }
    public static void GameOverSequence(){
        fadeOutObject.SetActive(true);
    }
}
