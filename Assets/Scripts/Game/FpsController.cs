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
    [SerializeField]
    private float walkingVelocity = 5;
    [SerializeField]
    private float runningVelocity = 10;
    [SerializeField]
    public float stamina = 10;
    [SerializeField]
    private float staminaDepletionRate = 1;
    [SerializeField]
    private float staminaRecoveryRate = 1;

    [Space(5)]
    [Header("Camara")]
    public float mouseSensitivity = 500;
    
    [HideInInspector]
    public float maxStamina;
    public const string mouseInputXName = "Mouse X";
    public const string mouseInputYName = "Mouse Y";
    public static Vector3 position;
    public static bool canMove = true;
    
    
    private const string horizontalInputName = "Horizontal";
    private const string verticalInputName = "Vertical";

    private CharacterController playerController;
    private GameObject player;
    private Transform playerTransform;
    private float limitX;
    private bool canRun = true;

    private void Awake()
    {
        LockCursor();
    }


    private void Start()
    {
        maxStamina = stamina;

        player = transform.parent.gameObject;
        playerTransform = player.transform;
        playerController = player.GetComponent<CharacterController>();
    
    }

    private void Update()
    {
        if(!canMove) return;
        Movement();
        CameraMovement();
        position = transform.position;
    }


    private void Movement()
    {
        
        float horizontalAmount = Input.GetAxis(horizontalInputName);
        float verticalAmount = Input.GetAxis(verticalInputName);

        Vector3 horizontalMovement = transform.forward * verticalAmount;
        Vector3 verticalMovement = transform.right * horizontalAmount;

        Vector3 movementeAmount = Vector3.ClampMagnitude(horizontalMovement + verticalMovement, 1f);
        
        if (Input.GetKey(KeyCode.LeftShift) && (horizontalAmount != 0 || verticalAmount != 0) && canRun){
            if(stamina <= 0){
                canRun = false;
                stamina = 0;
            }else{
                stamina -= Time.deltaTime * staminaDepletionRate;
            }

            playerController.SimpleMove(movementeAmount * runningVelocity);
        }else{
            if(stamina >= maxStamina){
                stamina = maxStamina;
            }else{
            stamina += Time.deltaTime * staminaRecoveryRate;
                if (stamina >= maxStamina/2){canRun = true;}
            }
            playerController.SimpleMove(movementeAmount * walkingVelocity);
        }
        
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

    public static void CanMove(bool state){
        canMove = state;
    }
}
