using UnityEngine;

public class RisingScript : MonoBehaviour
{
    public float waterRisingRate = 0.02f;
   
    void Update()
         => transform.position = this.transform.position + new Vector3 (0f, waterRisingRate, 0f) * Time.deltaTime;
}
