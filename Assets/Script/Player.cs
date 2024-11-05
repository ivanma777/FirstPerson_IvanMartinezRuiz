using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float vidas;

    [Header("movimineto")]
    private CharacterController controller;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float alturaSalto;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float radioDeteccion;

    [Header("pies")]
    [SerializeField] private Transform pies;
    private Vector3 movimientoVertical;
    [SerializeField] private LayerMask FloorCheck;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v);

         transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        if(input.magnitude > 0)
        {
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;  

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        AplicarGravedad();

        if(EnSuelo())
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }
    private void Saltar()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
        }
        
    

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);

    }

    public void RecibirDanho(float danhoEnemigo)
    {
        vidas -= danhoEnemigo;

    }
}
