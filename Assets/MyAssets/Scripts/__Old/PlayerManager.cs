//using UnityEngine;
//using System.Collections;

//public enum Subsystem : int
//{
//    GUN_MAIN = 0,
//    GUN_TLEFT = 1,
//    GUN_TRIGHT = 2,
//    GUN_BLEFT = 3,
//    GUN_BRIGHT = 4,
//    SHIELD_DELAY = 5,
//    SHIELD_RATE = 6,
//    SHIELD_MAX = 7,
//    HEALTH_MAX = 8,
//    ENGINE = 9
//};

//public enum WeaponType : int
//{
//    NONE = 0,
//    REPEATER = 1,
//    SHOTGUN = 2
//};

//public class PlayerManager : MonoBehaviour {

//    //Player ref
//    public PlayerShip player;

//    //Money
//    public float money;

//    //Ship
//    public float shieldRechargeDelay_Base;
//    public float shieldRechargeRate_Base;
//    public float maxShield_Base;
//    public float maxHealth_Base;
//    public float speed_Base;

//    private float[] upgradeCosts = { //The five first values are not used see the weapon specific table instead
//    0, //Main
//    0, //TLeft
//    0, //TRight
//    0, //BLeft
//    0, //BRight
//    0, //Shield Delay
//    0, //Shield Rate
//    0, //MaxShield
//    0, //Max Heatlth
//    0  //Engine
//    };

//    private int[] subLevels = {
//    0, //Main
//    0, //TLeft
//    0, //TRight
//    0, //BLeft
//    0, //BRight
//    0, //Shield Delay
//    0, //Shield Rate
//    0, //MaxShield
//    0, //Max Heatlth
//    0  //Engine
//    };


//    //Guns - Main, TLeft, TRight, BLeft, BRight
//    public WeaponType[] activeWeapon;

//    private int[,] weaponsLevels =
//    {
//        { 0, 0, 0, 0, 0 }, //NONE
//        { 1, 0, 0, 0, 0 }, //REPEATER
//        { 0, 0, 0, 0, 0 }  //SHOTGUN
//    };

//    private float[] weaponUpgradeCosts =
//    {
//        0,  //NONE
//        10, //REPEATER
//        50  //SHOTGUN
//    };






//    //METHOD
//    public bool isUpgradable(Subsystem sub, WeaponType weapon = WeaponType.NONE)
//    {
//        if (money < getUpgradeCost(sub, weapon) || getSubLevel(sub, weapon) >= 10) return false;
//        else return true;
//    }

//    public void Upgrade(Subsystem sub, WeaponType weapon = WeaponType.NONE)
//    {
//        if (weapon != WeaponType.NONE)
//            weaponsLevels[(int)weapon, (int)sub]++;
//        else
//            subLevels[(int)sub]++;

//        money -= getUpgradeCost(sub, weapon);
//        updatePlayer(sub, weapon);
//    }

//    //Specify weapon if referring to a weapon subsystem
//    public int getSubLevel(Subsystem sub, WeaponType weapon = WeaponType.NONE)
//    {
//        if (weapon != WeaponType.NONE)
//            return weaponsLevels[(int)weapon, (int)sub];
//        else
//            return subLevels[(int)sub];
//    }

//    public bool isWeaponActive(Subsystem sub, WeaponType weapon)
//    {
//        return activeWeapon[(int)sub] == weapon;
//    }

//    public void SetWeapon(Subsystem sub, WeaponType weapon)
//    {
//        GameObject gunPoint;
//        GameObject newGun;


//        switch(sub)
//        {
//            case Subsystem.GUN_MAIN:
//                gunPoint = player.transform.Find("GunPoint_Main").gameObject;
//                break;

//            case Subsystem.GUN_TLEFT:
//                gunPoint = player.transform.Find("GunPoint_TLeft").gameObject;
//                break;

//            case Subsystem.GUN_TRIGHT:
//                gunPoint = player.transform.Find("GunPoint_TRight").gameObject;
//                break;

//            case Subsystem.GUN_BLEFT:
//                gunPoint = player.transform.Find("GunPoint_BLeft").gameObject;
//                break;

//            case Subsystem.GUN_BRIGHT:
//                gunPoint = player.transform.Find("GunPoint_BRight").gameObject;
//                break;

//            default:
//                Debug.Log("Unknown Subsystem type");
//                return;
//        }

//        switch(weapon)
//        {
//            case WeaponType.REPEATER:
//                newGun = ObjectPooler.GetObject("Player_Repeater");
//                newGun.GetComponent<Weapon>().level = getSubLevel(sub, weapon);
//                activeWeapon[(int)sub] =  WeaponType.REPEATER;
//                break;

//            case WeaponType.SHOTGUN:
//                newGun = ObjectPooler.GetObject("Player_ShotGun");
//                newGun.GetComponent<Weapon>().level = getSubLevel(sub, weapon);
//                activeWeapon[(int)sub] = WeaponType.SHOTGUN;
//                break;

//            default:
//                Debug.Log("Unknown new Weapon Type");
//                return;
//        }

//        //Pool Current Gun
//        ObjectPooler.PoolObject(gunPoint.transform.GetChild(0).gameObject);

//        //Set New Gun
//        newGun.transform.parent = gunPoint.transform;
//        newGun.transform.localPosition = Vector3.zero;
//        newGun.transform.localScale = Vector3.one;
//        newGun.transform.localRotation = Quaternion.Euler(Vector3.zero);

//        player.weapons[(int)sub] = newGun.GetComponent<Weapon>();
//        player.PropagateTag(player.transform);
//    }


//    public float getUpgradeCost(Subsystem sub, WeaponType weapon)
//    {
//        int subLevel = 0;
//        float upCost = 0;

//        if (weapon != WeaponType.NONE)
//        {
//            subLevel = weaponsLevels[(int)weapon, (int)sub];
//            upCost = weaponUpgradeCosts[(int)weapon];
//        }
//        else
//        {
//            subLevel = subLevels[(int)sub];
//            upCost = upgradeCosts[(int)sub];
//        }

//        if (subLevel == 0) return upCost * 10; //Entry cost
//        else return Mathf.Pow(upCost, subLevel);
//    }

//    private void updatePlayer(Subsystem sub, WeaponType weapon)
//    {
//        switch (sub)
//        {
//            case Subsystem.GUN_MAIN:
//                getPlayerWeaponByName("GunPoint_Main").level =
//                    getSubLevel(sub, weapon);
//                break;
//            case Subsystem.GUN_TLEFT:
//                break;
//            case Subsystem.GUN_TRIGHT:
//                break;
//            case Subsystem.GUN_BLEFT:
//                break;
//            case Subsystem.GUN_BRIGHT:
//                break;
//            case Subsystem.SHIELD_DELAY:
//                break;
//            case Subsystem.SHIELD_RATE:
//                break;
//            case Subsystem.SHIELD_MAX:
//                break;
//            case Subsystem.HEALTH_MAX:
//                break;
//            case Subsystem.ENGINE:
//                player.speed = speed_Base * subLevels[(int)sub];
//                break;
//            default:
//                Debug.Log("Unknown Subsystem");
//                break;
//        }
//    }

//    private Weapon getPlayerWeaponByName(string name)
//    {
//        return player.transform
//                    .Find(name)
//                    .GetChild(0)
//                    .GetComponent<Weapon>();
//    }

//}
