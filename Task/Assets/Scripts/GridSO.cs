
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GridSO")]
public class GridSO : ScriptableObject
{
   [SerializeField] public int rows;
   [SerializeField] public int columns;
   [SerializeField] public int topPadding;
   [SerializeField] public Vector2 spacing;

   public GridSO(int rows, int columns, int topPadding, Vector2 spacing)
   {
      this.rows = rows;
      this.columns = columns;
      this.topPadding = topPadding;
      this.spacing = spacing;
   }
}
