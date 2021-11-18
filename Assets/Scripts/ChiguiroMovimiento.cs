using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChiguiroMovimiento : MonoBehaviour
{
    //Vida
    public Image Corazon1;
    public Image Corazon2;
    public Image Corazon3;
    public Image lose;
   // public Image Corazon;
    //public int CantDeCorazon;
    public int vida = 3;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int Offset;
  
    //Salto regulable
    public bool Saltando;
    private float Ypos;
    private int sky_;
    private float inputMovimiento;



    public float speed;
    public float maxspeed;
    public float fuerzaSalto;
    public int saltosMax = 2;
    public LayerMask capaSuelo;


    private int saltosRestantes;
    private Vector2 moveInput;
    private bool mirandoDerecha = true;
    private  Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        saltosRestantes = saltosMax;

        //Transform PosCorazon = PosicionPrimerCorazon;

        //for (int i = 0; i < CantDeCorazon; i++)
        //{
        //    Image NewCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
        //    NewCorazon.transform.parent = MyCanvas.transform;
        //    PosCorazon.position = new Vector2(PosCorazon.position.x + Offset, PosCorazon.position.y);
        //}

    }

    // Update is called once per frame
    void Update()
    {
       
        

             ProcesarMovimiento();
        ProcesarSaltoDerecha();
        ProcesarSaltoIzquierda();
        izquierda(inputMovimiento);
        derecha(inputMovimiento);
        AtaqueDerecha();
        AtaqueIzquierda();
        
       


        if (vida <= 2)
        {
            
            Destroy(Corazon3);
        } if(vida <= 1)
        {
            Destroy(Corazon2);
        }
        if (vida <= 0)
        {
            
            Destroy(Corazon1);
            Destroy(gameObject);
         
        }

    }

    bool EstaEnSuelo(){
        RaycastHit2D raycastHit= Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down,0.1f,capaSuelo);
        return raycastHit.collider != null;
    }

        public void ProcesarSaltoIzquierda(){
        if(EstaEnSuelo()){
            saltosRestantes = saltosMax;
            animator.SetBool("sky2", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0 && mirandoDerecha == false){
            animator.SetBool("sky2",true);
            saltosRestantes--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        if(transform.position.y > Ypos){
            animator.SetFloat("Gravity",1);
        }
        if (transform.position.y < Ypos){
            animator.SetFloat("Gravity", 0);
        }
        Ypos = transform.position.y;
    }

    public void AtaqueDerecha(){
        if(mirandoDerecha == true){
            
             if (Input.GetMouseButtonDown(1)){
                Debug.Log("Pressed primary button.");
                
                animator.SetBool("IsAttackRight", true);
                Debug.Log(animator.GetBool("IsAttackRight"));
             }else{
                 animator.SetBool("IsAttackRight", false);
             }
        }
    }

    public void AtaqueIzquierda(){
        if(mirandoDerecha == false){
             if (Input.GetMouseButtonDown(1)){
                animator.SetBool("IsAttackLeft", true);
                Debug.Log(animator.GetBool("IsAttackLeft"));
             }else{
                 animator.SetBool("IsAttackLeft", false);
             }
        }
    }

    public void ProcesarSaltoDerecha(){
        if(EstaEnSuelo()){
            saltosRestantes = saltosMax;
            animator.SetBool("sky", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0 && mirandoDerecha == true){
            animator.SetBool("sky",true); 
            saltosRestantes--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        if(transform.position.y > Ypos){
            animator.SetFloat("Gravity",1);
        }
        if (transform.position.y < Ypos){
            animator.SetFloat("Gravity", 0);
        }
        Ypos = transform.position.y;
    }

     void Orientacion(float inputMovimiento){
        if (mirandoDerecha == true && inputMovimiento < 0)
        {
            mirandoDerecha = false;
        }
        if (mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = true;
        }
    }
    
    void derecha(float inputMovimiento){
        if(inputMovimiento != 0 && mirandoDerecha == true){  
                animator.SetBool("IsRunningRight", true);
        }else{
                animator.SetBool("IsRunningRight", false);
        }
    }

    void izquierda(float inputMovimiento){
        if(inputMovimiento != 0 && mirandoDerecha == false){  
            animator.SetBool("IsRunningLeft", true);
        }else{
            animator.SetBool("IsRunningLeft", false);
        }
    }
    void ProcesarMovimiento(){
        inputMovimiento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(inputMovimiento * maxspeed, rigidbody.velocity.y);
        Orientacion(inputMovimiento);
    }

    //Reconocer hit del la trampa para restar vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            print("aychhhhhh" + vida);
            
            vida -= 1;

            
        }
    }

    
}
