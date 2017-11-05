using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemiga : MonoBehaviour {


    public GameObject[] Enemigos;
    public float TiempoDeSpawn = 3f;
    public Transform[] PuntoDeSpawn;
    public float puntuacion = 50f;

    

    // Use this for initialization
    void Start () {

        InvokeRepeating("Spawn", TiempoDeSpawn, TiempoDeSpawn);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {

        if (puntuacion < 50)
        {
         
            int spawnPointIndex = Random.Range(0, PuntoDeSpawn.Length);

        Instantiate(Enemigos[0], PuntoDeSpawn[spawnPointIndex].position, PuntoDeSpawn[spawnPointIndex].rotation);
           

         
        }

        if (puntuacion < 100 && puntuacion > 50)
        {

            int spawnPointIndex = Random.Range(0, PuntoDeSpawn.Length);

            Instantiate(Enemigos[Random.Range(0, 2)], PuntoDeSpawn[spawnPointIndex].position, PuntoDeSpawn[spawnPointIndex].rotation);

        }


        if (puntuacion > 100)
        {

            int spawnPointIndex = Random.Range(0, PuntoDeSpawn.Length);

            Instantiate(Enemigos[Random.Range(0, 3)], PuntoDeSpawn[spawnPointIndex].position, PuntoDeSpawn[spawnPointIndex].rotation);

        }


    }



}

