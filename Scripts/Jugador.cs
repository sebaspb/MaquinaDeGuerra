using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

	public float Velocidad = 5f;
	public float VelocidadRotacion = 100f;
	public float Impulso = 5f;
	public float SaludJugador = 500f;
	public float Curacion = 50f;
	public float Veneno = 50f;
	public Slider BarraDeVida;
	public Rigidbody CuerpoRigidoJugador;


	// Use this for initialization
	void Start () {

        CuerpoRigidoJugador = GetComponent<Rigidbody> ();

  
    }
	
	// Update is called once per frame
	void Update () {



		float Movimiento = Input.GetAxis ("Vertical") * Velocidad;
		float Rotacion = Input.GetAxis ("Horizontal") * VelocidadRotacion;

		Movimiento *= Time.deltaTime;
		Rotacion *= Time.deltaTime;

		transform.Translate(0,0,Movimiento);	
		transform.Rotate (0, Rotacion,0);



	}

	public bool EstaEnElPiso = false;

	void FixedUpdate ()
	{
		if (Input.GetButtonDown ("Jump") && EstaEnElPiso == true)
		{
			CuerpoRigidoJugador.AddForce (0, Impulso, 0, ForceMode.Impulse);
		}
			
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.CompareTag ("Piso"))
		{
			EstaEnElPiso = true;
			Debug.Log ("Tocando el piso = " + EstaEnElPiso);
		}




	}
 

   

    void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag ("Piso")) {
			EstaEnElPiso = false;
			Debug.Log ("Tocando el piso = " + EstaEnElPiso);
		}
	}



    IEnumerator MostrarSalud(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Salud");
        foreach (GameObject go in gameObjectArray)
        {

            go.GetComponent<Renderer>().enabled = true;
            go.GetComponent<BoxCollider>().enabled = true;

        }

    }

    IEnumerator MostrarVeneno(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Veneno");
        foreach (GameObject go in gameObjectArray)
        {

            go.GetComponent<Renderer>().enabled = true;
            go.GetComponent<BoxCollider>().enabled = true;


        }
    }

   
        

        void OnTriggerEnter (Collider colision){
		if (colision.CompareTag ("Salud")) {
			SaludJugador += Curacion;
			Debug.Log (SaludJugador);
			BarraDeVida.value = SaludJugador;
            Salud.SaludActivada = false;

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Salud");
            foreach (GameObject go in gameObjectArray)
            {

                go.GetComponent<Renderer>().enabled = false;
                go.GetComponent<BoxCollider>().enabled = false;

            }

            StartCoroutine(MostrarSalud(8));

    

       
        }

        if (colision.CompareTag ("Veneno")) {
			SaludJugador -= Veneno;
			Debug.Log (SaludJugador);
			BarraDeVida.value = SaludJugador;

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Veneno");
            foreach (GameObject go in gameObjectArray)
            {

                go.GetComponent<Renderer>().enabled = false;
                go.GetComponent<BoxCollider>().enabled = false;


            }

            StartCoroutine(MostrarVeneno(4));
        }
        }
	}






		