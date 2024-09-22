using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotateSpeed);
    }
}
