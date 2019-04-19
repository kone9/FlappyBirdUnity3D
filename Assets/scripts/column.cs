using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class column : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameController.instance.BirdScored();
        }
    }

}
