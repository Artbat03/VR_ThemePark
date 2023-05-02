using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Variables
    [Header("TEXTS")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Space(15), Header("PANELS")]
    [SerializeField] private Transform allPlayCanvasParent;
    [SerializeField] private List<GameObject> playCanvas;
    [SerializeField] private GameObject gameCanvas;

    private void Awake()
    {
        if (allPlayCanvasParent != null)
        {
            for (int i = 0; i < allPlayCanvasParent.childCount; i++)
            {
                playCanvas.Add(allPlayCanvasParent.GetChild(i).gameObject);
            }
        }
    }

    private void Update()
    {
        scoreText.text = ScoreManager.instance.Score.ToString("00");
    }

    public void Play(string standName)
    {
        HidePlayPanels();
        gameCanvas.SetActive(true);
        GameManager.instance.IsPlaying = true;
        GameManager.instance.NameStandTransform(standName);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HidePlayPanels()
    {
        foreach (GameObject playCanvas in playCanvas)
        {
            playCanvas.SetActive(false);
        }
    }
}
