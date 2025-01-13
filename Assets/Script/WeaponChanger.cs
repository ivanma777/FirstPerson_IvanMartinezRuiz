using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

    [SerializeField] private ArmaSaliendo caja;

    private int indiceArmaActual;

    private bool tope;
    private bool tope2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaConTeclado();
        CambiarRaton();
        




    }

    private void CambiarArma(int indiceArma)
    {
        armas[indiceArmaActual].SetActive(false);

        armas[indiceArma].SetActive(true);  

        indiceArmaActual = indiceArma;  

        if(indiceArmaActual < 0 )
        {
            indiceArma = armas.Length - 1;


        }
        else if(indiceArmaActual >= armas.Length)
        {
            indiceArma = 0;


        }
    }

    private void CambiarArmaConTeclado()
    {


        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {

            CambiarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            CambiarArma(3);




        }

        
    }

    void CambiarRaton()
    {


        float scroolWheel = Input.GetAxis("Mouse ScrollWheel");

        if(scroolWheel > 0 && !tope)
        {

            CambiarArma(1);
            tope = true;
            tope2 = false;

        }
        else if(scroolWheel < 0 && !tope2)
        {

            CambiarArma(/*indiceArmaActual - 1*/0);
            tope2 = true;
            tope = false;

        }



    }

    public void CambiarLista()
    {
        //int seleccionado = indiceArmaActual;
        //indiceArmaActual = caja.ArmaFinal; // Eliminarlo de su posición original
        //caja.ArmaFinal = seleccionado; // Insertarlo al inicio

        // Mostrar la lista modificada
        

        for (int i = caja.ArmaFinal; i > 0; i--)
        {
            armas[i] = armas[i - 1];


        }
        armas[0] = armas[caja.ArmaFinal];


    }
         




}
