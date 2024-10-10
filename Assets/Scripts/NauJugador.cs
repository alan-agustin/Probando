using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NauJugador : MonoBehaviour
{
    private float _vel;
    Vector2 minPantalla, maxPantalla;
    
    [SerializeField]
    private GameObject prefabProjectil;

    [SerializeField]
    private GameObject prefabExplosio;

    private int videsJugador;

    [SerializeField]
    private TMPro.TextMeshProUGUI uiVidesJugador;



    void Start()
    {
        _vel = 20;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //limite inferior
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //limite superior

        float midaMeitatImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float midaMeitatImatgeY = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        //minPantalla.x = minPantalla.x + 1.3f;
        //minPantalla.x += 1.3f; hace lo mismo que la de arriba
        //minPantalla.x +=
        //maxPantalla.x -= GetComponent<SpriteRenderer>().bounds.size.x / 2;
        //minPantalla.y += GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //maxPantalla.y -= GetComponent<SpriteRenderer>().bounds.size.y / 2; 

        minPantalla.x += midaMeitatImatgeX;
        maxPantalla.x -= midaMeitatImatgeX;
        minPantalla.y += midaMeitatImatgeY;
        maxPantalla.y -= midaMeitatImatgeY;

        videsJugador = 3;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();
        DisparaProjectil();

    }
    private void MovimentNau()
    {
     float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
    float direccioIndicadaY = Input.GetAxisRaw("Vertical");
    //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);

    Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

    Vector2 novaPos = transform.position;
    novaPos = novaPos + direccioIndicada* _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);
       
        transform.position = novaPos; //tres lineas que hacen que la variable posicion la guardamos en nova, y luego al igualar hacemos que la posicion cambie.
        }
   
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            videsJugador--;
            uiVidesJugador.text = "vides: " + videsJugador.ToString();
            if (videsJugador <= 0)
            {
                GameObject explosio = Instantiate(prefabExplosio);
                explosio.transform.position = transform.position;
                SceneManager.LoadScene("pantallaResultats");
                Destroy(gameObject);
            }
        }
    }


    private void DisparaProjectil() 
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject projectil = Instantiate(prefabProjectil);
            projectil.transform.position = transform.position;
        }

    }
}
