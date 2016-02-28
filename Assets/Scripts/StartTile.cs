using UnityEngine;
using System.Collections;

public class StartTile : MonoBehaviour {

    void OnMouseEnter() {
        //Disable Start, End and Outta Time menus (only 1 will be active at a time)
        GameManager.Instance.startMenu.SetActive(false);
        GameManager.Instance.endMenu.SetActive(false);
        GameManager.Instance.outtaTimeMenu.SetActive(false);

        //Reset UI variables if you had previously finished the game
        if (GameManager.Instance.gameFinished || GameManager.Instance.outtaTime)
        {
            GameManager.Instance.timer = 0.0f;
            GameManager.Instance.attempts = 0;
            GameManager.Instance.gameFinished = false;
            GameManager.Instance.outtaTime = false;
        }

        //Turn the Flashlight on
        GameManager.Instance.torch.enabled = true;
        GameManager.Instance.halo.GetType().GetProperty("enabled").SetValue(GameManager.Instance.halo, true, null);
        GameManager.Instance.torch.intensity = 8.0f;

        //Turn the End Tile on
        GameManager.Instance.endTile.SetActive(true);

        //Turn timer on
        GameManager.Instance.isTimerActive = true;

        //Start your first attempt (there will be many more to follow)
        GameManager.Instance.attempts += 1;

        //You are back up now
        GameManager.Instance.fellOff = false;

        //Disable self
        this.gameObject.SetActive(false);  
    }
}
