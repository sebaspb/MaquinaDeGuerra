using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemiga : MonoBehaviour {

	[Header("<OPCIONES DE ENEMIGOS>")]
	[Tooltip("Arreglo que almacena la lista de enemigos")]
	public GameObject[] Enemigos;
	[Tooltip("Segundos que transcurren entre cada spawn")]
	public float TiempoDeSpawn = 3f;
	[Tooltip("Arreglo que contiene los distintos puntos de spawn")]
	public Transform[] PuntosDeSpawn;


	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", TiempoDeSpawn, TiempoDeSpawn);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn()
	{
        if (Jugador.puntuacionstatic >= 0 && Jugador.puntuacionstatic < 250)
        {

            int NumeroPuntoSpawn = Random.Range(0, 1);
            Instantiate(Enemigos[0], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);


        }

        if (Jugador.puntuacionstatic >=250  && Jugador.puntuacionstatic < 350)
        {

            int NumeroPuntoSpawn = Random.Range(0, 2);
            Instantiate(Enemigos[Random.Range(0, 2)], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);


        }

        if (Jugador.puntuacionstatic >= 350 && Jugador.puntuacionstatic < 500)
        {

            int NumeroPuntoSpawn = Random.Range(0, 2);
            Instantiate(Enemigos[Random.Range(0, 3)], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);


        }

        if (Jugador.puntuacionstatic >= 500 && Jugador.puntuacionstatic < 750)
        {

            int NumeroPuntoSpawn = Random.Range(2, 4);
            Instantiate(Enemigos[Random.Range(0, 4)], PuntosDeSpawn[NumeroPuntoSpawn].position, PuntosDeSpawn[NumeroPuntoSpawn].rotation);


        }

    }
    }
