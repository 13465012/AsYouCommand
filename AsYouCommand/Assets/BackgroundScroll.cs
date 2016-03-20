using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public GameObject Background;

    private bool newBackground = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Scroll background
        
        if(this.gameObject.transform.position.y > 5 && newBackground == false)
        {
            Instantiate(Background, new Vector3(0.0f, -14.9f, 1.0f),Quaternion.identity);
            newBackground = true;
        }
        else if(this.gameObject.transform.position.y > 15)
        {
            this.DestroySelf();
        }
        else
        {
            if(GameObject.Find("player") != null)
                this.gameObject.transform.Translate(0.0f, (0.25f * Time.deltaTime * GameObject.Find("player").GetComponent<Player>().fallSpeed), 0.0f);
            else
                this.gameObject.transform.Translate(0.0f, (1f * Time.deltaTime), 0.0f);
        }
	}

    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
