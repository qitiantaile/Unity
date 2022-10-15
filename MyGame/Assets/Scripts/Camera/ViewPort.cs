using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPort : Singleton<ViewPort>
{
    float minX;
    float maxX;
    float minY;
    float maxY;

    private void Start()
    {
        Camera mainCamera = Camera.main;

        Vector2 bottomleft = mainCamera.ViewportToWorldPoint(new Vector3(0f,0f));
        Debug.Log(bottomleft);
        Vector2 topright = mainCamera.ViewportToWorldPoint(new Vector3(1f,1f));
        Debug.Log(topright);
        minX = bottomleft.x;
        minY = bottomleft.y;
        maxX = topright.x;
        maxY = topright.y;
    }

    public Vector3 PlayerMoveablePosition(Vector3 PlayerPosition,float paddingX,float paddingY)
    {
        Vector3 position = Vector3.zero;
        //Mathf.Clamp函数可将浮点数限制在一个区间内
        position.x = Mathf.Clamp(PlayerPosition.x, minX + paddingX, maxX - paddingX);
        position.y = Mathf.Clamp(PlayerPosition.y, minY + paddingY, maxY - paddingY);

        return position;
    }
}
