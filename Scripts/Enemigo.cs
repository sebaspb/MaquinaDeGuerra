using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

	public Transform Jugador;
	public float Velocidad;
	public float DistanciaEnemigo;


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		
		transform.LookAt (Jugador);

		float Distancia = Vector3.Distance (Jugador.position, transform.position);


		if (Distancia > DistanciaEnemigo)
		{

			float Movimiento = Velocidad * Time.deltaTime;

			transform.position = Vector3.MoveTowards (transform.position, Jugador.position, Movimiento);


		}


	}
}
