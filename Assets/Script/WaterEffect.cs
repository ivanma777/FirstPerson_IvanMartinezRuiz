using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class WaterEffect : MonoBehaviour
{
    private Volume volume;
    private LensDistortion distorsionEffects;
    [SerializeField] private float velocidadAngular;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Volume>();
        if(volume.profile.TryGet(out LensDistortion lensDistortion))
        {
            distorsionEffects = lensDistortion;

        }
    }

    // Update is called once per frame
    void Update()
    {

        FloatParameter ejemplo = new FloatParameter(1+Mathf.Sin(velocidadAngular * Time.time) /2 );
        FloatParameter ejemplo2 = new FloatParameter(1+Mathf.Cos(velocidadAngular * Time.time)/2);
        distorsionEffects.yMultiplier.SetValue(ejemplo) ;
        distorsionEffects.xMultiplier.SetValue(ejemplo2);


    }
}
