using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

public class CardGridHandler : MonoBehaviour
{
    public enum Layout
    {
       Layout2X2,
       Layout2X3,
       Layout5X6
    }

    [SerializeField] private Layout layout;
    [SerializeField] private GridSO layoutOne;
    [SerializeField] private GridSO layoutTwo;
    [SerializeField] private GridSO layoutThree;
    [SerializeField] private GameObject card;

    [SerializeField] private Transform cardGrid;
    [SerializeField] private CardGridLayoutHandler cardGridLayoutHandler;
    private GridSO _gridSo;
    
    // Start is called before the first frame update
    void Start()
    {
        CheckLayout();

    }

    private void CheckLayout()
    {
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

    public List<Card> _cardsList = new List<Card>();
    private int temp;
    public void GenerateCard()
    {
        cardGridLayoutHandler.SetRowsColumnsValue(_gridSo.rows,_gridSo.columns,_gridSo.topPadding,_gridSo.spacing);
        var cardsCount = _gridSo.rows * _gridSo.columns;
        
        var cardIDs = GenerateRandomCardIDs(cardsCount / 2);
        Shuffle(cardIDs);
        InstantiateCards(cardIDs);
        
        /*for (int i = 0; i < cardsCount / 2; i++)
        {
            var g1 = Instantiate(card, cardGrid, false);
            var c1 = g1.GetComponent<Card>();
            c1.SetCardData(i);
            
            var g2 = Instantiate(card, cardGrid, false);
            var c2 = g2.GetComponent<Card>();
            c2.SetCardData(i);
            
            _cardsList.Add(c1);
            _cardsList.Add(c2);
        }*/
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

    private void InstantiateCards(List<int> cardIDs)
    {
        foreach (var t in cardIDs)
        {
            var c = Instantiate(card,cardGrid,false);
            c.GetComponent<Card>().SetCardData(t);
        }
        
        Invoke(nameof(DisableGridComponent),1f);
    }
    
    private void DisableGridComponent()
    {
        var g = cardGrid.GetComponent<CardGridLayoutHandler>();
        g.enabled = false;
    }
    

    
}
