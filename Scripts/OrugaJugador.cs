using UnityEngine;
using System.Collections;

public class OrugaJugador : MonoBehaviour {
    public float scrollSpeed = 0.5F;
    public Renderer rend;
    void Start() {
        rend = GetComponent<Renderer>();
    }

    void Update() {



        float Movimiento = Input.GetAxis("Vertical");

            if (Movimiento > 0) { 
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
        if (Movimiento < 0)
        {
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
        }
    }
}