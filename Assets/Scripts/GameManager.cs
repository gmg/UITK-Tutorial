using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Too many game managers, deleting extra");
            Destroy(gameObject);
        } 
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void OnEnable()
    {
        Gem.GemCollected += OnGemCollected;
        KeyCard.KeyCardCollected += OnKeyCardCollected;
        Door.DoorEntered += OnDoorEntered;
    }

    private void OnGemCollected()
    {
        Score++;
        Debug.Log($"Score updated: {Score}");
    }

    private void OnKeyCardCollected()
    {
        Debug.Log("KeyCard Collected");
    }

    private void OnDoorEntered()
    {
        Debug.Log("Door Entered");
    }

}
