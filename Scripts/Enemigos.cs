using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour {

    [Header("<OPCIONES DE OBJETIVO>")]
    [Tooltip("El objetivo al cual seguirá éste enemigo")]
    public Transform jugador;
    [Header("<OPCIONES DE MOVIMIENTO>")]
    [Tooltip("Velocidad a la cual se moverá el enemigo, valor por defecto 4")]
    public float VelocidadEnemigo = 4f;
    [Tooltip("Distancia minima a la cual puede estar el enemigo de el objetivo, valor por defecto 2")]
    public float DistanciaMinima = 2f;
    [Header("<OPCIONES DE SALUD>")]
    [Tooltip("Salud del enemigo, valor por defecto 150")]
    public float SaludEnemigo = 150f;
    [Header("<OPCIONES DE DISPARO>")]
    [Tooltip("Bool privado que indica si el enemigo está atacando o no")]
    bool EstaAtacando;
    [Tooltip("Tiempo que transcurre hasta el siguiente disparo")]
    public float SiguienteDisparo;
    [Tooltip("Cadencia de disparo")]
    public float Cadencia;
    [Tooltip("Prefab usado como bala por el enemigo")]
    public GameObject Bala;
    [Tooltip("Emisor de Bala")]
    public GameObject EmisorDeBalas;
    [Tooltip("Fuerza de balas enemigas")]
    public float FuerzaBala;

    public float dañocausado;
    public static float dañocausadostatic;

    public bool EstaEnSpawn = true;
    public float puntos;

    public Renderer orugas;
    public float velocidadscrollorugas;
    public AudioSource disparo;
    public AudioSource motor;
    // Use this for initialization
    void Start() {

       //jugador = GameObject.Find("Jugador").transform;
        dañocausadostatic = dañocausado;

        if (!motor.isPlaying)
        {
            motor.Play();
        }
    }

    // Update is called once per frame
    void Update() {
        print(SaludEnemigo);
        if (EstaEnSpawn)
        {
            float Movimiento = VelocidadEnemigo * Time.deltaTime;
            transform.Translate(new Vector3(0f, 0f, VelocidadEnemigo) * Time.deltaTime);
            movimientoOrugas();


        }

        if (!EstaEnSpawn)
        {
            
            var targetRotation = Quaternion.LookRotation(jugador.gameObject.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
            
           
        
            //transform.LookAt(Jugador);

            float Distancia = Vector3.Distance(jugador.position, transform.position);
        
        if (Distancia > DistanciaMinima) {

           
                movimientoOrugas();

            }

        if (Distancia <= DistanciaMinima) {

            EstaAtacando = true;
                transform.position = Vector3.MoveTowards(transform.position, jugador.position, 0);

            } else {


            EstaAtacando = false;


        }

        Atacando();

        if (SaludEnemigo <= 0) {

                Jugador.puntuacionstatic += puntos;
            Destroy(gameObject);

        }
        }

    }

    public void movimientoOrugas()
    {
        float Movimiento = VelocidadEnemigo * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, jugador.position, Movimiento);
        float offset = Time.time * velocidadscrollorugas;
        orugas.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));

    }

    public void Atacando() {

        if (EstaAtacando == true) {


            if (Time.time > SiguienteDisparo) {

              
                    disparo.Play();
               

                SiguienteDisparo = Time.time + Cadencia;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BalaJugador(Clone)") {

            SaludEnemigo -= 50;

            Debug.Log("SaludEnemigo = " + SaludEnemigo);


        }

        if (collision.gameObject.name == "BalaJugador2(Clone)")
        {

            SaludEnemigo -= 10;

            Debug.Log("SaludEnemigo = " + SaludEnemigo);


        }

    



    }

    void OnParticleCollision(GameObject Jugador)
    {

        SaludEnemigo -= 10;
        print("lanzallamas" + SaludEnemigo);

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject)
            {

            EstaEnSpawn = false;


        }
    }
}