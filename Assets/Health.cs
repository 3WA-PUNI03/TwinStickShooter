using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool _isPlayer;
    [SerializeField] int _startHealth;
    [SerializeField] int _scoreOnDeath;

    [SerializeField] UnityEvent _onPlayerDamage;

    public bool IsPlayer { get => _isPlayer; set => _isPlayer = value; }

    private void Reset()
    {
        _startHealth = 30;
        _scoreOnDeath = 10;
    }

    public void TakeDamage(int amount)
    {
        _startHealth -= amount;

        if( _isPlayer )
        {
            _onPlayerDamage?.Invoke();
        }


        if(_startHealth <= 0)
        {
            if(_isPlayer)
            {
                // Reload Menu
                SceneManager.LoadScene("Menu");
            }
            else
            {
                ScoreManager.Instance.AddScore(_scoreOnDeath);
            }

            Destroy(gameObject);
        }

    }


}
