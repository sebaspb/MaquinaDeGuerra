using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{

    Transform Jugador;
    public float Velocidad;
    public float Distancia;
    bool IsAttacking;
    public  float nextFire;
    public float fireRate;
    public GameObject Bala;
    public GameObject EmisorDeBalas;
    public float FuerzaBala;
   



    // Use this for initialization
    void Start()
    {

        Jugador = GameObject.Find("Jugador").transform;
       


    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("atacando"+IsAttacking);

        transform.LookAt(Jugador);

        float Distancia = Vector3.Distance(Jugador.position, transform.position);


        if (Distancia > this.Distancia)
        {

            float Movimiento = Velocidad * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, Jugador.position, Movimiento);



        }

        if (Distancia < 50)
        {


            IsAttacking = true;
        }
        else
        {
            IsAttacking = false;
        }

        Attacking();
    }

    public void Attacking()
    {
        if (IsAttacking == true)
        {


            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                GameObject ControladorBalas;
                ControladorBalas = Instantiate(Bala, EmisorDeBalas.transform.position, EmisorDeBalas.transform.rotation) as GameObject;

                ControladorBalas.transform.Rotate(Vector3.left * 90);

                Rigidbody CuerpoRigidoTemporal;
                CuerpoRigidoTemporal = ControladorBalas.GetComponent<Rigidbody>();

                CuerpoRigidoTemporal.AddForce(transform.forward * FuerzaBala);

                Destroy(ControladorBalas, 3f);
                

            }
        }
    }




}





