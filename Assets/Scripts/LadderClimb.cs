using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class LadderClimb : MonoBehaviour
{

    public Transform chController;
    bool inside = false;
    public float speedUpDown = 0.2f;
    public FirstPersonController FPSInput;


    // Start is called before the first frame update
    void Start()
    {
        FPSInput = GetComponent<FirstPersonController>();
        inside = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Ladder"))
        {
            FPSInput.enabled = false;
            inside = !inside;
            Debug.Log("Is inside");
        }
    }


    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Ladder"))
        {
            FPSInput.enabled = true;
            inside = !inside;
            Debug.Log("Is Exit");
        }
    }
        

    // Update is called once per frame
    void Update()
    {


        if(inside == true && Input.GetKey(KeyCode.W))
        {
            chController.transform.position += Vector3.up * speedUpDown;

        }

        if(inside == true && Input.GetKey(KeyCode.S))
        {
            chController.transform.position += Vector3.down * speedUpDown;

        }

        if(Input.GetKey(KeyCode.L)) {
            inside = !inside;

        }
        
    }
}
