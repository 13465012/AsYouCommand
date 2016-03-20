using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

    public float DeathTimer = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DeathTimer -= 1 * Time.deltaTime;
        if (DeathTimer < 0)
            End();
	}

    void End()
    {
        GameObject.Find("player").GetComponent<Player>().EndGame();
    }
}
