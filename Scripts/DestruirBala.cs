using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBala : MonoBehaviour
{
    public ParticleSystem balajugador;
    public AudioSource explosion;
    // Use this for initialization
    void Start()
    {
        balajugador.Pause();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision colision)
    {

       
        {

            var sonido = Instantiate(explosion, transform.position, Quaternion.identity) as AudioSource;
                        sonido.Play();

            var exp = Instantiate(balajugador, transform.position, Quaternion.identity) as ParticleSystem;
            exp.loop = false;

            

           
            Destroy(sonido.gameObject, exp.duration);
            Destroy(exp.gameObject, exp.duration);
            Destroy(gameObject);

          




            print("Bala destruida");

        }

    }
}
