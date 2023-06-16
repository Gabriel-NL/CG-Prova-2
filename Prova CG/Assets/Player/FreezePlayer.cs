using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    public GameObject playerObject; // Reference to the jogador_objeto's GameObject
    // or

    public void AnimationFinished()
    {
        Rigidbody playerRigidbody;

        // Option 1: Access Rigidbody via GameObject reference
        playerRigidbody = playerObject.GetComponent<Rigidbody>();

        // Freeze rotation and position
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    
}
