using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{

    
    private void OnColliderEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("ChiguiroPlayer"))
        {
            
            print("Daño");

            

        }


    }
    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
