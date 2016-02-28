using UnityEngine;
using System.Collections;

public class Bleed : MonoBehaviour {

    public float timeTillDespawn;

	// Use this for initialization
	void Start () {
        timeTillDespawn = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeTillDespawn > 0.0f) {
            timeTillDespawn -= Time.deltaTime;
        } else {
            Destroy(this.gameObject);
        }
	}
}
