using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemigoPrefab;
    [SerializeField]private Transform[] puntosSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, 8)].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
