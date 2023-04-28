using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    public static WaterBehavior Instance { get; private set; }
    public float waterRisingRate = 0.02f;
    public float initialLevel, maxLevel;
    public float currentLevel;


    void Awake() => Instance = this;
    void Start()
    {
        initialLevel = transform.position.y;
        currentLevel = initialLevel;
        maxLevel = 37.5f;
    } 
    void Update()
    {
        if ( currentLevel >= initialLevel && currentLevel < maxLevel)
            raiseWaterLevel();
    }

    void raiseWaterLevel()
    {
        currentLevel += waterRisingRate * Time.deltaTime;
        transform.position = new Vector3(0, currentLevel, 0);
    }
}
