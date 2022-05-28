using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAdjustment : MonoBehaviour
{
    public CinemachineTrackedDolly dolly;
    [SerializeField] private Vector3 waterOffset;
    [SerializeField] CinemachineTransposer transposer;
    [SerializeField] float _speed = 1f;

    private void Awake()
    {
        CinemachineVirtualCamera vcam = GetComponent<CinemachineVirtualCamera>();
        transposer = vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();

    }

    private void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().whenInLand += (LandCamera);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().whenInWater += (WaterCamera);
    }

    public void WaterCamera()
    {
        Debug.Log("Water Camera");
        StopAllCoroutines();
        StartCoroutine(IWaterCamera());
    }

    public void LandCamera()
    {
        Debug.Log("Land Camera");
        StopAllCoroutines();
        StartCoroutine(ILandCamera());
    }

    private IEnumerator IWaterCamera()
    {

        Vector3 currentOffset = dolly.m_PathOffset;


        while (dolly.m_PathOffset != waterOffset)
        {
            dolly.m_PathOffset = Vector3.Lerp(dolly.m_PathOffset, waterOffset, _speed * Time.deltaTime);
            yield return null;
        }

        dolly.m_PathOffset = waterOffset;


    }

    private IEnumerator ILandCamera()
    {
        Vector3 currentOffset = dolly.m_PathOffset;


        while (dolly.m_PathOffset != Vector3.zero)
        {
            dolly.m_PathOffset= Vector3.Lerp(dolly.m_PathOffset, Vector3.zero, _speed * Time.deltaTime);
            yield return null;
        }

       dolly.m_PathOffset= Vector3.zero;
    }

}
