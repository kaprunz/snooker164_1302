using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] bgm;
    [SerializeField]    
    private AudioSource[] sfx;
    [SerializeField]
    private AudioMixer mixer;
    public static AudioManager Instance;

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StopAllBGM()
    {
        foreach (AudioSource audio in bgm)
        {
            audio.Stop();
        }
    }

    public void PlayBGM(int index)
    {
        StopAllBGM();
        if (index < bgm.Length)
            bgm[index].Play();
    }

    public void PlaySFX(int index)
    {
        if (index < sfx.Length)
            sfx[index].PlayOneShot(sfx[index].clip);
    }
}
