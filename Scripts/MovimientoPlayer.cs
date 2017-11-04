using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPlayer : MonoBehaviour
{

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float thrust = 5.0f;
    public Rigidbody rb;
    public int totalsalud;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

    void FixedUpdate()
    {
      
        if (Input.GetButtonDown("Jump") && EstaEnElPiso == true)
        {
            rb.AddForce(0, thrust, 0, ForceMode.Impulse);
        }
    }

    public bool EstaEnElPiso = false;

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("terreno"))
        {

            EstaEnElPiso = true;
            Debug.Log("Tocando el piso " + EstaEnElPiso);
        }
    }

    void OnCollisionExit(Collision cosito)
    {

        EstaEnElPiso = false;
        print("No longer in contact with " + EstaEnElPiso);
    }
}


