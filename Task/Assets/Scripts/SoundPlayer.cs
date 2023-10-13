using System;
using Unity.VisualScripting;
using UnityEngine;
public class SoundPlayer : MonoBehaviour
{
   public static SoundPlayer Instance;
   public GameObject soundManager;
   
   private void Start()
   {
      if (SoundManager.Instance == null)
      {
         Instantiate(soundManager);
      }
   }

   private void OnEnable()
   {
      Instance = this;
   }

   public void PlayButtonSound()
   {
      SoundManager.Instance.PlayBtnSound();
   }

   public void PlayUnMatchedSound()
   {
      SoundManager.Instance.UnMatchedSound();
   }

   public void PlayMatchedSound()
   {
      SoundManager.Instance.MatchedSound();
   }

   public void PlayFlipSound()
   {
      SoundManager.Instance.FlipSound();
   }

   public void PlayBackFlipSound()
   {
      SoundManager.Instance.BackFlipSound();
   }

   public void PlayLevelCompleteSound()
   {
      SoundManager.Instance.LevelCompleteSound();
   }
}
