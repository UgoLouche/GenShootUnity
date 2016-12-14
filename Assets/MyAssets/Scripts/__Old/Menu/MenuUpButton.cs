//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class MenuUpButton : MonoBehaviour {

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

//    public void OnClick()
//    {
//        if (playerManager.isUpgradable(sub, weapon))
//        {
//            playerManager.Upgrade(sub, weapon);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if ( !playerManager.isUpgradable(sub, weapon) )
//        {
//            if (gameObject.GetComponent<Button>().interactable)
//                gameObject.GetComponent<Button>().interactable = false;
//        }
//        else
//        {
//            if (!gameObject.GetComponent<Button>().interactable)
//                gameObject.GetComponent<Button>().interactable = true;
//        }
//    }
//}
