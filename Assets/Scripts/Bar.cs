using UnityEngine;

public class Bar : MonoBehaviour 
{    
    public RectTransform bar;
    WaterBehavior water;

    void Awake()
    {
        bar = transform.GetChild(0).GetComponent<RectTransform>();
        water = WaterBehavior.Instance;
    } 

    float getBarBottom()
    {
        return 0;
    }

    float getBarTop()
    {
        return 135.22f;
    }

    void Update () => updateBar();

    void updateBar()
    {
        float BarLevel = mapRange(water.initialLevel, water.maxLevel, getBarBottom(), getBarTop(), WaterBehavior.Instance.currentLevel);
        bar.sizeDelta = new Vector2(bar.offsetMax.x, BarLevel);
    }

    public static float mapRange(float inStart, float inEnd, float outStart, float outEnd, float value)
    {
        float scale = (outEnd - outStart) / (inEnd - inStart);
        return (outStart + ((value - inStart) * scale));
    }
}
