using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour {

    public Text scoresText;
	
	void Update () {
        //Display text for when the End Menu is shown.
        scoresText.text = "Time Taken to Complete Level: " + GameManager.Instance.timer.ToString("F2") + " seconds \n" + "Number of Attempts at Level: " + GameManager.Instance.attempts + "\n\n" + "The node glows invitingly...";
	}
}
