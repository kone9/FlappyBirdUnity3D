using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance; //variable singleton
    public GameObject gameOverText; //referencia al objeto texto
    public bool GameOver; //esta o no esta destruida
    public soundSystem soundSystem; 
    public float scrollSpeed = -1.5f;
    public int score;
    public Text scoreText;





    private void Awake()
    {
        //GameController.instance = this;

        if (GameController.instance == null)
        {
            GameController.instance = this; //inicializo el singleton
        }
        else if (GameController.instance != this)
        {
            Destroy(gameObject); //destruyo el singleton
            Debug.LogWarning("gamecontroller ha sido instaicado por segunda ves.Esto no deberia pasar");
        }
            
            
        
    }

    public void BirdScored()
    {
        //if (GameOver) return; tambien se puede escribir de esta manera
        if (!GameOver)
        {
            soundSystem.instance.PlayCoint();
            score++;
            scoreText.text = "Score = " + score;
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver && Input.GetMouseButtonDown(0))
        {
            
            SceneManager.LoadScene("main"); //reinicio escena en la misma escena    
        }
    }

    public void BirdDie()//si el pajaro esta muerto
    {
        soundSystem.Pararmusica(); //accedo al componente sonido simpem,funcion pararmusica
        gameOverText.SetActive(true); // vemos el texto game over
        GameOver = true; //variable bool game over verdadero
    }

    private void OnDestroy()
    {
        if(GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}
