using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SubmitButton : MonoBehaviour {

	public void OnPointerUp(PointerEventData p)
    {
        print("click");
        GameObject.FindGameObjectWithTag("HighScoreCanvas").GetComponent<HighScoreGUI>().Button();
    }
}
