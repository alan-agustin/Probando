using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;

    // Start is called before the first frame update

    Vector2 minPantalla, maxPantalla;
    void Start()
    {
        _vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //limite inferior
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //limite superior

        minPantalla.x = minPantalla.x + 1.3f;
        maxPantalla.x = maxPantalla.x - 1.3f;
        minPantalla.y = minPantalla.y + 1.3f;
        maxPantalla.y = maxPantalla.y - 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);

        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x,maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y,maxPantalla.y);
       
        transform.position = novaPos; //tres lineas que hacen que la variable posicion la guardamos en nova, y luego al igualar hacemos que la posicion cambie.
    }
}
