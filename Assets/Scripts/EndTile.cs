using UnityEngine;
using System.Collections;

public class EndTile : MonoBehaviour {

    void OnMouseEnter() {
        //Game is finished
        GameManager.Instance.gameFinished = true;

        //Disable End menu
        GameManager.Instance.endMenu.SetActive(true);

        //Stop the timer counting up
        GameManager.Instance.isTimerActive = false;

        //Deactivate the Flashlight
        GameManager.Instance.torch.enabled = false;
        GameManager.Instance.halo.GetType().GetProperty("enabled").SetValue(GameManager.Instance.halo, false, null);

        //Deactivate the End Tile and activate the Start Tile
        GameManager.Instance.endTile.SetActive(false);
        GameManager.Instance.startTile.SetActive(true);
    }
}
