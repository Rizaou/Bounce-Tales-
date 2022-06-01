using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallPreferences", menuName = "ScriptableObjects/Create Ball", order = 0)]
public class SBallPreferences : ScriptableObject
{
    [SerializeField] private Material material;
    [SerializeField] float _landSpeed = 5f;
    [SerializeField] float _waterSpeed = 1f;
    [SerializeField] float _landJumpForce = 10f;
    [SerializeField] float _waterJumpForce = 5f;
    [SerializeField] float maxSpeed = 10f;

    public float LandSpeed { get => _landSpeed;  }
    public float WaterSpeed { get => _waterSpeed;  }
    public float LandJumpForce { get => _landJumpForce;  }
    public float WaterJumpForce { get => _waterJumpForce;  }
    public float MaxSpeed { get => maxSpeed; }
    public Material Material { get => material; }
}   
