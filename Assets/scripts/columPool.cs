using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columPool : MonoBehaviour
{
    public int columnsPoolSize = 5;//cantidad de columnas
    public GameObject ColumnPrefacts; //cargo como prefacts a las columnas

    public float columnMin = -2.9f; //direccion en "Y" minima
    public float columnMax = 1.4f; //direccion en "Y" maxima
    private float spawnXPosition = 10f; //posición en "X" para iniciar

    private GameObject[] columns; //arreglo de tipo gameobjets para cargar objetos en cada indice
    private Vector2 objetctPoolPosition = new Vector2(-14,0); //posición inicial antes de comenzar

    private float timeSinceLastSpawnew; //tiempo antes de reiniciar posicion de columnas
    public float spawrate;//tiempo para reiniciarse se pone en la interface

    private int currentColumn = 0; //indice de la columna actual


    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnsPoolSize]; //agrego al objeto columns el tamaño la cantidad de columnas
        for(int i = 0; i < columnsPoolSize; i++ ) //repetir mientra indice del arreglo columna sea menor a i
        {
            columns[i] = Instantiate(ColumnPrefacts,objetctPoolPosition,Quaternion.identity);//instancio en cada indice del arreglo columns el objeto de tipo columnas
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawnew += Time.deltaTime;//tomo el tiempo actual en segundos
        if(!GameController.instance.GameOver &&  timeSinceLastSpawnew >= spawrate) //sino es game over y tiempo de espera es mayor al tie
        {

            timeSinceLastSpawnew = 0; //tiempo para reiniciar es igual a cero
            float spawnYPosition = Random.Range(columnMin,columnMax);//Numero aleatorio para el valor de la posición sobre "Y"
            columns[currentColumn].transform.position = new Vector2(spawnXPosition,spawnYPosition); //posición "X" e "y" de la columna..."Y" es aletorio en el rango establecido
            currentColumn++; //incremento el indice de las columnas
            if(currentColumn >= columnsPoolSize)//si el indice de la culmna actual es mayor o igual a tamaño de indice de columnas
            {
                currentColumn = 0;//indice de la columna actual es igual a cero
            }
        }
    }
}
