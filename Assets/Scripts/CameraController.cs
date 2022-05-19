using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _pos;

    private void Awake()
    {
        if (!_player) { 
            _player = FindObjectOfType<Player>().transform;
        }
    }

    private void Update()
    {
        _pos = _player.position;
        _pos.z = -10f;
        transform.position = Vector3.Lerp(transform.position, _pos, 1f);
    }
}