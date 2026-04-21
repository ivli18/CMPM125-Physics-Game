using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CheckpointBehavior : MonoBehaviour
{
    // Checkpoint behavior script
    // This script can be attached to checkpoint objects in the game.
    
    // References to other game objects or components can be added here, such as the player or checkpoint manager.
    private GameObject player;
    private int checkpointID;
    [SerializeField] private bool isActive;
    private Vector3 checkpointPosition; 

    void Start()
    {
        
    }

    

}
