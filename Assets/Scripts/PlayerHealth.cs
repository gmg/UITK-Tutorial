using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action<int> HealthChanged;
    public event Action HealthDepleted;

    [SerializeField] private int maxHealth = 100;

    private int _health;
    public int Health {  
        get
        {
            return _health;
        } 
        private set
        {
            _health = value;
            HealthChanged?.Invoke(_health);

            if (_health <= 0) HealthDepleted?.Invoke();
        }
    }

    private void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
