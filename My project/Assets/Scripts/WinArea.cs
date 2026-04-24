using UnityEngine;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour
{
    [SerializeField] private string levelToLoad; // The name of the level to load when the player wins
    // Win area script
    // This script can be attached to objects that should cause the player to win when they collide with them.

    private CheckpointManager checkpointManager;
    void OnCollisionEnter(Collision other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}