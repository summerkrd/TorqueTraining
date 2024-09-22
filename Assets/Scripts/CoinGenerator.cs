using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _points;

    private void Start()
    {
        foreach (Transform point in _points)
        {
            Vector3 position = point.position;
            Instantiate(_coinPrefab, position, Quaternion.identity);
        }
    }
}
