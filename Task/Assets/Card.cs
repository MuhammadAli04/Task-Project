using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct CardData
{
    public int cardId;
    public bool isMatched;
}
public class Card : MonoBehaviour
{
    [SerializeField] private int cardId;
    [SerializeField] private Image cardFront;
    [SerializeField] private Image cardBack;
    private bool _isFlipped;
    private bool _isMatched;
    
    public int CardId => cardId;
    // Start is called before the first frame update
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButton);
        DisableAllImages();
    }

    private void OnEnable()
    {
        GameplayEventSystem.OnSetCardId += SetCardData;
    }

    private void OnDisable()
    {
        GameplayEventSystem.OnSetCardId -= SetCardData;
    }

    public void SetFlipStatus(bool f)
    {
        _isFlipped = f;
    }

    private void OnButton()
    {
        //Debug.Log(_isFlipped);
        if (!_isFlipped)
        {
            _isFlipped = true;
            FlipCard();
            StartCoroutine(FlipAnimation());
            GameplayEventSystem.CardFlipped(this);
        }
        
    }

    public void SetCardData(int id)
    {
        cardId = id;
    }

    public void SetCardSprites(Sprite s)
    {
        cardFront.sprite = s;
    }

    private void FlipCard()
    {
        DisableAllImages();
        EnableCardFrontImage();
    }

    public void UnFlipCard()
    {
       DisableAllImages();
       EnableCardBackImage();
    }
    
    

    public CardData GetCardData()
    {
        var cd = new CardData
        {
            cardId = cardId,
            isMatched = _isMatched
        };

        return cd;
    }
    

    public void IsMatched()
    {
        _isMatched = true;
        SaveCardState();
        DisableGameObject();
    }
    
    private IEnumerator FlipAnimation()
    {
        DisableCardImage();
        var duration = 0.5f;
        var elapsed = 0f;

        var startRotation = cardFront.transform.eulerAngles;
        var endRotation = new Vector3(startRotation.x, startRotation.y + 180f, startRotation.z);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            var t = Mathf.Clamp01(elapsed / duration);
            
            cardFront.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, t);

            yield return null;
        }

        cardFront.transform.eulerAngles = endRotation;
        EnableCardImage();
    }

    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }

    private void SaveCardState()
    {
        PlayerPrefs.SetInt("Card_" + cardId, _isMatched ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadCardState()
    {
        _isMatched = PlayerPrefs.GetInt("Card_" + cardId) == 1;
        if (_isMatched)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetCardState()
    {
        PlayerPrefs.SetInt("Card_" + cardId, 0);
    }
    
    
    private void EnableCardFrontImage()
    {
        cardFront.gameObject.SetActive(true);
    }
    
    private void EnableCardBackImage()
    {
        cardBack.gameObject.SetActive(true);
    }

    private void DisableAllImages()
    {
        cardFront.gameObject.SetActive(false);
        cardBack.gameObject.SetActive(false);
    }

    private void DisableCardImage()
    {
        var c = GetComponent<Image>();
        c.enabled = false;
    }
    
    private void EnableCardImage()
    {
        var c = GetComponent<Image>();
        c.enabled = true;
    }
    
}
