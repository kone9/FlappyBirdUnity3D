using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSystem : MonoBehaviour
{
    public static soundSystem instance; //variable global instance

    public AudioSource audiohit;
    public AudioSource audioflap;
    public AudioSource audiocoint;
    public AudioSource musica;



    private void Awake()    
    {
        if(soundSystem.instance == null) //si la variable sonidoSystem es igual a vacio
            {
            soundSystem.instance = this; //crear una instancia
            }
        else if(soundSystem.instance != this) //sino es esta creada
        {
            Destroy(gameObject); //destruir el game object del sonido
        }
    } 

    private void OnDestroy() //funcion destruir sonido creado
    {
        if(soundSystem.instance == this) //si el sonido es igual al que sono
        {
            soundSystem.instance = null; //sound va a ser igual a vacio
        }
    }


    public void PlayCoint() //funcion empezar sonido coint
    {
        audiocoint.Play(); //llama a la función con el parametro audioclipcoint
    }

    public void Playflap() //funcion empezar sonido volar
    {
        audioflap.Play(); //llama a la función con el parametro audioclipflap
    }

    public void Playhit() //funcion empezar sonido hit
    {
        audiohit.Play(); //llama a la función con el parametro audiocliphit
    }

    public void Pararmusica() //funcion empezar sonido hit
    {
        musica.Stop(); //llama a la función con el parametro audiocliphit
    }

}
