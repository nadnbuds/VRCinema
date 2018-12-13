using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // The force applied to the character when jumping.
    public float jumpHeight = 2f;

	// Snap turn rotation
	public float rotationAngle = 25.0f;

	// This bool is set to true whenever the player controller has been teleported. It is reset after every frame. Some systems, such as
	// CharacterCameraConstraint, test this boolean in order to disable logic that moves the character controller immediately
	// following the teleport.
	public bool Teleported;

	// When true, user input will be applied to rotation. Set this to false whenever the player controller needs to ignore input for rotation.
	public bool EnableRotation = true;

	protected Rigidbody PlayerControl;

	private float Speed = 5f;
	private bool  HaltUpdateMovement = false;
	private bool ReadyToSnapTurn = true; // Set to true when a snap turn has occurred, code requires one frame of centered thumbstick to enable another snap turn.

	Vector3 lhStick = Vector3.zero;
    Vector2 lhInput;
    Vector2 rhStick;

	// Use this for initialization
	void Start () {
        PlayerControl = GetComponent<Rigidbody>();
        PlayerControl.velocity = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        lhInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        lhStick.x = lhInput.x;
        lhStick.z = lhInput.y;
        rhStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //Debug.Log("Right Stick: " + rhStick.ToString("F5"));
        //Debug.Log("Left Stick: " + lhInput.ToString("F5"));
    }

	void FixedUpdate () {
        // Directional Movement
        Vector3 MoveDir = transform.TransformDirection(lhStick * Speed * Time.fixedDeltaTime);
        PlayerControl.MovePosition(PlayerControl.position + MoveDir);
        
        if (rhStick.x <= -0.25 && ReadyToSnapTurn)
        {
            ReadyToSnapTurn = false;
            PlayerControl.rotation = (PlayerControl.rotation * Quaternion.Euler(0, rotationAngle * -1f, 0));
            Debug.Log("Rotate Left");
        }
        else if (rhStick.x >= 0.25 && ReadyToSnapTurn)
        {
            ReadyToSnapTurn = false;
            PlayerControl.rotation = (PlayerControl.rotation * Quaternion.Euler(0, rotationAngle, 0));
            Debug.Log("Rotate Right");
        }

        if (!ReadyToSnapTurn && rhStick.x < 0.25 && rhStick.x > -0.25)
        {
            ReadyToSnapTurn = true;
        }
    }
}
