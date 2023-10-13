using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
public enum Layout
{
    Layout2X2,
    Layout2X3,
    Layout5X6
}
public class CardGridHandler : MonoBehaviour
{
    
    private Layout layout;
    [SerializeField] private GridSO layoutOne;
    [SerializeField] private GridSO layoutTwo;
    [SerializeField] private GridSO layoutThree;
    [SerializeField] private GameObject card;

    [SerializeField] private Sprite[] cardSprites;

    [SerializeField] private Transform cardGrid;
    [SerializeField] private CardGridLayoutHandler cardGridLayoutHandler;
    private GridSO _gridSo;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        GameplayEventSystem.OnLoadCard += LoadCards;
        GameplayEventSystem.OnSetLayout += SetLayout;
    }

    private void OnDisable()
    {
        GameplayEventSystem.OnLoadCard -= LoadCards;
        GameplayEventSystem.OnSetLayout -= SetLayout;
    }
    
    private void LoadCards()
    {
        cardGridLayoutHandler.SetRowsColumnsValue(_gridSo.rows,_gridSo.columns,_gridSo.topPadding,_gridSo.spacing,_gridSo.gridPosition);
        var cardsCount = _gridSo.rows * _gridSo.columns;
        
        var cardIDs = GenerateRandomCardIDs(cardsCount / 2);
        Shuffle(cardIDs);
        InstantiateCards(cardIDs);
    }

    public void SetLayout(Layout lo)
    {
        layout = lo;
        switch (layout)
        {
            case Layout.Layout2X2:
                _gridSo = layoutOne;
                break;
            case Layout.Layout2X3:
                _gridSo = layoutTwo;
                break;
            case Layout.Layout5X6:
                _gridSo = layoutThree;
                break;
        } 
    }

    public int GetTotalPairs()
    {
        return (_gridSo.rows * _gridSo.columns) / 2;
    }
    
    private List<int> GenerateRandomCardIDs(int paris)
    {
        var cardIDs = new List<int>();

        for (var i = 0; i < paris; i++)
        {
            cardIDs.Add(i);
            cardIDs.Add(i);
        }

        return cardIDs;
    }

    private void Shuffle(IList<int> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public List<Card> cards = new List<Card>();

    private void InstantiateCards(List<int> cardIDs)
    {
        foreach (var t in cardIDs)
        {
            var o = Instantiate(card,cardGrid,false);
            var c = o.GetComponent<Card>();
            cards.Add(c);
            c.SetCardData(t);
            c.SetCardSprites(cardSprites[t]);
        }
        
        Invoke(nameof(DisableGridComponent),1f);
    }
    
    
    
    private void DisableGridComponent()
    {
        var g = cardGrid.GetComponent<CardGridLayoutHandler>();
        g.enabled = false;
    }
    

    
}
