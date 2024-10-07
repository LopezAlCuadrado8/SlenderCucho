using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Collectible : MonoBehaviour, IInteractive
{
    [SerializeField]
    private float distanceToInteract = 1.5f;
    void Update(){
        if((transform.position - FpsController.position).sqrMagnitude <= distanceToInteract){
            DisplayText.ChangeText("Interactua con \"E\"");
        }else{
            DisplayText.ChangeText("");
        }
    }

    public void Interact()
    {
        Destroy(gameObject);
    }
}
