using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    Vector3 cursorPosition;
    float moveSpeed;

	// Use this for initialization
	void Start () {
        moveSpeed = 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
        cursorPosition = Input.mousePosition;
        transform.position = Vector3.Lerp(transform.position, new Vector3((-cursorPosition.x + (Screen.width / 2)) / (Screen.width / 23), (cursorPosition.y - 540.0f) / 85.5f, 0.2f), moveSpeed);
    }
}
