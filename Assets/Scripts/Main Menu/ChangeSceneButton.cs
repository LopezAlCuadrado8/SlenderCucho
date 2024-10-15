using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    
    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }
}
