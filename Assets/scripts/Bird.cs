using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private bool isDead; //esta muerto

    private Rigidbody2D rb2d; //componente riggid body

    private Animator anim;

    public float upForce = 200f; //fuerza impulso




    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); //componente riggingbody2D
        anim = GetComponent<Animator>(); //componente animator
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead) return; //si esta muerto salgo de update
        
        if(Input.GetMouseButtonDown(0)) //si presiono boton izquierdo mouse
        {
            rb2d.velocity = Vector2.zero; //pongo la velocidad de caida en 0
            rb2d.AddForce(new Vector2(0,upForce)); // velocidad x, velocidad y
            anim.SetTrigger("flap");
            soundSystem.instance.Playflap();
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //si colisiono con el suelo
    {
        isDead = true; //esta muerto es igual a verdadero
        anim.SetTrigger("die");
        GameController.instance.BirdDie(); //llamo a la funcion BirdDie del sigleton
        rb2d.velocity = Vector2.zero;
        soundSystem.instance.Playhit();

    }
}
