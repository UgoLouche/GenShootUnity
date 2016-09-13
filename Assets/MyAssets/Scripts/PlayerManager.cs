using UnityEngine;
using System.Collections;

public enum Subsystem : int
{
    GUN_MAIN = 0,
    GUN_TLEFT = 1,
    GUN_TRIGHT = 2,
    GUN_BLEFT = 3,
    GUN_BRIGHT = 4,
    SHIELD_DELAY = 5,
    SHIELD_RATE = 6,
    SHIELD_MAX = 7,
    HEALTH_MAX = 8,
    ENGINE = 9
};

public enum WeaponType
{
    REPEATER
};

public class PlayerManager : MonoBehaviour {

    //Player ref
    public PlayerShip player;

    //Money
    public int money;

    //Ship
    public float shieldRechargeDelay_Base;
    public int shieldRechargeDelay_Level;
    public int shieldRechargeDelay_UpgradeCost;

    public float shieldRechargeRate_Base;
    public int shieldRechargeRate_Level;
    public int shieldRechargeRate_UpgradeCost;

    public float maxShield_Base;
    public int maxShield_Level;
    public int maxShield_UpgradeCost;

    public float maxHealth_Base;
    public int maxHealth_Level;
    public int maxHealth_UpgradeCost;

    //Guns - Main, TLeft, TRight, BLeft, BRight
    public int[] repeatersLevel;
    public int repeater_UgradeCost;

    //Add other guns type here

    //Propulsion
    public int engineLevel;
    public int engine_UpgradeCost;



    //METHOD
    //SPecify weapon if referring to a weapon subsystem
    public int getSubLevel(Subsystem sub, WeaponType weapon = WeaponType.REPEATER)
    {
        switch(sub)
        {
            case Subsystem.ENGINE:
                return engineLevel;

            case Subsystem.HEALTH_MAX:
                return maxHealth_Level;

            case Subsystem.SHIELD_MAX:
                return maxShield_Level;

            case Subsystem.SHIELD_RATE:
                return shieldRechargeRate_Level;

            case Subsystem.SHIELD_DELAY:
                return shieldRechargeDelay_Level;

            case Subsystem.GUN_BRIGHT:
            case Subsystem.GUN_BLEFT:
            case Subsystem.GUN_TRIGHT:
            case Subsystem.GUN_TLEFT:
            case Subsystem.GUN_MAIN:
                switch(weapon)
                {
                    case WeaponType.REPEATER:
                        return repeatersLevel[(int)sub];
                    default:
                        Debug.Log("Unknown Weapon type");
                        return 0;
                }
            default:
                Debug.Log("Unknown Subsystem");
                return 0;
        }
    }

    public void SetWeapon(Subsystem sub, WeaponType weapon)
    {
        GameObject gunPoint;
        GameObject newGun;

        switch(sub)
        {
            case Subsystem.GUN_MAIN:
                gunPoint = player.transform.Find("GunPoint_Main").gameObject;
                break;

            case Subsystem.GUN_TLEFT:
                gunPoint = player.transform.Find("GunPoint_TLeft").gameObject;
                break;

            case Subsystem.GUN_TRIGHT:
                gunPoint = player.transform.Find("GunPoint_TRight").gameObject;
                break;

            case Subsystem.GUN_BLEFT:
                gunPoint = player.transform.Find("GunPoint_BLeft").gameObject;
                break;

            case Subsystem.GUN_BRIGHT:
                gunPoint = player.transform.Find("GunPoint_BRight").gameObject;
                break;

            default:
                Debug.Log("Unknown Subsystem type");
                return;
        }

        switch(weapon)
        {
            case WeaponType.REPEATER:
                newGun = ObjectPooler.GetObject("Player_Repeater");
                break;

            default:
                Debug.Log("Unknown new Weapon Type");
                return;
        }

        //Pool Current Gun
        ObjectPooler.PoolObject(gunPoint.transform.GetChild(0).gameObject);

        //Set New Gun
        newGun.transform.SetParent(gunPoint.transform);
    }



}
