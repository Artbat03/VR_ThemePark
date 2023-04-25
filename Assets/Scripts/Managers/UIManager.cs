using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Variables
    [SerializeField] private SpawnRings _spawnRings;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnValidate()
    {
        if (_spawnRings == null)
        {
            _spawnRings = FindObjectOfType<SpawnRings>();
        }
    }

    private void Update()
    {
        scoreText.text = ScoreManager.instance.Score.ToString("00");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
