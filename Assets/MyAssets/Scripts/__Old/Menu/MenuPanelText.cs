//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class MenuPanelText : MonoBehaviour {

//    private Subsystem sub;
//    private WeaponType weapon;

//    private PlayerManager playerManager;


//    public void SetSub(Subsystem sub)
//    {
//        this.sub = sub;
//    }

//    public void SetWeapon(WeaponType weapon)
//    {
//        this.weapon = weapon;
//    }

//    public void SetManager(PlayerManager playerManager)
//    {
//        this.playerManager = playerManager;
//    }


//    void Update()
//    {
//        gameObject.GetComponent<Text>().text = 
//            "Next Upgrade Cost: " + playerManager.getUpgradeCost(sub, weapon);
//    }
//}
