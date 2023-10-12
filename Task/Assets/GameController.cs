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

    
    private void OnEnable()
    {
        GameplayEventSystem.OnCardFlipped += CardFlipped;
        GameplayEventSystem.OnGameStart += InIt;
        GameplayEventSystem.OnResetCardState += ResetCardState;
    }

    private void OnDisable()
    {
        GameplayEventSystem.OnCardFlipped -= CardFlipped;
        GameplayEventSystem.OnGameStart -= InIt;
        GameplayEventSystem.OnResetCardState -= ResetCardState;
    }
    private void InIt()
    {
        GameplayEventSystem.LoadCard();
        LoadCardState();
        GameplayEventSystem.UpdateScoreText(Prefs.Score);
    }

    private void LoadCardState()
    {
        var count = cardGridHandler.cards.Count;
        for (var i = 0; i < count; i++)
        {
            cardGridHandler.cards[i].LoadCardState();
        }
    }

    private void ResetCardState()
    {
        var count = cardGridHandler.cards.Count;
        for (var i = 0; i < count; i++)
        {
            cardGridHandler.cards[i].ResetCardState();
        }
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
            var s=Prefs.Score += 1;
            Debug.Log(s);
            GameplayEventSystem.UpdateScoreText(s);
            CheckGameStatus();
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
    }

    private void CheckGameStatus()
    {
        var pairs = cardGridHandler.GetTotalPairs();
        var score = Prefs.Score;
        if (score == pairs)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("GameComplete");
        }
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
