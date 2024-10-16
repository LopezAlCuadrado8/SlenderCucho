using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private float interactionRange = 1.5f;
    
    private bool canInteract = true;
    void Update(){
        Ray ray = new(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange)){
            if(hit.transform.TryGetComponent(out IInteractive interactive)){
                interactive.InteractText();
                if(Input.GetKey(KeyCode.E)){
                    if(!canInteract) return;
                    interactive.Interact();
                }
            }

        }
    }
}
