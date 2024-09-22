using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private Rigidbody _playerRigidbody;
    private List<Vector3> _velocitiesList;

    public int ListSize = 10;
    public float LerpSpeed = 1.0f;

    private void Awake()
    {
        _playerRigidbody = _playerTransform.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _velocitiesList = new List<Vector3>(ListSize);

        for (int i = 0; i < ListSize; i++)
        {
            _velocitiesList.Add(Vector3.zero);
        }
    }

    private void Update()
    {
        LookingForPlayer();
    }

    private void FixedUpdate()
    {
        UpdatePlayerVelocity();
    }

    private void LateUpdate()
    {
        transform.position = _playerTransform.position;
    }

    private void LookingForPlayer()
    {
        Vector3 summ = Vector3.zero;

        for (int i = 0; i < _velocitiesList.Count; i++)
        {
            summ += _velocitiesList[i];
        }

        summ = new Vector3(summ.x, 0f, summ.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ), Time.deltaTime * LerpSpeed);
    }

    private void UpdatePlayerVelocity()
    {
        _velocitiesList.Add(_playerRigidbody.velocity);
        _velocitiesList.RemoveAt(0);
    }
}
