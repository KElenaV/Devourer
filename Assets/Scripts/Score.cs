using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private PlayerCollision _player;
    [SerializeField] private TMP_Text _scoreDisplay;

    private int _score = 0;

    private void OnEnable() => _player.Eated += OnPlayerEated;

    private void OnDisable() => _player.Eated -= OnPlayerEated;

    private void OnPlayerEated() => _scoreDisplay.text = $"Score: {++_score}";
}
