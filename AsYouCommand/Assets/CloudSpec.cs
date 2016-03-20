using UnityEngine;
using System.Collections;

public class CloudSpec : MonoBehaviour {

    public GameObject p;

    // destory on collision and trigger particle effect
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            GameObject.Find("player").GetComponent<Player>().CloudHit();
            Vector3 burstpos = this.gameObject.transform.position;
            Instantiate(p, burstpos, Quaternion.Euler(270, 0, 0));
        }
            this.gameObject.GetComponent<Obstacle>().ObstacleDestroy();
    }
}
