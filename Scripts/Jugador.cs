using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.Xml;
using System.IO;


public class Jugador : MonoBehaviour {
    
	//Inicializa el menu del jugador para todos los objetos que tengan asignada ésta clase.

	[Header("<OPCIONES DE MOVIMIENTO>")]
	[Tooltip("Velocidad con la cual se moverá el jugador hacia los lados, adelante y atras; valor por defecto 5")]
	public float VelocidadMovimiento = 5f;

	[Tooltip("Velocidad con la cual el jugador girará sobre si mismo; valor por defecto 100")]
	public float VelocidadRotacion = 100f;

	[Tooltip("Impulso con el cual saltará el jugador; 0 para desactivar el salto")]
	public float Impulso = 5f;

	[Tooltip("Comprueba constantemente si el jugador está en contacto con el piso")]
	public bool EstaEnElPiso = false;

	[Tooltip("Asigna el rigidbody del jugador que se usa para la función salto")]
	public Rigidbody CuerpoRigidoJugador;

	[Header("<OPCIONES DE SALUD Y BARRA DE VIDA>")]

	[Tooltip("Salud del jugador, por defecto 500")]
	public float SaludJugador = 500f;
	public static float SaludJugadorStatic;

	[Tooltip("Slider barra de vida jugador ")]
	public Slider BarraDeVida;
	public static Slider BarraDeVidaStatic;

	[Header("<OPCIONES DE DISPARO>")]
	[Tooltip("El prefab que se asignará como bala")]
	public GameObject Bala;
    public GameObject Bala2;

    [Tooltip("El objeto que se usará como emisor de balas")]
	public GameObject EmisorDeBalas;
    public GameObject EmisorDeBalas2;

    [Tooltip("Fuerza con la cual se disparará la bala")]
	public float FuerzaBala;
    public float FuerzaBala2;

    public Transform scoreText;
    public int puntuacion = 100;
    public static float puntuacionstatic;

    public static int highScore;
    float playerScore;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    public ParticleSystem lanzallamas;
    public Transform cañon;
    public AudioSource minigun;
    public AudioSource audiocañon;
    public AudioSource lanzallamassonido;
    public AudioSource motorjugador;
    public AudioSource iniciomotor;
    public AudioSource impactobala;
    public static bool balaexiste = false;
    // Use this for initialization
    void Start () {

		BarraDeVida.maxValue = SaludJugador;
		BarraDeVida.value = SaludJugador;
		SaludJugadorStatic = SaludJugador;
		BarraDeVidaStatic = BarraDeVida;
        puntuacionstatic = puntuacion;

        iniciomotor.Play();

  
            motorjugador.Play();
        


    }


    // Update is called once per frame
    void Update () {

        print("bala existe "+balaexiste);

        playerScore = PlayerPrefs.GetFloat("Player Score");

        print("RECORD " + playerScore);

        if (puntuacionstatic > playerScore)
        {
            
            PlayerPrefs.SetFloat("Player Score", puntuacionstatic);
            print("HAS REGISTRADO UN NUEVO RECORD");
            
          
        }
        if (!iniciomotor.isPlaying)
        {
            MovimientoJugador();
            DisparoJugador();
        }
       
        scoreText.GetComponent<Text>().text = puntuacionstatic.ToString();
        
    }

	void FixedUpdate () {

		SaltoJugador();

	}


	//Inicia la función movimiento del jugador
	public void MovimientoJugador()
	{

    

        float Movimiento = Input.GetAxis ("Vertical") * VelocidadMovimiento;
		Movimiento *= Time.deltaTime;
		transform.Translate (0, 0, Movimiento);

		float Rotacion = Input.GetAxis ("Horizontal") * VelocidadRotacion;
		Rotacion *= Time.deltaTime;
		transform.Rotate (0, Rotacion, 0);
        


    } 

	public void SaltoJugador()
	{

		CuerpoRigidoJugador = GetComponent<Rigidbody>();

		if (Input.GetButtonDown("Jump") && EstaEnElPiso == true)
		{

			CuerpoRigidoJugador.AddForce (0, Impulso, 0,ForceMode.Impulse);

		}
	}

    public void DisparoJugador()
    {
        if (InterfazMenu.IsInputEnabled)
        {
            
            if (Input.GetButtonDown("Fire1")){
                if (!balaexiste) { 
            
                
                    audiocañon.Play();
                        balaexiste = true;
                GameObject ControladorBala;
                ControladorBala = Instantiate(Bala, EmisorDeBalas.transform.position, EmisorDeBalas.transform.rotation) as GameObject;

                ControladorBala.transform.Rotate(Vector3.left * 90);

                Rigidbody CuerpoRigidoTemporal;
                CuerpoRigidoTemporal = ControladorBala.GetComponent<Rigidbody>();

                CuerpoRigidoTemporal.AddForce(cañon.transform.forward * FuerzaBala);

                Destroy(ControladorBala, 3f);
                    StartCoroutine(cambiarexistenciabala(1.5f));  
                    
                        
            }
                }


            myTime = myTime + Time.deltaTime;

      

            if (Input.GetButton("Fire2") && myTime > nextFire)
            {

                if (!minigun.isPlaying)
                {
                    minigun.Play();
                }
               
                nextFire = myTime + fireDelta;
                GameObject ControladorBala2;
                ControladorBala2 = Instantiate(Bala2, EmisorDeBalas2.transform.position, EmisorDeBalas2.transform.rotation) as GameObject;

      

                ControladorBala2.transform.Rotate(Vector3.left * 90);

                Rigidbody CuerpoRigidoTemporal2;
                CuerpoRigidoTemporal2 = ControladorBala2.GetComponent<Rigidbody>();

                CuerpoRigidoTemporal2.AddForce(cañon.transform.forward * FuerzaBala2);

                Destroy(ControladorBala2, 3f);
                nextFire = nextFire - myTime;
                myTime = 0.0F;

            

            }

            if (Input.GetButtonUp("Fire2"))
            {
                minigun.Stop();

            }

            if (Input.GetButton("Fire3"))
            {
                if (!lanzallamassonido.isPlaying)
                {
                    lanzallamassonido.Play();
                }
                lanzallamas.Play();

            }

            if (Input.GetButtonUp("Fire3"))
            {
                StartCoroutine(sonidolanzallamas(1.8f));
                lanzallamas.Stop();

            }

        }

    }
    IEnumerator cambiarexistenciabala(float time)
    {
        yield return new WaitForSeconds(time);

        balaexiste = false;
    }

    IEnumerator sonidolanzallamas(float time)
    {
        yield return new WaitForSeconds(time);

        lanzallamassonido.Stop();
    }
    void OnCollisionEnter(Collision collisionbala)
	{
		if (collisionbala.gameObject.name=="BalaEnemigo(Clone)") {

			SaludJugadorStatic -= Enemigos.dañocausadostatic;
			BarraDeVida.value = SaludJugadorStatic;
            if (!impactobala.isPlaying)
            {
                impactobala.Play();
            }
           
		Debug.Log (SaludJugadorStatic);


		}
	}


    void OnCollisionStay()
	{
		if (gameObject.CompareTag ("Jugador")) {


			EstaEnElPiso = true;
			Debug.Log ("Tocando el piso =" + EstaEnElPiso);

		}




	}




    void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag ("Piso")) {


			EstaEnElPiso = false;
			Debug.Log ("Tocando el piso =" + EstaEnElPiso);
		}
	}

}
