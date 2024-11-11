using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteEnemigo : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanho;
    public void RecibirDahno(float danhoEnemigo)
    {
        mainScript.Vida -= danhoEnemigo * multiplicadorDanho;
        if (mainScript.Vida == 0)
        {

            mainScript.Morir();


        }
    }
}
