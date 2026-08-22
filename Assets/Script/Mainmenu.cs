using UnityEngine;
using UnityEngine.SceneManger;

public class Mainmenu : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        SceneManger.loadScene("Scene01")
    }

    public void ExitGame()
    {
        application.stop()
    }
}
