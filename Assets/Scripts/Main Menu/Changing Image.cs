using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingImage : MonoBehaviour
{
    [Header("Imagenes")]
    [SerializeField]
    private List<Sprite> Sprites;
    

    private Image image;
    void Start(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        image = GetComponent<Image>();
    }


    public void ChangeImageMethod(){
        int randomImagePositon = Random.Range(0, Sprites.Count);
        image.sprite = Sprites[randomImagePositon];
    }
}
