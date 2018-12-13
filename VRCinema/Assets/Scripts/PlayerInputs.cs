using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class PlayerInputs : MonoBehaviour {
    public GameObject keyboard;
    private bool isOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Show Keyboard
		if(OVRInput.GetDown(OVRInput.Button.Start)) {
            isOpen = !isOpen;
            keyboard.SetActive(isOpen);
        }
    }
}
