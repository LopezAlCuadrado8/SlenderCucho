using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    private static TextMeshProUGUI textMesh;
    void Start(){
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public static void ChangeText(string text){
        textMesh.text = text;
    }
}
