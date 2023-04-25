using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RisingScript : MonoBehaviour
{
    public float waterRisingRate = 0.02f;
    public Transform BoxCollider;
   
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3 (0f, waterRisingRate, 0f) * Time.deltaTime;
        BoxCollider.transform.position = BoxCollider.position + new Vector3(0f, waterRisingRate, 0f) * Time.deltaTime;

    }
}
