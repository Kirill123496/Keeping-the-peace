using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorm : Entity
{
    [SerializeField] private int _lives = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            HP.Instance.GetDamage();
            _lives--;
            Debug.Log("У червяка " + _lives);
        }
        if (_lives < 1) Die();
    }
}
