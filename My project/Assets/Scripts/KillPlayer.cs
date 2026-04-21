using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour
{
    // Kill player script
    // This script can be attached to objects that should cause the player to die when they collide with them, such as spikes, lava, or falling off the map.

    private CheckpointManager checkpointManager;
    void OnCollisionEnter(Collision other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            if(checkpointManager == null)
            {
                checkpointManager = FindFirstObjectByType<CheckpointManager>();
            }
            if (checkpointManager != null)
            {
                // Move the player to the last checkpoint position
                other.gameObject.transform.position = checkpointManager.GetRespawnPosition();

                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
            
        }
    }
}