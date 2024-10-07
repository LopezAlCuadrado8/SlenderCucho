using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private float interactionRange = 1.5f;

    void Update(){
        if(Input.GetKey(KeyCode.E)){
            Ray ray = new(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactionRange)){
                if(hit.transform.TryGetComponent(out IInteractive interactive)){
                    interactive.Interact();
                }
            }
        }
    }

    void DebugRay(){
        Debug.DrawLine(transform.position, transform.position +  transform.forward, Color.red);
    }
}
