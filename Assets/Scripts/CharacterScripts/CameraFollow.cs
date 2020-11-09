using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform = null;
    void Update()
    {
        transform.position = _playerTransform.position + new Vector3(0, 25, -50);
    }
}
