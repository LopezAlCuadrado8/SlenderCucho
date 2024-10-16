using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Collectible : MonoBehaviour, IInteractive
{
    [SerializeField]
    private float distanceToInteract = 2.5f;

    public void Interact()
    {
        CollectiblesDisplay.IncreaseCollectiblesAmount();
        DisplayText.ChangeText("");
        Destroy(gameObject);
    }

    public void InteractText(){
        if((transform.position - FpsController.position).sqrMagnitude <= distanceToInteract){
            DisplayText.ChangeText("Interactua con \"E\"");
        }else{
            DisplayText.ChangeText("");
        }
    }
}
