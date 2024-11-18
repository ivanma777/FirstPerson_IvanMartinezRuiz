using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    //enemigo debe perser¡guier al player
    private NavMeshAgent   agent;
    private Animator anim;
    private Player player;
    private bool ventanaAbierta;
    private bool PuedoDanhar = true;

    private float vida = 10;

    [SerializeField]private float danhoEnemigo;

    [Header("attack")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAttack;
    [SerializeField] private LayerMask Danable;

    Rigidbody[] huesos;

    public float Vida { get => vida; set => vida = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<Player>();

        anim = GetComponent<Animator>();

        huesos = GetComponentsInChildren<Rigidbody>();

        CambiarEstadosHuesos(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            Perseguir();
            
        }

        if (ventanaAbierta && PuedoDanhar)
        { 
            DetectarImpact();
        
        }
       

    }

    private void DetectarImpact()
    {
       Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAttack, Danable );
        if (collsDetectados.Length > 0)
        {
            for (int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<Player>().RecibirDanho(danhoEnemigo);

            }

            PuedoDanhar = false;
        }
    }

    private void FinAtaque()
    {
        agent.isStopped = false;
        anim.SetBool("attack", false);
        PuedoDanhar = true;

    }
    private void AbrirVentanaDeAtaque()
    {
        ventanaAbierta = true;

    }
    private void CerrarVentana()
    { 
        ventanaAbierta = false;
    }
    void Perseguir()
    {

        agent.SetDestination(player.transform.position);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attack", true);

        }

    }
    private void CambiarEstadosHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = true;
        }

    }
    public void Morir()
    {
        CambiarEstadosHuesos(false);
        anim.enabled = false;
        agent.enabled = false;

    }
    
}
