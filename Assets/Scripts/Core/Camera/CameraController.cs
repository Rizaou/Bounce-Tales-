using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera _dollyCamera;
    [SerializeField] CinemachineVirtualCamera _waterCamera;


    private void Awake()
    {
        PlayerMovement playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playerMovement.whenInLand += DollyCamera;
        playerMovement.whenInWater += WaterCamera;
        
    }


    public void WaterCamera()
    {
        _dollyCamera.Priority = 0;
        _waterCamera.Priority = 1;
    }

    public void DollyCamera()
    {
        _dollyCamera.Priority = 1;
        _waterCamera.Priority = 0;
    }
}
