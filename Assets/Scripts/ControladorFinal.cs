using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorFinal : MonoBehaviour
{
    
    public GameObject controlador_ganar;
    public Button ReintentarWin;
    public Button VolverMenu;
    // Start is called before the first frame update
    void Start()
    {
        controlador_ganar.gameObject.SetActive(false);
        Button ReinterBtn = ReintentarWin.GetComponent<Button>();
        ReinterBtn.onClick.AddListener(VolverJugar);

        Button VolverMenuBtn = VolverMenu.GetComponent<Button>();
        VolverMenuBtn.onClick.AddListener(Volver);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D final) {
         if (final.CompareTag("ChiguiroPlayer")){
             controlador_ganar.gameObject.SetActive(true);
        }
    }

    public void VolverJugar(){  
        SceneManager.LoadScene("PruebaChiguiro");
    }

    public void Volver(){
        
        SceneManager.LoadScene("SampleScene");
    }
}
