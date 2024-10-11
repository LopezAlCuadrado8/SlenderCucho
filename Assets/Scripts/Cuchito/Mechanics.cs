using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public int rutine;
    public float cronometro;
    Animator ani;
    public Quaternion angle;
    public float grado;

    //agro
    public GameObject target;


    public void CuchitoBehaviour()
    {
        if (WawitaDetected())
        {
            
            CuchitoAgressive();
        }
        else
        {
            CuchitoIdle();
        }
        
    }
    bool WawitaDetected()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= 3)
        {
            return true;
        }
        else { return false; }
    }
    void CuchitoIdle()
    {
        ani.SetBool("run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutine = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutine)
        {
            case 0:
                ani.SetBool("walk", false);
                break;
            case 1:
                grado = Random.Range(0, 360);
                angle = Quaternion.Euler(0, grado, 0);
                rutine++;
                break;
            case 2:

                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f); //rotacion
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);//movimiento y velocidad hacia adelante
                ani.SetBool("walk", true);
                break;
        }
    }
    
    void CuchitoAgressive()
    {
        var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
        ani.SetBool("walk", false);
        ani.SetBool("run", true);
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CuchitoBehaviour();
    }
}
