using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score = 0;
    private float scoref = 0;
	
	// Update is called once per frame
	void Update () {
        scoref += (Time.deltaTime * GameObject.Find("player").GetComponent<Player>().fallSpeed);
        score = (int)scoref;
        this.GetComponent<Text>().text = score.ToString();
    }
}
