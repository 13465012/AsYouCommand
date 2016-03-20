using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreGUI : MonoBehaviour {

    public string[] file;
    public string[][] file2;
    bool populatedScroll = false;
    bool ScoreHigh = false;
    public InputField input;

    public void Button()
    {
        string output = "";
        for (int i = 0; i < this.file2.Length - 1; i++) {
            output += file2[i][0] + "-" + file2[i][1] + "|";
       }
        output += file2[file2.Length - 1][0] + "-";
        if (input.text == "")
            output += "Unknown|";
        else
            output += input.text + "|";

        File.WriteAllText("highscores.txt", output);
        SceneManager.LoadScene("MainMenu");
    }

    // Use this for initialization
    void Start () {
        if (File.Exists("highscores.txt")) {
            this.file = File.ReadAllLines("highscores.txt");
        }
        else
        {
            File.WriteAllText("highscores.txt", "0-Unknown|");
            this.file = File.ReadAllLines("highscores.txt");
        }
	}
	
	// Update is called once per frame
	void Update () {

        // Populate highscore list
	    if(GameObject.FindGameObjectWithTag("ScoreList") != null)
        {
            if(!populatedScroll)
            {
                string output = "";
                int entries = 0;
                for(int i = 0; i < this.file.Length;i++)
                {
                    for(int x = 0; x < this.file[i].Length;x++)
                    {
                        if (this.file[i][x] == '|')
                        {
                            entries++;
                        }
                    }
                }
                

                // load entries into new array
                this.file2 = new string[entries][];
                int e = 0;
                string var = "";
                for(int i = 0; i < entries;i++)
                    this.file2[i] = new string[2];

                for (int i = 0; i < this.file[0].Length;i++)
                {
                    if (this.file[0][i] == '-')
                    {
                        this.file2[e][0] = var;
                        var = "";
                    }
                    else if (this.file[0][i] == '|')
                    {
                        print(file2[e]);
                        this.file2[e][1] = var;
                        var = ""; e++;
                    }
                    else
                        var += this.file[0][i];
                        
                }

                
                
                bool noneSmaller = false;
                string[][] file3 = this.file2;
                while (!noneSmaller)
                {
                    noneSmaller = true;
                    for (int i = 0; i < file3.Length - 1; i++)
                    {
                        if(i - 1 > -1)
                        {
                            if(Convert.ToInt32(file3[i][0]) > Convert.ToInt32(file3[i-1][0]))
                            {
                                string[] tmp = { file3[i - 1][0], file3[i - 1][1] };
                                file3[i - 1] = file3[i];
                                file3[i] = tmp;
                                noneSmaller = false;
                            }

                        }

                    }
                }
                
                for (int i = 0; i < file3.Length - 1; i++)
                    output += file3[i][0] + " - " + file3[i][1] + "\n";

                GameObject.FindGameObjectWithTag("ScoreList").GetComponent<Text>().text = output;
                input.text = file2[file2.Length - 1][1];
                populatedScroll = true;
            }


            if(GameObject.FindGameObjectWithTag("ScoreHigh") != null && !ScoreHigh)
            {
                GameObject.FindGameObjectWithTag("ScoreHigh").GetComponent<Text>().text = file2[file2.Length - 1][0];
                ScoreHigh = true;
            }


        }
	}
}
