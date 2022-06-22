using UnityEngine;

public sealed class EditorGrid 
{

    private const float LeftPosition = -10f;
    private const float RightPosition = 7f;
    
    private const float DownPosition = -5f;
    private const float UpPosition = 11f;

    public bool CheckPosition(Vector2 position)
    {
        if (position.y >= DownPosition && position.y <= UpPosition)
        {
            if(position.x <= RightPosition && position.x >= LeftPosition)
            {
                if (IsEmpty(position))
                {
                    return true;
                }
            }
        }
        Debug.LogWarning("Position is not in Grid or grid already contains position!");
        return false;
    }
    private bool IsEmpty(Vector2 position)
    {
        Collider2D collider = Physics2D.OverlapCircle(position, 0.01f);
        return collider == null;
    }
}
