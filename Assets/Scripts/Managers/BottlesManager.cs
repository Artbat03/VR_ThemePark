using UnityEngine;

public class BottlesManager : MonoBehaviour
{
    // Variables
    public static BottlesManager instance;
    
    [SerializeField] private int ringsInScene;
    
    #region GETTERS && SETTERS

    public int RingsInScene
    {
        get => ringsInScene;
        set => ringsInScene = value;
    }

    #endregion

    void Awake()
    {
        instance = this;

        ringsInScene = GameObject.FindGameObjectsWithTag("Ring").Length;
    }

    private void Update()
    {
        CheckDartsInScene();
    }

    public void CheckDartsInScene()
    {
        if (ringsInScene <= 0)
        {
            GameManager.instance.IsPlaying = false;

            if (!ScoreManager.instance.RingsToyReached)
            {
                ScoreManager.instance.CheckScoreForReward();
            }
        }
    }
}
