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
	}
}
