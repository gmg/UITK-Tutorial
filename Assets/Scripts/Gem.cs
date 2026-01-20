using System;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public static event Action GemCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        GemCollected?.Invoke();
        gameObject.SetActive(false);
    }
}
