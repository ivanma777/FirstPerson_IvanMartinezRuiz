using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    private Vector3 movimientoVertical;
    [SerializeField] private LayerMask FloorCheck;
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
        AplicarGravedad();
        EnSuelo();
    }

    private void AplicarGravedad()
    {
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);

    }
    private bool EnSuelo()
    {
       bool resultado = Physics.CheckSphere(pies.position, radioDeteccion);
        return resultado;
    }


}
