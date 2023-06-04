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
        if (ringsInScene <= 0 && GameManager.instance.NameStand == "RingsStand")
        {
            GameManager.instance.isPlaying = false;
            GameManager.instance.NameStand = null;

            AudioManager.instance.PlayMusic(AudioManager.instance.listaAudio[1]);
            
            if (!ScoreManager.instance.RingsToyReached)
            {
                ScoreManager.instance.CheckScoreForReward();
            }
            
            Destroy(GameObject.FindGameObjectWithTag("Game").gameObject);
        }
    }
}
