using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _coinsText;    

    private Collider _otherCollider;
    private int _neededAmount = 20;
    private int _coinCount = 0;
    private float _timer = 60f;
    
    public int NeededAmount => _neededAmount;
    public int CoinCount => _coinCount;
    public float Timer => _timer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            _coinCount++;            
        }
        Destroy(other.gameObject);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _timerText.text = _timer.ToString("00");
        _coinsText.text = ($"Собрано {_coinCount} / {_neededAmount}");
    }
}
