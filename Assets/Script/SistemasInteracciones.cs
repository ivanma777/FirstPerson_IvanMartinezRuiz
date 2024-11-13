using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemasInteracciones : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    private Camera cam;
    private Transform interactuableActual;

    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        DeteccionCaja();
        
    }

    private void Interactuar()
    {
        if (!interactuableActual)
        { 
        
        
        
        
        }


    }

    // Update is called once per frame
    

    private void DeteccionCaja()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, maxDistance))
        {

            if (hitInfo.transform.TryGetComponent(out CajaMunicion scriptCaja))
            {
                interactuableActual = scriptCaja.transform;
                scriptCaja.transform.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                { 
                
                    scriptCaja.AbrirCaja();
                
                }
            }

        }
        else if (interactuableActual != null)
        {

            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;
        }
    }
}
