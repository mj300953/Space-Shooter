using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    
    private int _scoreNumber;

    private void Start()
    {
        _scoreNumber = 0;
        scoreText.text = _scoreNumber.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            _scoreNumber += 1;
            Destroy(col.gameObject);
            scoreText.text = _scoreNumber.ToString();
        }
        
        if (col.CompareTag("BigCoin"))
        {
            _scoreNumber += 50;
            Destroy(col.gameObject);
            scoreText.text = _scoreNumber.ToString();
        }
    }
}
