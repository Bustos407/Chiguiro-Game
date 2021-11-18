using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMGLose : MonoBehaviour
{

    public Image lose;
    public ChiguiroMovimiento cm;
    // Start is called before the first frame update
    void Start()
    {
        lose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cm.vida <= 0)
        {

            lose.gameObject.SetActive(true);
        }

    }
}
