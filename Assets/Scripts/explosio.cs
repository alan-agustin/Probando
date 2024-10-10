using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosio : MonoBehaviour
{


    // Start is called before the first frame update

    void Start()
    {
        Invoke("DestrueixExplosio", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private void DestrueixExplosio()
    {
        Destroy(gameObject);
    }
}
