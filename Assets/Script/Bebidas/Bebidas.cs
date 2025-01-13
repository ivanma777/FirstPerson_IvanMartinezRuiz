using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bebidas : MonoBehaviour
{
    



    [SerializeField]  GameObject bebidas;
    public void Tomar()
    {
        bebidas.SetActive(true);


    }
}
