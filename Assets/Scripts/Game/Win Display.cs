
using UnityEngine;

public class WinDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject winSequence;

    private static GameObject winSequenceObject;

    void Start(){
        winSequenceObject = winSequence;
    }
    public static void WinSequence(){
        winSequenceObject.SetActive(true);
    }
}
