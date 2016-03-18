using UnityEngine;
using System.Collections;

public class GameManager : SingletonBehaviour<GameManager> {

    public float timer;
    public int attempts;
    public bool isTimerActive;
    public bool gameFinished;
    public bool outtaTime;
    public bool fellOff;
    public float randSoundCountdown;

    public Light torch;
    public Component halo;

    public GameObject startMenu;
    public GameObject endMenu;
    public GameObject outtaTimeMenu;
    public GameObject startTile;
    public GameObject endTile;
    public GameObject flashlight;
    public GameObject blood;

	void Start () {
        //Set variables for timer and attempts
        timer = 0.0f;
        attempts = 0;
        gameFinished = true;
        outtaTime = false;
        fellOff = false;
        randSoundCountdown = 15.0f;

        //Setup for the flashlight being turned on and off
        torch.enabled = false;
        halo = flashlight.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);

        //Set the timer to not count up on startup
        isTimerActive = false;
	}
	
	void Update () {
	    if(isTimerActive) {
            //If isimerActive variable is true, count up the seconds!
            timer += Time.deltaTime;
        }

        if (!gameFinished && !fellOff) {
            if (torch.intensity > 0.25f) {
                torch.intensity -= Time.deltaTime * 0.09f;
            } else {
                //Ran out of time
                outtaTime = true;

                //Disable End menu
                outtaTimeMenu.SetActive(true);

                //Stop the timer counting up
                isTimerActive = false;

                //Deactivate the Flashlight
                torch.enabled = false;
                halo.GetType().GetProperty("enabled").SetValue(GameManager.Instance.halo, false, null);

                //Deactivate the End Tile and activate the Start Tile
                endTile.SetActive(false);
                startTile.SetActive(true);
            }

            //Random sounds coming from whatever lurks in the darkness
            if(randSoundCountdown > 0.0f) {
                randSoundCountdown -= Time.deltaTime;
            } else {
                AudioManager.Instance.RandomAudioSound();
                randSoundCountdown = 15.0f;
            }
        }
    }
}
