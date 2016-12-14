//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class MenuToggle : MonoBehaviour {

//    public WeaponType weapon;

//    private Subsystem sub;

//    private PlayerManager playerManager;


//    public void SetSub(Subsystem sub)
//    {
//        this.sub = sub;
//    }

//    public void SetManager(PlayerManager playerManager)
//    {
//        this.playerManager = playerManager;
//    }

//    public void stateChange(bool isOn)
//    {
//        if (isOn)
//        {
//            playerManager.SetWeapon(sub, weapon);
//            transform.parent.gameObject.GetComponent<MenuPanel>().SetWeapon(weapon);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (playerManager.isWeaponActive(sub, weapon))
//            gameObject.GetComponent<Toggle>().isOn = true;
//    }

//    // Use this for initialization
//    void Start()
//    {

//    }

//}
