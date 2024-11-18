using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemigoPrefab;
    [SerializeField]private Transform[] puntosSpawn;
    [SerializeField] private int numeroNiveles;
    [SerializeField] private int rondasPorNivel;
    [SerializeField] private int spawnsPorRonde;
    [SerializeField] private int esperaEntreSpawns;
    [SerializeField] private int esperaEntreRondas;
    [SerializeField] private int esperaEntreNiveles;


    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine( Spawnear());
    }

    // Update is called once per frame
    void Update()
    {

       

    }

    IEnumerator Spawnear()
    {

       for (int i = 0; i < numeroNiveles; i++)
        {
            for (int j = 0; j < rondasPorNivel; j++)
            {
                for (int k = 0; k < spawnsPorRonde; k++)
                {
                    Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
                 yield return new WaitForSeconds(esperaEntreSpawns);

                }
                yield return new WaitForSeconds(esperaEntreRondas);
            }

            yield return new WaitForSeconds(esperaEntreNiveles);

        }


    }
}
