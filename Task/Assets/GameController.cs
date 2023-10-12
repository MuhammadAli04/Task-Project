using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GameController : MonoBehaviour
{
    [SerializeField] private float cardDelayTime = 1f;
    [SerializeField] private CardGridHandler cardGridHandler;
    private Card _firstCard;
    private Card _secondCard;

    private bool _canFlip = true;

    private string _savePathFile;
    // Start is called before the first frame update
    void Awake()
    {
        _savePathFile = Application.persistentDataPath + "/cardData.json";
    }

    private void Start()
    {
        
    }
    
    public void InIt()
    {
        GameplayEventSystem.LoadCard();
        LoadCardState();
    }

    private void LoadCardState()
    {
        var count = cardGridHandler.cards.Count;
        for (var i = 0; i < count; i++)
        {
            cardGridHandler.cards[i].LoadCardState();
        }
    }

    private void OnEnable()
    {
        GameplayEventSystem.OnCardFlipped += CardFlipped;
    }

    private void OnDisable()
    {
        GameplayEventSystem.OnCardFlipped -= CardFlipped;
    }

    public bool CanFlip()
    {
        return _canFlip;
    }

    private void CardFlipped(Card c)
    {
        if (_firstCard == null)
        {
            _firstCard = c;
        }
        else
        {
            _secondCard = c;
            _canFlip = false;
            StartCoroutine(CardMatchingRoutine());
        }
    }

    private IEnumerator CardMatchingRoutine()
    {
        DisableFlipStatus();
        if (_firstCard.CardId == _secondCard.CardId)
        {
            Debug.Log("Matched");
            yield return new WaitForSeconds(cardDelayTime);
            _firstCard.gameObject.SetActive(false);
            _secondCard.gameObject.SetActive(false);
            HandleMatch(_firstCard,_secondCard);
        }
        else
        {
            Debug.Log("UnMatched");
            yield return new WaitForSeconds(cardDelayTime);
            _firstCard.UnFlipCard();
            _secondCard.UnFlipCard();
           
        }
        _firstCard = null;
        _secondCard = null;
        EnableFlipStatus();
        _canFlip = true;
    }

    private void DisableFlipStatus()
    {
        foreach (var c in cardGridHandler.cards)
        {
            c.SetFlipStatus(true);
        }
    }
    private void EnableFlipStatus()
    {
        foreach (var c in cardGridHandler.cards)
        {
            c.SetFlipStatus(false);
        }
    }


    private void HandleMatch(Card card1, Card card2)
    {
        card1.IsMatched();
        card2.IsMatched();
    }
    
}
