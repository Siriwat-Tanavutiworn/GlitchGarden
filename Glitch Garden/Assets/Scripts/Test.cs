using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefController.GetMasterVolume();
        Debug.Log("Value is " + PlayerPrefController.GetMasterVolume());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
