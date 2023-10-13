
using UnityEngine;
using UnityEngine.Serialization;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public AudioSource btnSound;
    public AudioSource flipSound;
    public AudioSource backFlipSound;
    public AudioSource matchedSound;
    public AudioSource unMatchedSound;
    public AudioSource levelCompleteSound;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
    

    public void PlayBtnSound()
    {
        if (!btnSound) return;
        btnSound.Play();
    }

    public void FlipSound()
    {
        if (!flipSound) return;
        flipSound.Play();
    }

    public void BackFlipSound()
    {
        if (!backFlipSound) return;
        backFlipSound.Play();
    }

    public void MatchedSound()
    {
        if (!matchedSound) return;
        matchedSound.Play();
    }

    public void UnMatchedSound()
    {
        if (!unMatchedSound) return;
        unMatchedSound.Play();
    }

    public void LevelCompleteSound()
    {
        if(!levelCompleteSound) return;
        levelCompleteSound.Play();
    }
}
