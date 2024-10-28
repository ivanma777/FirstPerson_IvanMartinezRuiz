using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private float velocidadMovimiento;

    private float velocidadRotacion;
    [SerializeField] private float smoothTime;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v);
        if (input.magnitude > 0)
        {
            anim.SetBool("Walking", true);
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, smoothTime);

            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

    }
}
