using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    Light testLight;
    public float minWaitTime;
    public float maxWaitTime;
    public float turnOffInterval;

    // Start is called before the first frame update
    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;
            yield return new WaitForSeconds(turnOffInterval);
            testLight.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}