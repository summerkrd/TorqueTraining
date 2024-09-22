using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    
    [SerializeField] private Image _winImage;
    [SerializeField] private Image _loseImage;

    private void Start()
    {
        _winImage.gameObject.SetActive(false);
        _loseImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_coinCollector.Timer <= 0)
        {
            EndOfTheGame(_loseImage);
        }

        if (_coinCollector.CoinCount >= _coinCollector.NeededAmount)
        {
            EndOfTheGame(_winImage);
        }
    }

    private void EndOfTheGame(Image image)
    {
        Time.timeScale = 0;
        image.gameObject.SetActive(true);
    }
}
