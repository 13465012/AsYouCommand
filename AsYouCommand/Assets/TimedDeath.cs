using UnityEngine;
using System.Collections;

public class TimedDeath : MonoBehaviour {

    public float StartTime;
    private float currentTime;

	// Use this for initialization
	void Start () {
        currentTime = StartTime;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
            Destroy(this.gameObject);
	}
}
