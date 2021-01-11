using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    #region fields
    static float screenTop;
    static float screenBot;
    static float screenLeft;
    static float screenRight;
    #endregion

    #region properties
    public static float ScreenTop
    {
        get { return screenTop; }
    }

    public static float ScreenBot
    {
        get { return screenBot; }
    }

    public static float ScreenLeft
    {
        get { return screenLeft; }
    }

    public static float ScreenRight
    {
        get { return screenRight; }
    }
    #endregion

    #region methods
    public static void Inizialize()
    {
        float screenZ = -Camera.main.transform.position.z;

        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBot = lowerLeftCornerWorld.y;

    }
    #endregion
}
