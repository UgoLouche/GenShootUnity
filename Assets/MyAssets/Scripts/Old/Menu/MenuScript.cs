using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    private Animator anim;

    public PlayerManager manager;

    //Menu pop in and out

    public void turnOn() //Let's try to have something a little animated
    {
        gameObject.SetActive(true);
        anim.SetBool("slidingOut", false); //safeguard
    }

    public void turnOff()
    {
        anim.SetBool("slidingOut", true);
    }

    //Deactivate and reset animator
    private void Disable()
    {
        anim.SetBool("slidingOut", false);
        gameObject.SetActive(false);
    }


    // Use this for initialization
    void Start ()
    {
        //Set the menu to its true position
        transform.GetChild(0).position += new Vector3(-1024f, 0f, 0f);
        gameObject.SetActive(false);
        anim = GetComponent<Animator>();

        //Initialize panels
        getSubPanelByName("Gun_Main").GetComponent<MenuPanel>().SetManager(manager);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private Transform getSubPanelByName(string subName)
    {
        return transform
            .Find("MasterMenu")
            .Find("Ship")
            .Find(subName)
            .Find("Panel");
    }
}
