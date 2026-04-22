using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collectibles : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the collectible object
            Destroy(gameObject);
            GameManager.Instance.AddScore(1);
        }
    }
}
