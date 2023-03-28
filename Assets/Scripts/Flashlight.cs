using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light m_light;
    public bool drainsOverTime;
    public float maxBrightness, minBrightness, drainRate;

    void Start()
        => m_light = GetComponent<Light>();

    void Update()
    {
        m_light.intensity = Mathf.Clamp(m_light.intensity ,minBrightness, maxBrightness);

        if (drainsOverTime && m_light.enabled == true)
            if (m_light.intensity > minBrightness)
                m_light.intensity -= Time.deltaTime *(drainRate/1000);

        if (Input.GetKeyDown(KeyCode.F))
            m_light.enabled = !m_light.enabled;
    }
}
