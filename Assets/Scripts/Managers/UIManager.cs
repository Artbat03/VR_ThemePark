using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Variables
    public static UIManager instance;

    [Header("TEXTS")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Space(15), Header("PANELS")]
    [SerializeField] private Transform allPlayCanvasParent;
    [SerializeField] private List<GameObject> playCanvas;
    [SerializeField] private GameObject gameCanvas;

    private void Awake()
    {
        instance = this;
        
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
        gameCanvas.SetActive(true);
        GameManager.instance.IsPlaying = true;
        GameManager.instance.NameStandTransform(standName);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowPlayPanels()
    {
        foreach (GameObject playCanvas in playCanvas)
        {
            playCanvas.SetActive(true);
        }
    }
    
    public void HidePlayPanels()
    {
        foreach (GameObject playCanvas in playCanvas)
        {
            playCanvas.SetActive(false);
        }
    }
}
