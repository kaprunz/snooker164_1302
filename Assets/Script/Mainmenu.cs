using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    [SerializeField]
    private GameObject adjustPanel;

    [SerializeField]
    private Slider volumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeSlider.value = AudioManager.Instance.LoadCurrentMasterVolume();

        AudioManager.Instance.PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        Setting.fromSave = false;
        SceneManager.LoadScene("Loading");
    }

    public void LoadSavedGame()
    {
        Setting.fromSave = true;
        SceneManager.LoadScene("Loading");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void showHideAdjustPanel(bool flag)
    {
        adjustPanel.SetActive(flag);
    }

    public void SetVolume(float volume)
    {
        AudioManager.Instance.AdjustMasterVolume(volume);
    }
}
