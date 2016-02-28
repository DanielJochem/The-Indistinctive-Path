using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    Vector3 cursorPosition;
    float moveSpeed;
    float lightSpeed;

	void Start () {
        //The speed in which the light will lerp towards the mouse cursor
        moveSpeed = 0.4f;

        //The time it takes for the light to lerp the rotation when changing direction
        lightSpeed = 0.05f;
    }

    void Update() {
        cursorPosition = Input.mousePosition;

        //Lerp the light source towards the cursor position, allowing for the screen dimentions in the calculation
        transform.position = Vector3.Lerp(transform.position, new Vector3((-cursorPosition.x + (Screen.width / 2) + 0.3f) / (Screen.width / 23.7f), (cursorPosition.y - 540.0f) / 81, 0.2f), moveSpeed);

        //Horizontal axis of mouse movement, used in the calculation of the light rotation
        if(Input.GetAxis("Mouse X") > 0) {
             transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -120, 0), lightSpeed); //Move Right
        } else if(Input.GetAxis("Mouse X") < 0) {
             transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -240, 0), lightSpeed); //Move Left
        }

        //Vertical axis of mouse movement, used in the calculation of the light rotation
        if (Input.GetAxis("Mouse Y") > 0) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-80, 180, 360), lightSpeed); //Move Up
        } else if (Input.GetAxis("Mouse Y") < 0) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(80, 180, 360), lightSpeed); //Move Down
        }

        //Rotate the light to the default position if the cursor is still
        if(Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), lightSpeed);
        }
    }
}
