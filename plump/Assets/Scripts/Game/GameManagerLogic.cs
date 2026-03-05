using UnityEngine;

public class GameManagerLogic : MonoBehaviour
{
    public static GameManagerLogic Instance { get; private set; }

    public int totalItemCount;
    public int stage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}