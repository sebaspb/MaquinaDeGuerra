using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfazMenu : MonoBehaviour {

    public static bool IsInputEnabled = true;
    public GameObject CanvasMenu;
    public GameObject BotonPausa;
    public GameObject TextoPausa;
    
    public GameObject CanvasInstrucciones;
    public GameObject CanvasOpciones;
    public GameObject CanvasCreditos;
    public GameObject BtnJugar;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

  public void Pausa()
    {

        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            IsInputEnabled = false;
            CanvasMenu.gameObject.SetActive(true);
            TextoPausa.GetComponent<Text>().text = "CONTINUAR";
           
            BotonPausa.GetComponent<Button>().enabled = false;
            BotonPausa.GetComponent<Button>().enabled = true;
            PlayerPrefs.DeleteAll();
        }
        else
        {
            Time.timeScale = 1.0f;
            IsInputEnabled = true;
            CanvasMenu.gameObject.SetActive(false);
            TextoPausa.GetComponent<Text>().text = "MENU/PAUSA";
            BotonPausa.GetComponent<Button>().enabled = false;
            BotonPausa.GetComponent<Button>().enabled = true;
        }

    }

    public void ActivarInstrucciones() {
        
        CanvasInstrucciones.gameObject.SetActive(true);



    }

    public void DesactivarInstrucciones()
    {

        CanvasInstrucciones.gameObject.SetActive(false);



    }

    public void ActivarOpciones()
    {

        CanvasOpciones.gameObject.SetActive(true);



    }

    public void DesactivarOpciones()
    {

        CanvasOpciones.gameObject.SetActive(false);



    }

    public void ActivarCreditos()
    {

        CanvasCreditos.gameObject.SetActive(true);



    }

    public void DesactivarCreditos()
    {

        CanvasCreditos.gameObject.SetActive(false);



    }

    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
        
    }
  


        
    public void Salir()
    {

        Application.Quit();
    }
}
