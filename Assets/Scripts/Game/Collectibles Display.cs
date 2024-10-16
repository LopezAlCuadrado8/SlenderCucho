using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectiblesDisplay : MonoBehaviour
{
    private static TextMeshProUGUI display;

    [HideInInspector]
    public static int collectiblesAmount;

    void Start(){
        display = GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        if (collectiblesAmount >= 7){
            FpsController.CanMove(false);
            WinDisplay.WinSequence();
        }
    }

    public static void IncreaseCollectiblesAmount(){
        collectiblesAmount++;
        display.text = collectiblesAmount + "/7";
    }
}
