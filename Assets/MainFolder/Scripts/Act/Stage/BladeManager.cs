using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeManager : MonoBehaviour
{
    public float attackDamage;
    public float attackPDamage;

    public StagePlayer player;

    public float ReturnDamage()
    {
        if (player.ReturnAttackData() == 0)
        {
            return 0;
            Debug.Log("Return 0!");
        }
        else if (player.ReturnAttackData() == 1)
        {
            return attackDamage;
            Debug.Log($"Return {attackDamage}!");
        }
        else
        {
            return attackPDamage;
            Debug.Log($"Return {attackPDamage}!");
        }
    }
}
