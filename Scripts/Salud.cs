using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour {

 public static bool  SaludActivada=true;
 public static bool VenenoActivado = true;

    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {




        if (CompareTag("Salud")) {

            transform.Rotate(new Vector3(0f, 80f, 0f) * Time.deltaTime);
           
           
            }

             



        if (CompareTag("Veneno")) {

            transform.Rotate(new Vector3(0f, -80f, 0f) * Time.deltaTime);
        }




       

    }
}

  


