using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public Button Reintentar_Menu;
    public Button Reintentar;
    public Text puntos;

    public int PuntosTotales{get{ return puntosTotales; }}
    private int puntosTotales;

    // Start is called before the first frame update
    void Start()
    {
        Button reintertarBtn = Reintentar.GetComponent<Button>();
        reintertarBtn.onClick.AddListener(IrReintentar); 
    }
    // Update is called once per frame
    void Update()
    {
        puntos.text = ": "+ puntosTotales.ToString();
    }

    public void SumaPuntos( int puntosASumar){
        puntosTotales += puntosASumar;

   }

   public void IrReintentar(){
        SceneManager.LoadScene("PruebaChiguiro");
   }
}
