using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class BebidasBotella : MonoBehaviour
{
    private Animation animationes;

    [SerializeField] private GameObject image;


    //[Header("mejora")]
    //[SerializeField] private BebidasScript perk;

    //private float perkActual ;

    

    private void Start()
    {
        animationes = GetComponent<Animation>();

        //CambiarVelocidadRecarga();
    }

    private void Update()
    {
        if (!animationes.IsPlaying("jugger"))
        {
            this.gameObject.SetActive(false);

            image.SetActive(true);

        }
    }



    //public void CambiarVelocidadRecarga()
    //{

    //    perkActual = perk.velocidadRecarga;

    //}
}
