using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBall : MonoBehaviour
{
    public enum BallType
    {
        red,
        grey,
    };


    [SerializeField] BallType ballType = BallType.red;
    [SerializeField] SBallPreferences red;
    [SerializeField] SBallPreferences grey;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            switch (ballType)
            {
                case BallType.red:
                    playerMovement.ChangeBallPreferences(red);
                    break;
                case BallType.grey:
                    playerMovement.ChangeBallPreferences(grey);
                    break;
            }

        }
    }
}
