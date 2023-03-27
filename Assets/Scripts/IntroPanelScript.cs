using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanelScript : MonoBehaviour
{
    public GameObject IntroBox;


    public void Start()
    {
        


    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(IntroBox);

        }


    }
}
