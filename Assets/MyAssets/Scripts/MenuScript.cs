using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public PlayerManager playerManager;

    private Animator anim;


    //Buttons effect

    //Weapon Selection
    public void SelectMainWeapon(string weapon)
    {
        SelectWeapon(Subsystem.GUN_MAIN, string2WeaponType(weapon));
    }

    public void SelectTLeftWeapon(string weapon)
    {
        SelectWeapon(Subsystem.GUN_TLEFT, string2WeaponType(weapon));
    }

    public void SelectTRightWeapon(string weapon)
    {
        SelectWeapon(Subsystem.GUN_TRIGHT, string2WeaponType(weapon));
    }

    public void SelectBLeftWeapon(string weapon)
    {
        SelectWeapon(Subsystem.GUN_BLEFT, string2WeaponType(weapon));
    }

    public void SelectBRightWeapon(string weapon)
    {
        SelectWeapon(Subsystem.GUN_BRIGHT, string2WeaponType(weapon));
    }

    public void SelectWeapon(Subsystem sub, WeaponType weapon)
    {
        playerManager.SetWeapon(sub, weapon);

        setBar(sub, playerManager.getSubLevel(sub, weapon));
    }


    //UI Green Bar Manipulation
    public void setBar(Subsystem sub, int level)
    {
        RectTransform bar = getSubBar(sub);

        bar.localScale = new Vector3(level * 0.1f, 1, 1);
    }

    public RectTransform getSubBar(Subsystem sub)
    {
        Transform curr_Transform = transform.Find("MasterMenu").Find("Ship");

        switch (sub)
        {
            case Subsystem.GUN_MAIN:
                curr_Transform = curr_Transform.Find("Gun_Main");
                break;

            default: //Changefor a different error message when all is done
                Debug.Log("Subsystem Not Implementeed yet");
                return null;
        }

        return (RectTransform)(curr_Transform.Find("Panel").Find("LevelBar"));
    }
















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
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    //PRIVATE Methods

    private WeaponType string2WeaponType(string weaponName)
    {
        if (weaponName == "REPEATER") return WeaponType.REPEATER;

        Debug.Log("Unknown Weapon Identifier");
        return WeaponType.REPEATER;
    }

    /*private Subsystem string2Sub(string subName)
    {
        if (subName == "GUN_MAIN") return Subsystem.GUN_MAIN;
        if (subName == "GUN_TLEFT") return Subsystem.GUN_TLEFT;
        if (subName == "GUN_TRIGHT") return Subsystem.GUN_TRIGHT;
        if (subName == "GUN_BLEFT") return Subsystem.GUN_BLEFT;
        if (subName == "GUN_BRIGHT") return Subsystem.GUN_BRIGHT;
        if (subName == "SHIELD_DELAY") return Subsystem.SHIELD_DELAY;
        if (subName == "SHIELD_RATE") return Subsystem.SHIELD_RATE;
        if (subName == "SHIELD_MAX") return Subsystem.SHIELD_MAX;
        if (subName == "HEALTH_MAX") return Subsystem.HEALTH_MAX;
        if (subName == "ENGINE") return Subsystem.ENGINE;

        Debug.Log("Unknown Subsystem identifier");
        return Subsystem.ENGINE;
    }*/
}
