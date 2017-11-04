using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancias : MonoBehaviour {

	public GameObject EmisorDeBalas;

	public GameObject Bala;

	public float FuerzaBala;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Fire1")) {
		
			GameObject ControladorBala;
			ControladorBala = Instantiate (Bala, EmisorDeBalas.transform.position, EmisorDeBalas.transform.rotation)as GameObject;
		
			ControladorBala.transform.Rotate (Vector3.left * 90);

			Rigidbody CuerpoRigidoTemporal;
			CuerpoRigidoTemporal = ControladorBala.GetComponent<Rigidbody>();

			CuerpoRigidoTemporal.AddForce (transform.forward * FuerzaBala); 

			Destroy (ControladorBala, 3f);


		}


	}
}
