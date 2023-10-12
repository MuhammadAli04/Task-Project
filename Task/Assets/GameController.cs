using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float cardDelayTime = 1f;
    private Card _firstCard;
    private Card _secondCard;

    private bool _canFlip = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (_firstCard.CardId == _secondCard.CardId)
        {
            Debug.Log("Matched");
            yield return new WaitForSeconds(cardDelayTime);
            _firstCard.gameObject.SetActive(false);
            _secondCard.gameObject.SetActive(false);
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

        _canFlip = true;
    }
}
