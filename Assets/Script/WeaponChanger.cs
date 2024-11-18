using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

    private int indiceArmaActual;
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
        else if(indiceArmaActual > armas.Length)
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

        if(scroolWheel > 0)
        {
            CambiarArma(indiceArmaActual + 1);

        }
        else if(scroolWheel < 0)
        {

            CambiarArma(indiceArmaActual - 1);
        }



    }
         




}
