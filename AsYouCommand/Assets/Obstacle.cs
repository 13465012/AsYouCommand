using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public GameObject cloud;
    private Vector3 newpos;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(0.0f, (0.5f * Time.deltaTime * GameObject.Find("player").GetComponent<Player>().fallSpeed), 0.0f);
        if(this.gameObject.transform.position.y > 5.5f)
        {
            this.ObstacleDestroy();
        }
	}

    // Destroy object and generate new object

    public void ObstacleDestroy()
    {

        // create new obstacle instance
        this.newpos.Set(Random.Range(-5.0f,5.0f), -5.5f, 0.5f);
        Instantiate(cloud,newpos,Quaternion.identity);

        // destroy this object
        Destroy(this.gameObject);
    }
}
