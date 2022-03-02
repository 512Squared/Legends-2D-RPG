using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class UI : MonoBehaviour
{

    #region Singleton

    public static UI instance;

    #endregion

    public TextMeshProUGUI[] goldStats, manaStats, hpStats;
    [Space]
    public Slider[] hpSliders;
    public Slider[] manaSliders;

    void Start()
    {
        instance = this;
        UpdateAll(0);
    }

    public void UpdateAfterUseItem()
    {
        for (int i = 0; i < manaStats.Length; i++)
        {
            if (i == 1) // front screen format
            {
                manaStats[i].text = Thulgran.ThulgranMana.ToString() + " / " + Thulgran.maxThulgranMana;
            }

            else if (i != 0 && i != 1)
            {
                manaStats[i].text = Thulgran.ThulgranMana.ToString();
            }
        }

        for (int i = 0; i < hpStats.Length; i++)
        {

            if (i == 1) // front screen format
            {
                hpStats[i].text = Thulgran.ThulgranHP.ToString() + " / " + Thulgran.maxThulgranHP;
            }

            else if (i != 0 && i != 1)
            {
                hpStats[i].text = Thulgran.ThulgranHP.ToString();
            }
        }

        for (int i = 0; i < hpSliders.Length; i++)
        {
            if (i != 0) hpSliders[i].value = Thulgran.ThulgranHP;
        }

        for (int i = 0; i < manaSliders.Length; i++)
        {
            if (i != 0) manaSliders[i].value = Thulgran.ThulgranMana;
        }
    }

    public void UpdateGoldUI(int coin)
    {
        for (int i = 0; i < goldStats.Length; i++)
        {
            if(goldStats[i] != null) goldStats[i].text = Thulgran.ThulgranGold.ToString();
        }
    }

    public void UpdateHPUI(int heart)
    {

        for (int i = 0; i < hpStats.Length; i++)
        {

            if (i == 0 || i == 1) // front screen format
            {
                hpStats[i].text = Thulgran.ThulgranHP.ToString() + " / " + Thulgran.maxThulgranHP;
            }

            else
            {
                hpStats[i].text = Thulgran.ThulgranHP.ToString();
            }
        }
    }

    public void UpdateManaUI(int rune)
    {

        for (int i = 0; i < manaStats.Length; i++)
        {
            if (i == 0 || i == 1) // front screen format
            {
                manaStats[i].text = Thulgran.ThulgranMana.ToString() + " / " + Thulgran.maxThulgranMana;
            }

            else
            {
                manaStats[i].text = Thulgran.ThulgranMana.ToString();
            }
        }
    }

    public void UpdateAll(int empty)
    {

        UpdateGoldUI(empty); // values are taken from static ThulgranGold
        UpdateHPUI(empty);
        UpdateManaUI(empty);

        for (int i = 0; i < hpSliders.Length; i++)
        {
            hpSliders[i].value = Thulgran.ThulgranMana;
        }

        for (int i = 0; i < manaSliders.Length; i++)
        {
            manaSliders[i].value = Thulgran.ThulgranMana;
        }
    }
}

