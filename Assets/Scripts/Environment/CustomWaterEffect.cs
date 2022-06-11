using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class CustomWaterEffect : MonoBehaviour
{

    [SerializeField] float xSpeed = 1f;
    [SerializeField] float ySpeed = 1f;
    private LensDistortion lens = null;
    private bool _inside = false;
    private float xTimer = 0f;
    private float yTimer = .3f;


    private void Update()
    {
        if (!lens) { return; }

        xTimer += Time.deltaTime;
        yTimer += Time.deltaTime;

        lens.xMultiplier.value = Mathf.Abs(Mathf.Sin(xTimer * xSpeed));
        lens.yMultiplier.value = Mathf.Abs(Mathf.Sin(yTimer * ySpeed));




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Volume>(out Volume volume))
        {
            if (volume.profile.TryGet<LensDistortion>(out LensDistortion lens))
            {
                this.lens = lens;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Volume>(out Volume volume))
        {
            if (volume.profile.TryGet<LensDistortion>(out LensDistortion lens))
            {
                lens = null;


            }
        }
    }





}
