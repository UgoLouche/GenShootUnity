//using UnityEngine;
//using System.Collections;

//public class MenuPanel : MonoBehaviour {

//    public MenuBar bar;
//    public MenuUpButton upButton;
//    public MenuPanelText text;
//    public MenuToggle[] toggleButtons;


//    public Subsystem sub;
//    private WeaponType weapon = WeaponType.NONE;

//    private PlayerManager playerManager;

//    public void SetSub(Subsystem sub)
//    {
//        this.sub = sub;
//        propagateSub();
//    }

//    public void SetWeapon(WeaponType weapon)
//    {
//        this.weapon = weapon;
//        propagateWeapon();
//    }

//    public void SetManager(PlayerManager playerManager)
//    {
//        this.playerManager = playerManager;
//        propagateManager();
//    }

//    // Use this for initialization
//    void Start () {
//        propagate();	
//	}
	
//	// Update is called once per frame
//	void Update () {
	
//	}

//    private void propagate()
//    {
//        propagateManager();

//        propagateSub();

//        propagateWeapon();
//    }

//    private void propagateSub()
//    {
//        bar.SetSub(sub);
//        upButton.SetSub(sub);
//        text.SetSub(sub);

//        foreach (MenuToggle toggle in toggleButtons)
//        {
//            toggle.SetSub(sub);
//        }
//    }

//    private void propagateManager()
//    {
//        bar.SetManager(playerManager);
//        upButton.SetManager(playerManager);
//        text.SetManager(playerManager);

//        foreach (MenuToggle toggle in toggleButtons)
//        {
//            toggle.SetManager(playerManager);
//        }
//    }

//    private void propagateWeapon()
//    {
//        bar.SetWeapon(weapon);
//        upButton.SetWeapon(weapon);
//        text.SetWeapon(weapon);
//    }
//}
