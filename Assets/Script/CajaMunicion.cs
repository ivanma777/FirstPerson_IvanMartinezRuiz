using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    private Animator anim;

    //[SerializeField] private Animator movement;

    private Animation movement;

    private bool cajaAbierta;
    private bool cajaEstaAbierta;

    private ArmaSaliendo armaSaliendo;
    private int armaEscogida;

    [SerializeField] private WeaponChanger weaponChanger;

    public int ArmaEscogida { get => armaEscogida; set => armaEscogida = value; }



    //[SerializeField] private Animation movement;
    private void Start()
    {
        anim = GetComponent<Animator>();

        movement = GetComponentInChildren<Animation>();

        armaSaliendo = GetComponentInChildren<ArmaSaliendo>();

    }

    private void Update()
    {
        //AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);


        //if (stateInfo.normalizedTime >= 1 && stateInfo.IsName("AperturaCajaM") && !isPlayed )
        //{
        //SaleArma();
        //isPlayed = true;

        //}

        CerrarArma();


    }





    public void AbrirCaja()
    {
        cajaAbierta = true;


        if (cajaAbierta && !movement.IsPlaying("armaSaliendo"))
        {
            anim.Play("AperturaCajaM");
            anim.SetBool("cerrar", false);

            //movement.SetBool("arma2", true);

            movement.Play();

            anim.SetBool("cerrar", false);

        }
        else if (armaSaliendo.TimerArma >= 3f )
        {
            CerrarCajaInsta();
            //armaSaliendo.ArmaFinal = armaEscogida;
            //weaponChanger.CambiarLista();
            
        }
        


        
        


    }

    private void CerrarCajaInsta()
    {
        movement.Stop();



    }

    

    private void CerrarArma()
    {
        if (cajaAbierta )
        {

           if (!movement.IsPlaying("armaSaliendo"))
           {

                anim.SetBool("cerrar", true);

                cajaAbierta = false;



           }


        }

        


        


    }
}
