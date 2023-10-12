using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private int cardId;
    [SerializeField] private Image cardFront;
    [SerializeField] private Image cardBack;
    [SerializeField] private bool isFlipped;

    public int CardId => cardId;
    // Start is called before the first frame update
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButton);
    }

    private void OnEnable()
    {
        GameplayEventSystem.OnSetCardId += SetCardData;
    }

    private void OnDisable()
    {
        GameplayEventSystem.OnSetCardId -= SetCardData;
    }

    public void OnButton()
    {
        FlipCard();
        GameplayEventSystem.CardFlipped(this);
    }

    public void SetCardData(int id)
    {
        cardId = id;
    }

    private void FlipCard()
    {
        DisableAllImages();
        EnableCardFrontImage();
        isFlipped = true;
    }

    public void UnFlipCard()
    {
       DisableAllImages();
       EnableCardBackImage();
       isFlipped = false;
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
}
