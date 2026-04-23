using UnityEngine;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour
{
    // Win area script
    // This script can be attached to objects that should cause the player to win when they collide with them.

    private CheckpointManager checkpointManager;
    void OnCollisionEnter(Collision other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}