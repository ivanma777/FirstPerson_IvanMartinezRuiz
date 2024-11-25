using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    [SerializeField] private float fuerzaImpulso;

    [Header("Explosion")]
    [SerializeField] private float radioExplosion;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask QueEsExplotable;

    private Collider[] buffer;

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

        int nCollDetect = Physics.OverlapSphereNonAlloc(transform.position, radioExplosion, buffer, QueEsExplotable);

        if (nCollDetect > 0)
        {

            for (int i = 0; i < nCollDetect; i++)
            {
               if( buffer[i].TryGetComponent(out ParteEnemigo scriptHueso))
                {
                    scriptHueso.Explotar(fuerzaExplosion, transform.position, radioExplosion, 3.5f);

                }

            }
        }
        

    }
}
