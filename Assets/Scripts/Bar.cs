using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour {
    
    public RectTransform bar;
    public int time;
    public Transform Water;



      
    void Start () {
        AnimateBar();
           }


       void Update () {
        updateBar();
        }

    public void AnimateBar()
            {
               
       }

    public static float mapRange(float inStart, float inEnd, float outStart, float outEnd, float value)
    {
        float scale = (outEnd - outStart) / (inEnd - inStart);
        return (outStart + ((value - inStart) * scale));
    }
    void updateBar()
    {
        float WaterLevel = Water.position.y;
        float BarLevel = mapRange(0f, 100f, -429f, 0, WaterLevel);
        bar.offsetMax = new Vector2(bar.offsetMax.x, BarLevel);
    }

}
