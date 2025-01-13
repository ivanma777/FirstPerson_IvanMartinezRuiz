using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Semi : MonoBehaviour
{
    [Header("arma")]
    private Camera cam;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;

    private int balasActuales;
    private int balasBolsaActuales;

    private bool puedoRecargar;
    private bool recargando = true;
    private bool quedaMunicion = true;

    private bool getAmmoIn;
    private bool delayedTime = true;

    private float tiempoCadaRonda;

    private float timer;
    

    [Header("texto")]

    [SerializeField] private TMP_Text textoBalas;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;


        balasActuales = misDatos.balasCargador;
        balasBolsaActuales = misDatos.balasBolsa;
    }

    // Update is called once per frame
    void Update()
    {
        textoBalas.text = balasActuales.ToString() + "/" + balasBolsaActuales.ToString();

        timer += Time.deltaTime;

        

        if (Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque && !getAmmoIn && delayedTime )
        {

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {

                //Debug.Log(hitInfo.transform.name);

                if (hitInfo.transform.TryGetComponent(out ParteEnemigo scriptEnemigo))
                {
                    scriptEnemigo.RecibirDahno(misDatos.danhoAtaque);

                }
            }

            if (tiempoCadaRonda <= 2)
            {


                system.Play();

                Balas();
                timer = 0;

            }
            else
            {
                delayedTime = false;
                StartCoroutine(DelayedAmmo());

            }
            
            


        }
        Recarga();
    }

    private void Balas()
    {
        balasActuales -= 1;

        tiempoCadaRonda += 1;
    }

    private void Recarga()
    {
        if (balasActuales >= 31)
        {
            puedoRecargar = false;

        }

        else if (balasActuales <= 0)
        {
            getAmmoIn = true;


        }
        else if (balasActuales <= 30)
        {
            puedoRecargar = true;

        }

        if (Input.GetMouseButtonDown(0) && getAmmoIn || Input.GetKeyDown(KeyCode.R) && puedoRecargar)
        {

            if (puedoRecargar && recargando && quedaMunicion)
            {
                recargando = false;
                getAmmoIn = true;
                //balasActuales = misDatos.balasCargador;

                StartCoroutine(DelayedAction());

            }

        }


    }
    private IEnumerator DelayedAction()
    {
        Debug.Log("Inicio Recarga");

        // Esperar 2 segundos antes de la siguiente acción
        yield return new WaitForSeconds(2f);

        Debug.Log("Fin Recarga");
        reload();

        //balasBolsaActuales -= misDatos.balasCargador - balasActuales;
        //balasActuales = misDatos.balasCargador;

    }

    private IEnumerator DelayedAmmo()
    {
        Debug.Log("Inicio Recarga");

        yield return new WaitForSeconds(0.5f);

        tiempoCadaRonda = 0;
        delayedTime = true;

    }

    private void OnEnable()
    {
        textoBalas.enabled = true;
    }
    private void OnDisable()
    {
        textoBalas.enabled = false;
    }

    private void hayBalasEnLaBolsa()
    {
        if (balasBolsaActuales <= 0)
        {
            quedaMunicion = false;

        }
        else
        {
            quedaMunicion = true;

        }

    }

    private void reload()

    {
        getAmmoIn = false;
        recargando = true;

        if (balasBolsaActuales > 0)
        {
            // Determinar cuántas balas se pueden recargar
            int neededAmmo = misDatos.balasCargador - balasActuales;
            int ammoToReload = Mathf.Min(neededAmmo, balasBolsaActuales);

            // Recargar
            balasActuales += ammoToReload;
            balasBolsaActuales -= ammoToReload;

            Debug.Log("Recargado! Balas actuales: " + balasActuales + ", Balas restantes: " + balasBolsaActuales);
        }
        else
        {
            Debug.Log("¡Sin balas restantes!");
        }

    }
}
