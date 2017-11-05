using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosInteractuables : MonoBehaviour
{

    
    public float CantidadReparacion = 50f;
    public float DañoVeneno = 150f;


    // Use this for initialization
    void Start()
    {

      

    }

    // Update is called once per frame
    void Update()
    {

        if (CompareTag("Reparacion"))
        {
            
            transform.Rotate(new Vector3(0f, 80f, 0) * Time.deltaTime);


        }

        if (CompareTag("Veneno"))
        {

            transform.Rotate(new Vector3(0f, -80f, 0f) * Time.deltaTime);


        }

    }


    void OnTriggerEnter(Collider colision)
    {
        if (gameObject.CompareTag("Reparacion")){
            if (colision.CompareTag("Jugador"))
            {
                
                Jugador.SaludJugadorStatic += CantidadReparacion;
                print(Jugador.SaludJugadorStatic);
                Jugador.BarraDeVidaStatic.value = Jugador.SaludJugadorStatic;
                GetComponent<Renderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;

                StartCoroutine(SpawnReparacion(8));
            }
        }

        if (gameObject.CompareTag("Veneno"))
        {
            if (colision.CompareTag("Jugador"))
            {
         
                
                Jugador.SaludJugadorStatic -= DañoVeneno;
                print(Jugador.SaludJugadorStatic);
                Jugador.BarraDeVidaStatic.value = Jugador.SaludJugadorStatic;
                GetComponent<Renderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;

                StartCoroutine(SpawnVeneno(2));
            }
        }


    }

    IEnumerator SpawnReparacion(float time)
    {

        yield return new WaitForSeconds(time);

          GetComponent<Renderer>().enabled = true;
          GetComponent<BoxCollider>().enabled = true;


        }

    IEnumerator SpawnVeneno(float time)
    {

        yield return new WaitForSeconds(time);
        
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;


    }

}
