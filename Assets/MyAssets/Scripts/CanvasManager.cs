using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		transform.FindChild ("ScoreBoard").gameObject.GetComponent<Text> ().text =
			"Score: " + GameManager.GetInstance ().Score();

		transform.FindChild ("MultiplierBoard").gameObject.GetComponent<Text> ().text =
			"X" + GameManager.GetInstance ().Multiplier ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.FindChild ("ScoreBoard").gameObject.GetComponent<Text> ().text =
			"Score: " + GameManager.GetInstance ().Score();
		
		transform.FindChild ("MultiplierBoard").gameObject.GetComponent<Text> ().text =
			"X" + GameManager.GetInstance ().Multiplier ();

        transform.FindChild("HealthBar").gameObject.GetComponent<RectTransform>().localScale =
           new Vector3(1, (float)(GameManager.GetInstance().getPlayer().GetHealth()) / (float)(GameManager.GetInstance().getPlayer().healthPool), 1); //NB: avoid move from setting Pivot to 0,0
	}
}
