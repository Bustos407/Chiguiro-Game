using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitEnemigo : MonoBehaviour
{
    public ChiguiroMovimiento cm;

 

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("ChiguiroPlayer"))
        {
          
            
               print("aychhhhhh" + cm.vida);

                cm.vida -= 1;


            
           


        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (cm.vida <= 2)
        {
            Destroy(cm.Corazon3);
        }
        if (cm.vida <= 1)
        {
            Destroy(cm.Corazon2);
        }
        if (cm.vida <= 0)
        {
            Destroy(cm.Corazon1);
            Destroy(cm.gameObject);
        }
    }
}
