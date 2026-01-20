using System;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public static event Action KeyCardCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        KeyCardCollected?.Invoke();
        gameObject.SetActive(false);
    }
}
