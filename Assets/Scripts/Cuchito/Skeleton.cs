using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    int rutine;
    float cronometro;
    Animator ani;
    Quaternion angle;
    float grado;
    public float walk_velocity;
    public float run_velocity;
    public float agro_area = 2;
    //public FieldOfView script_FieldOfView;
    //bool playerSeen;

    //agro
    public GameObject target;
    bool attacking = false;


    void CuchitoBehaviour()
    {
        if (WawitaDetected() )
        {
            
            if (DistanceToWawita() > 1 && !attacking)
            {
                CuchitoChase();
            }
            else 
            {
                CuchitoAttack();
            }
        }
        else
        {
            CuchitoIdle();
        }
        /*if(playerSeen)
        {
            print("te veo");
        }*/
    }
    bool WawitaDetected()
    {
        if (DistanceToWawita() <= agro_area)
        {
            return true;
        }
        return false;
    }
    void CuchitoIdle()
    {
        attacking = false;
        ani.SetBool("attack", false);
        ani.SetBool("walk", false);
        ani.SetBool("run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 3)
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
                //walking idle
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f); //rotate
                transform.Translate(Vector3.forward * walk_velocity * Time.deltaTime);//velocity and move forward
                ani.SetBool("walk", true);
                break;
        }
    }
    
    void CuchitoChase()
    {
        RotateToWawita();
        ani.SetBool("walk", false);
        ani.SetBool("run", true);
        ani.SetBool("attack", false);
        attacking = false;
        transform.Translate(Vector3.forward * run_velocity * Time.deltaTime);
    }
    void CuchitoAttack()
    {
        RotateToWawita();
        ani.SetBool("walk", false);
        ani.SetBool("run", false);
        ani.SetBool("attack", true);
        attacking = true;
        /*if (DistanceToWawita() > 1)
        {
            attacking = false;
        }
        else
        {
            attacking = true;
        }*/
    }

    float DistanceToWawita()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    void RotateToWawita()
    {
        //mirar al wawita
        var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
    }
    public void CancelAttackAnimation()
    {
        ani.SetBool("attack", false);
        attacking = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        //script_FieldOfView = GetComponent<FieldOfView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerSeen = script_FieldOfView.canSeePlayer;
        CuchitoBehaviour();

    }
}
