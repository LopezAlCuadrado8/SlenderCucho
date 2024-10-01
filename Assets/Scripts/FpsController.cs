using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    /*
     * Se requiere poner un componente de Character Controller al jugador
     * Colocar la camara como hijo del jugador y ubicarlo a la altura de los ojos
     * Este script de agrega a la camara y no al jugador
    */
    [Space(5)]
    [Header("Movimiento")]

    public float velocity = 5;

    private CharacterController playerController;

    [Space(5)]
    [Header("Camara")]

    public float mouseSensitivity = 500;
    
    [Space(5)]
    

    public const string mouseInputXName = "Mouse X";
    public const string mouseInputYName = "Mouse Y";

    private const string horizontalInputName = "Horizontal";
    private const string verticalInputName = "Vertical";

    private GameObject player;
    private Transform playerTransform;
    private float limitX;
    
    private void Awake()
    {
        LockCursor();
    }


    private void Start()
    {
        player = transform.parent.gameObject;
        playerTransform = player.transform;
        playerController = player.GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        CameraMovement();
    }


    private void Movement()
    {
        float horizontalAmount = Input.GetAxis(horizontalInputName) * velocity;
        float verticalAmount = Input.GetAxis(verticalInputName) * velocity;

        Vector3 horizontalMovement = transform.forward * verticalAmount;
        Vector3 verticalMovement = transform.right * horizontalAmount;

        playerController.SimpleMove(horizontalMovement + verticalMovement);
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void CameraMovement()
    {
        float coorX = Input.GetAxis(mouseInputXName) * mouseSensitivity * Time.deltaTime;
        float coorY = Input.GetAxis(mouseInputYName) * mouseSensitivity * Time.deltaTime;

        limitX += coorY;
        if (limitX > 90.0f)
        {
            limitX = 90.0f;
            coorY = 0.0f;
            ClampXAxisRotationToValue(270f);
        }
        else if (limitX < -90.0f)
        {
            limitX = -90.0f;
            coorY = 0.0f;
            ClampXAxisRotationToValue(90f);
        }

        transform.Rotate(Vector3.left * coorY);
        playerTransform.Rotate(Vector3.up * coorX);

    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

}
