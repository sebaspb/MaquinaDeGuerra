using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosInteractuables : MonoBehaviour {

	[Header("<OPCIONES DE INTERACTUABLES>")]
	[Tooltip("Cantidad de vida que recuperá el objeto de recuperación")]
	public float CantidadReparacion = 50f;
	[Tooltip("Cantidad de vida que quitará el objeto de daño")]
	public float CantidadDaño = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (CompareTag ("Reparacion")) 
		{
		
			transform.Rotate (new Vector3 (0f, 45f, 45f) * Time.deltaTime);
		
		}
		if (CompareTag ("Daño")) 
		{

			transform.Rotate (new Vector3 (0f, 80f, 0f) * Time.deltaTime);

		}



	}

	void OnTriggerEnter(Collider colision)
	{
	
		if (gameObject.CompareTag ("Reparacion")) {

			if (colision.CompareTag ("Jugador")) {

				Jugador.SaludJugadorStatic += CantidadReparacion;
				print (Jugador.SaludJugadorStatic);
				Jugador.BarraDeVidaStatic.value = Jugador.SaludJugadorStatic;
				GetComponent<Renderer> ().enabled = false;
				GetComponent<BoxCollider> ().enabled = false;
                GetComponent<Light>().enabled = false;
				StartCoroutine (SpawnReparacion (8));
			}

		}

		if (gameObject.CompareTag ("Daño")) {

			if (colision.CompareTag ("Jugador")) {

				Jugador.SaludJugadorStatic -= CantidadDaño;
				print (Jugador.SaludJugadorStatic);
				Jugador.BarraDeVidaStatic.value = Jugador.SaludJugadorStatic;
				GetComponent<Renderer> ().enabled = false;
				GetComponent<BoxCollider> ().enabled = false;
				StartCoroutine (SpawnReparacion (2));
			}

		}
	
	}

	IEnumerator SpawnReparacion(float time)
	{

		yield return new WaitForSeconds (time);
		GetComponent<Renderer> ().enabled = true;
		GetComponent<BoxCollider> ().enabled = true;
        GetComponent<Light>().enabled = true;
    }

	IEnumerator SpawnDaño(float time)
	{

		yield return new WaitForSeconds (time);
		GetComponent<Renderer> ().enabled = true;
		GetComponent<BoxCollider> ().enabled = true;

	}


}
