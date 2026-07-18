using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public static Game_Manager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
