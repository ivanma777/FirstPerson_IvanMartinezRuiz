using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteEnemigo : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanho;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void RecibirDahno(float danhoEnemigo)
    {
        mainScript.Vida -= danhoEnemigo * multiplicadorDanho;
        if (mainScript.Vida == 0)
        {

            mainScript.Morir();


        }
    }

    public void Explotar(float fuerzaExplosion, Vector3 puntoImpacto, float radioExplosion, float upward)
    {
        mainScript.Morir();
        rb.AddExplosionForce(fuerzaExplosion,puntoImpacto,radioExplosion,upward, ForceMode.Impulse);

    }
}
