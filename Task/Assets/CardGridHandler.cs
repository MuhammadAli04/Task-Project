using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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

    
    public void GenerateCard()
    {
        cardGridLayoutHandler.SetRowsColumnsValue(_gridSo.rows,_gridSo.columns,_gridSo.topPadding,_gridSo.spacing);
        var cardsCount = _gridSo.rows * _gridSo.columns;

        for (int i = 0; i < cardsCount; i++)
        {
            Instantiate(card, cardGrid, false);
        }
    }


    
}
