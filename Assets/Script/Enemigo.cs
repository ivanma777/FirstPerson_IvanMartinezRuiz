using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    //enemigo debe perser�guier al player
    private NavMeshAgent   agent;
    private Animator anim;
    private Player player;
    private bool ventanaAbierta;


    [SerializeField]private float danhoEnemigo;

    [Header("attack")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAttack;
    [SerializeField] private LayerMask Danable;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<Player>();

        anim = GetComponent<Animator>();

       
        
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();

        if (ventanaAbierta)
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


        }
    }

    private void FinAtaque()
    {
        agent.isStopped = false;
        anim.SetBool("attack", false);

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

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attack", true);

        }

    }
}