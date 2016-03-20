using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    public InputField input;
    public GameObject DeathEffect;
    public float fallSpeed = 1.0f;
    Vector3 inertia;
    float inertiaDecay = 0.2f;
    float verticalCorrection = 0.1f;


	// Use this for initialization
	void Start () {
        this.inertia = new Vector3(0.0f,0.0f,0.0f);
	}

    // hit a cloud
    public void CloudHit()
    {
        inertia.y += 1f;
    }	

    // Death
    public void Death()
    {
        this.fallSpeed = 0;
        Instantiate(DeathEffect, this.gameObject.transform.position,Quaternion.identity);
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Destroy
    public void EndGame()
    {

        // Record Highscore
        File.AppendAllText("highscores.txt",GameObject.FindGameObjectWithTag("score").GetComponent<Score>().score.ToString() + "-Unknown|");
        SceneManager.LoadScene("HighScore");
  
    }

	// Update is called once per frame
	void Update () {
        input.ActivateInputField();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // get value from input
            string value = input.text;
            value = value.ToLower();

            // clear current value of input
            input.text = "";

            // Move according to value entered
            switch (value)
            {
                // Move left
                case "left":
                case "go left":
                case "move left":
                    this.inertia.x -= 1f;
                    break;

                // Move right
                case "right":
                case "go right":
                case "move right":
                    this.inertia.x += 1f;
                    break;

                // Move Down
                case "down":
                case "go down":
                case "speed":
                case "speed up":
                    this.inertia.y -= 1f;
                    break;

                // default
                default:
                    break;
            }
        }
        // Adjust Player Position
        this.gameObject.transform.Translate(this.inertia * Time.deltaTime);
            

        // adjust horizontal intertia
        if(this.inertia.x <= this.inertiaDecay && this.inertia.x >= this.inertiaDecay * -1)
        {
            this.inertia.x = 0.0f;
        }
        else if(this.inertia.x > 0.0f)
        {
            this.inertia.x -= this.inertiaDecay * Time.deltaTime;
        }
        else
        {
            this.inertia.x += this.inertiaDecay * Time.deltaTime;
        }

        // adjust vertical inertia
        if (this.inertia.y <= this.inertiaDecay && this.inertia.y >= this.inertiaDecay * -1)
        {
            this.inertia.y = 0.0f;
        }
        else if (this.inertia.y > 0.0f)
        {
            this.inertia.y -= this.inertiaDecay * Time.deltaTime;
        }
        else
        {
            this.inertia.y += this.inertiaDecay * Time.deltaTime;
        }

        // Jump to other side of screen
        if (-6.25f > this.gameObject.transform.position.x + 0.25f)
        {
            this.gameObject.transform.position = new Vector3(6.5f, this.gameObject.transform.position.y);
        }
        else if (6.25f < this.gameObject.transform.position.x - 0.25f)
        {
            this.gameObject.transform.position = new Vector3(-6.5f, this.gameObject.transform.position.y);
    
        }

        // check if at bottom or top
        if (this.gameObject.transform.position.y < -3)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -3f);
            if (this.inertia.y < 0)
                this.inertia.y = 0;
        }
        else if (this.gameObject.transform.position.y > 3)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 3f);
            if (this.inertia.y > 0)
                this.inertia.y = 0;
        }

        // increment fall speed
        this.fallSpeed += 0.1f * Time.deltaTime;
    }


}
