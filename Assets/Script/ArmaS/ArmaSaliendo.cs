using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaSaliendo : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

    private int armaSeleccionada;

    [SerializeField] private Transform cubePosition;

    [SerializeField] private Transform cubeInitialPosition;
    

    private Animation movement;

    private int armaFinal;

    private float timerArma;

    private int counter, counterCompare;

    public float TimerArma { get => timerArma; set => timerArma = value; }
    public int ArmaFinal { get => armaFinal; set => armaFinal = value; }

    private void Start()
    {
          movement = GetComponent<Animation>();
    }

    private void FixedUpdate()
    {
       
        if(movement.IsPlaying("armaSaliendo"))
        {
            timerArma += Time.deltaTime;
            armas[armaSeleccionada].SetActive(true);

            if (timerArma < 3f && counter<counterCompare)
            {
                counter++;

            }
            else if (counter == counterCompare)
            {
                counter = 0;
                RandomizerGun();
                counterCompare++; 
            }
            else if (timerArma >= 3f )
            {
                //armaSeleccionada = armaFinal;


            }
            armas[armaSeleccionada].transform.position = cubePosition.position;

        }
        else
        {
            counterCompare = 0;
            counter = 0;
            timerArma = 0;
            armas[armaSeleccionada].transform.position = cubeInitialPosition.position;
            armas[armaSeleccionada].SetActive(false);
            armaFinal = 0;



        }




    }

    private void CogerArma()
    {
        
    }

    //override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{


    //}






    void RandomizerGun()
    {
        int gunCount = armas.Length;
        int rand = Random.Range(0, gunCount);

        while (rand == armaSeleccionada)
        {

            rand = Random.Range(0, gunCount);   
        }

        armaSeleccionada = rand;

        DisableGuns();




        armas[armaSeleccionada].SetActive(true);
        armas[armaSeleccionada].transform.position = cubePosition.position;


    }


    void DisableGuns()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);


        }


    }



}
