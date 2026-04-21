using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Checkpoint manager script
// This script can be attached to an empty game object in the scene to manage checkpoints.

public class CheckpointManager : MonoBehaviour
{
    // Checkpoint behavior that logs the current checkpoint and allows the player to respawn at that checkpoint when they die.
    [SerializeField] private CheckpointBehavior initialCheckpoint;
    private CheckpointBehavior currentCheckpoint;    
    
    // List of checkpoints in the game
    private List<CheckpointBehavior> checkpoints;

    void Start()
    {
        // Initialize the list of checkpoints
        checkpoints = new List<CheckpointBehavior>();
        
        // Find all checkpoint objects in the scene and add their CheckpointBehavior components to the list
        CheckpointBehavior[] checkpointArray = FindObjectsByType<CheckpointBehavior>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );
        checkpoints.AddRange(checkpointArray);
        
        if (initialCheckpoint != null)
        {
            // Set the initial checkpoint to the first one found (this can be changed as needed)
            currentCheckpoint = initialCheckpoint;  
        }
        else if (checkpoints.Count > 0)
        {
            initialCheckpoint = checkpoints[0];
            currentCheckpoint = initialCheckpoint;
        }
        else
        {
            Debug.LogError("No checkpoints found in scene.");
        }

        Debug.Log("Checkpoints: " + checkpoints);
    }

    // Additional methods for managing checkpoints can be added here, such as activating a checkpoint, resetting to a checkpoint, etc.
    void UpdateCurrentCheckpoint(CheckpointBehavior newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }
    public Vector3 GetRespawnPosition()
    {
        return currentCheckpoint.transform.position;
    }

}