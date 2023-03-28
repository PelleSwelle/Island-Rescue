using UnityEngine;

public class Bar : MonoBehaviour 
{    
    public RectTransform bar;
    public Transform Water;

    void Update () 
    {
        updateBar();
    }

    void updateBar()
    {
        float WaterLevel = Water.position.y;
        float BarLevel = mapRange(0f, 10f, -327f, 0, WaterLevel);
        bar.offsetMax = new Vector2(bar.offsetMax.x, BarLevel);
    }

    public static float mapRange(float inStart, float inEnd, float outStart, float outEnd, float value)
    {
        float scale = (outEnd - outStart) / (inEnd - inStart);
        return (outStart + ((value - inStart) * scale));
    }
}
