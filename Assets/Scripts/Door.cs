using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static event Action DoorEntered;
    
    [SerializeField] private Color closedColor = Color.magenta;
    [SerializeField] private Color openColor = Color.cyan;
    
    private SpriteRenderer _spriteRenderer;
    private Collider2D _col;
    private bool _isOpen = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = closedColor;
        _col = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        KeyCard.KeyCardCollected += OnKeyCardCollected;
    }

    private void OnDisable()
    {
        KeyCard.KeyCardCollected -= OnKeyCardCollected;
    }

    private void OnKeyCardCollected()
    {
        _spriteRenderer.color = openColor;
        _col.isTrigger = true;
        _isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        DoorEntered?.Invoke();
    }
}
