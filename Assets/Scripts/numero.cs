using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numero : MonoBehaviour
{
    private float _vel;

    public Sprite[] spritesNumerosPossibles = new Sprite[10];

    private int valorNumero;

    [SerializeField]
    private GameObject prefabExplosio;


    private Vector2 minPantalla;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 5f;

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));

        System.Random aleatori = new System.Random();
        valorNumero = aleatori.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = spritesNumerosPossibles[valorNumero];
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos += new Vector2(0, -1) * _vel * Time.deltaTime;
        transform.position = novaPos;

        if(transform.position.y < minPantalla.y)
        {
            DadesGlobals.punts += -valorNumero;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "ProjectilJugador" || objecteTocat.tag == "NauJugador")
        {
            GameObject explosio = Instantiate(prefabExplosio);
            explosio.transform.position = transform.position;
            DadesGlobals.punts += +valorNumero;
            Destroy(gameObject);
        }
    }
}
