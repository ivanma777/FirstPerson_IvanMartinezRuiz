using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private GameObject explosion;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

    }
}
