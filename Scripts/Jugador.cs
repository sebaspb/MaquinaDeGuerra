using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jugador : MonoBehaviour {

    




    //Inicializa el menú de las opciones del jugador en todos los objetos que tengan asignados éste Script
    [Header("<Opciones de Movimiento>")]
        [Tooltip("Velocidad con la cual se moverá el jugador de manera vertica y/o horizontal")]
        public float VelocidadMovimiento=5f;

        [Tooltip("Velocidad con la cual el jugador girará sobre si mismo")]
        public float VelocidadRotacion = 100f;

        [Tooltip("Impulso con el cual saltará el jugador 0 para desactivar el salto")]
        public float Impulso = 5f;

        [Tooltip("Comprueba constantemente si el jugador se encuentra en contacto con el piso")]
        public bool EstaEnElPiso = false;

        [Tooltip("Asignar el 'Rigidbody' del jugador, se usa para la función salto")]
        public Rigidbody CuerpoRigidoJugador;
        

        [Tooltip("Salud del jugador")]
        public float SaludJugador = 500f;
        public static float SaludJugadorStatic;

        public Slider BarraDeVida;
        public static Slider BarraDeVidaStatic;

        public GameObject Bala;
        public GameObject EmisorDeBalas;
        public float FuerzaBala;



    //
    void Start () {

        BarraDeVida.maxValue = SaludJugador;
        BarraDeVida.value = BarraDeVida.maxValue;
        SaludJugadorStatic= SaludJugador;
        BarraDeVidaStatic = BarraDeVida;
    }
	
	// Update se llama una vez por cuadro
	void Update () {

        //Invoca la función de movimiento del jugador (ver abajo)
        MovimientoJugador();
        DisparoJugador();
        
     }

    //FixedUpdate se llama cada cierto tiempo o cada vez que 'algo' suceda.
    void FixedUpdate()
    {
        //Invoca la función de salto del jugador (ver abajo)
        SaltoJugador();

    }

    //Inicia la función movimiento del jugador
    public void MovimientoJugador()
    {

        float Movimiento = Input.GetAxis("Vertical") * VelocidadMovimiento;
        float Rotacion = Input.GetAxis("Horizontal") * VelocidadRotacion;

        Movimiento *= Time.deltaTime;
        Rotacion *= Time.deltaTime;

        transform.Translate(0, 0, Movimiento);
        transform.Rotate(0, Rotacion, 0);

    }

    //Inicia la función salto del jugador
    public void SaltoJugador()
    {

        CuerpoRigidoJugador = GetComponent<Rigidbody>();
        if (Input.GetButtonDown("Jump") && EstaEnElPiso == true)
        {
            CuerpoRigidoJugador.AddForce(0, Impulso, 0, ForceMode.Impulse);

                    }

        

    }


    public void DisparoJugador()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            GameObject ControladorBala;
            ControladorBala = Instantiate(Bala, EmisorDeBalas.transform.position, EmisorDeBalas.transform.rotation) as GameObject;

            ControladorBala.transform.Rotate(Vector3.left * 90);

            Rigidbody CuerpoRigidoTemporal;
            CuerpoRigidoTemporal = ControladorBala.GetComponent<Rigidbody>();

            CuerpoRigidoTemporal.AddForce(transform.forward * FuerzaBala);

            Destroy(ControladorBala, 3f);



        }
    }


    //Inicia la función que comprueba si el Jugador está en colisión o no
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Piso"))
        {
            EstaEnElPiso = true;
            Debug.Log("Tocando el piso = " + EstaEnElPiso);
        }

   

    }



    //Inicia la función que se activa cuando el jugador deja de estar en colisión
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Piso"))
        {
            EstaEnElPiso = false;
            Debug.Log("Tocando el piso = " + EstaEnElPiso);
        }
    }


   

}

