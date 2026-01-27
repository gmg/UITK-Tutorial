using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }
    public int Lives { get; private set; }

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

    public void StartNewGame()
    {
        Score = 0;
        Lives = 3;
        SceneManager.LoadScene("GamePlay");
    }

    private void OnEnable()
    {
        Gem.GemCollected += OnGemCollected;
        KeyCard.KeyCardCollected += OnKeyCardCollected;
        Door.DoorEntered += OnDoorEntered;
        Player.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        Gem.GemCollected -= OnGemCollected;
        KeyCard.KeyCardCollected -= OnKeyCardCollected;
        Door.DoorEntered -= OnDoorEntered;
        Player.PlayerDied -= OnPlayerDied;
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

    private void OnPlayerDied()
    {
        Lives--;
        Debug.Log("Player died");
    }

}
