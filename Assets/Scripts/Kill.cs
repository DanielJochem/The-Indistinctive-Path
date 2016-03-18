using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {

    public int randRotation;

    void OnMouseEnter() {
        if (!GameManager.Instance.startTile.activeSelf) {
            //Death sound
            AudioManager.Instance.DeathAudioSound();

            //Randomly generate a number for the rotation of the blood pool
            randRotation = Random.Range(0, 360);
            Instantiate(GameManager.Instance.blood, new Vector3((-Input.mousePosition.x + (Screen.width / 2) + 0.3f) / (Screen.width / 23.7f), (Input.mousePosition.y - 540.0f) / 81, 0.05f), Quaternion.Euler(randRotation, 0, 0));

            //Disable End Tile (so you don't cheat)
            GameManager.Instance.endTile.SetActive(false);

            //Turn the Flashlight off
            GameManager.Instance.torch.enabled = false;
            GameManager.Instance.halo.GetType().GetProperty("enabled").SetValue(GameManager.Instance.halo, false, null);

            //Oh no, you went off the path
            GameManager.Instance.fellOff = true;

            //Turn the Start Tile back on
            GameManager.Instance.startTile.SetActive(true);
        }
    }
}
