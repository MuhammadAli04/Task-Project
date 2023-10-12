
using UnityEngine;
using UnityEngine.UI;

public class CardGridLayoutHandler : LayoutGroup
{
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private Vector2 cardSize;
    [SerializeField] private Vector2 spacing;
    [SerializeField] private int topPadding;
    
    public override void CalculateLayoutInputVertical()
    {
        base.CalculateLayoutInputHorizontal();
        if (rows == 0 || columns == 0)
        {
            rows = 5;
            columns = 6;
        }
        
        var rect = rectTransform.rect;
        var pWidth = rect.width;
        var pHeight = rect.height;

        var cHeight = (pHeight - 2 * topPadding -  (rows - 1) * spacing.y) / rows;
        var cWidth = cHeight;

        cardSize.x = cWidth;
        cardSize.y = cHeight;

        padding.left = Mathf.FloorToInt((pWidth - columns * cHeight) / 2);
        padding.top = Mathf.FloorToInt((pHeight - rows * cWidth) / 2);
        padding.bottom = padding.top;
        
        for (var i = 0; i < rectChildren.Count; i++)
        {
             var rowCount = i / columns;
             var columnCount = i % columns;

            var item = rectChildren[i];
            var xPos = padding.left + cardSize.x * columnCount + spacing.x * (columnCount);
            var yPos = padding.top + cardSize.y * rowCount + spacing.y * (rowCount);
            
            SetChildAlongAxis(item,0,xPos,cardSize.x);
            SetChildAlongAxis(item,1,yPos,cardSize.y);
        }
    }

    public void SetRowsColumnsValue(int r, int c, int p, Vector2 s,Vector2 gp)
    {
        rows = r;
        columns = c;
        topPadding = p;
        spacing = s;
        transform.localPosition = gp;
    }

    public override void SetLayoutHorizontal()
    {
   
    }

    public override void SetLayoutVertical()
    {
    
    }
}
