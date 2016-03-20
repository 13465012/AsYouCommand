using UnityEngine;
using System.Collections;

public class GullEnemy : MonoBehaviour {

    private Vector3 movement = new Vector3(2, 0.5f, 0);
    public float DeathTime = 5;
    public GameObject gull;

    // Use this for initialization
    void Start() {
        // random x position
        float x = Random.Range(-1, 1);
        if (x < 0)
        {
            this.gameObject.transform.position = new Vector3(-7.5f, Random.Range(-8, 3));
        }
        else
        {
            this.gameObject.transform.Rotate(0, 180, 0);
            this.gameObject.transform.position = new Vector3(7.5f, Random.Range(-10, 10));
        }
    }

    // Update is called once per frame
    void Update() {
        
        // if vertically out of frame
        if (this.gameObject.transform.position.y > 5.5f)
        {
            if (DeathTime < 0)
                DestroyGull();
            else
                DeathTime -= 1 * Time.deltaTime;
        }
        // else update
        else
        {
            this.gameObject.transform.Translate(movement.x * Time.deltaTime, movement.y * Time.deltaTime * GameObject.Find("player").GetComponent<Player>().fallSpeed, movement.z);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            GameObject.Find("player").GetComponent<Player>().Death();
            DestroyGull();
        }
    }

    void DestroyGull()
    {
        Instantiate(gull, new Vector3(-10, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
