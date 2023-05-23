using UnityEngine;

public class BottlesManager : MonoBehaviour
{
    // Variables
    public static BottlesManager instance;
    
    [SerializeField] private int pinkRingsInScene;
    [SerializeField] private int yellowRingsInScene;
    [SerializeField] private int blueRingsInScene;
    
    #region GETTERS && SETTERS

    public int PinkRingsInScene
    {
        get => pinkRingsInScene;
        set => pinkRingsInScene = value;
    }
    
    public int YellowRingsInScene
    {
        get => yellowRingsInScene;
        set => yellowRingsInScene = value;
    }public int BlueRingsInScene
    {
        get => blueRingsInScene;
        set => blueRingsInScene = value;
    }

    #endregion

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            CheckRingsInScene();
        }
    }

    public void CheckRingsInScene()
    {
        if (pinkRingsInScene <= 0 && GameManager.instance.NameStand == "RingsStandLevel1")
        {
            GameManager.instance.isPlaying = false;
            GameManager.instance.NameStand = null;

            if (!ScoreManager.instance.RingsToyReached)
            {
                ScoreManager.instance.CheckScoreForReward();
            }
        }
        else if (yellowRingsInScene <= 0 && GameManager.instance.NameStand == "RingsStandLevel2")
        {
            GameManager.instance.isPlaying = false;
            GameManager.instance.NameStand = null;

            if (!ScoreManager.instance.RingsToyReached)
            {
                ScoreManager.instance.CheckScoreForReward();
            }
        }
        else if (blueRingsInScene <= 0 &&  GameManager.instance.NameStand == "RingsStandLevel3")
        {
            GameManager.instance.isPlaying = false;
            GameManager.instance.NameStand = null;

            if (!ScoreManager.instance.RingsToyReached)
            {
                ScoreManager.instance.CheckScoreForReward();
            }
        }
    }
}
