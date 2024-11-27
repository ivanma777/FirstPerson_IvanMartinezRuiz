using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque)
        {
            
                system.Play();
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
                {

                    //Debug.Log(hitInfo.transform.name);

                    if (hitInfo.transform.TryGetComponent(out ParteEnemigo scriptEnemigo))
                    {
                        scriptEnemigo.RecibirDahno(misDatos.danhoAtaque);

                    }
                }

            timer = 0;


        }
    }
}
