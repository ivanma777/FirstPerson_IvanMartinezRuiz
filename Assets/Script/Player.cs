using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float velocidadMovimiento;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v);
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(0, angulo, 0);
        if(input.magnitude > 0)
        {

            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;  

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        
    }
}
