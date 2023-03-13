using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
/*
        Debug.Log (this.transform.position.x);
        Debug.Log (this.transform.position.y);
        Debug.Log (this.transform.position.z);

        this.transform.position.x = 10f;
        this.transform.position.y = 0f;
        this.transform.position.z = 0f;
        */

        // this.transform.position = new Vector3(0f,13f,0f);

        

    }

    // Update is called once per frame
    void Update()
    {
    this.transform.position = this.transform.position + new Vector3 (0f, 0.02f, 0f) * Time.deltaTime;
    
    }
}
