using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public int currentXp;
    public int requiredXp;

    [SerializeField]
    private Player player;

    private void determineBonus()
    {
        switch (level)
        {
            case 2:
                player.IncDamage(20);
                player.IncMaxHealth(40);
                break;
            default:
                player.IncDamage(10);
                player.IncMaxHealth(20);
                break;
        }
    }

    void Start()
    {
        player = GetComponent<Player>();
        XpText.currentExp = currentXp;
        XpText.requiredExp = requiredXp;
        LevelText.level = level;
    }

    void Update()
    {
        // like a chetcode
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            //GainExperience(20);
            LevelUp();
        }
        if (currentXp >= requiredXp)
        {
            Debug.Log("WTF");
            LevelUp();
        }
        XpText.currentExp = currentXp;
        XpText.requiredExp = requiredXp;
        LevelText.level = level;
    }

    void LevelUp()
    {
            level++;
            determineBonus();
            currentXp = currentXp - requiredXp;
            requiredXp += 100;
    }

    public void GainExperience(int xpGained)
    {
        currentXp += xpGained;

    }
}
