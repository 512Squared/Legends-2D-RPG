using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum CharacterID
{
    NONE,
    village_madam,
    weapon_Npc,
    Food_Npc,
    village_Elder,
    Village_girl,
    potion_Npc,
    injured_farmer,
    Guard_Npc


}

public class Demo_GM : MonoBehaviour {




    public CharacterID characterid = CharacterID.village_madam;

    public static Demo_GM Gm;

    public Image[] UIImage;

    public RectTransform Pointer;
    public RectTransform CanvasUIRect;
    // Use this for initialization
    void Awake () {
        Gm = this;
        Color myColor = new Color32(180, 180, 180, 255);
        UIImage[0].color = myColor;

        Screen.fullScreen = false;
    }
	
	// Update is called once per frame
	void Update () {

        KeyUPDownchange();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1_village_madam");

            characterid = CharacterID.village_madam;
            InitColor();
            Color myColor = new Color32(180,180,180,255);
         
            UIImage[0].color = myColor;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2_weapon_Npc");

            characterid = CharacterID.weapon_Npc;

            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[1].color = myColor;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3_Food_Npc");

            characterid = CharacterID.Food_Npc;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[2].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4_village_Elder");

            characterid = CharacterID.village_Elder;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[3].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("5_Village_girl");

            characterid = CharacterID.Village_girl;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[4].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("6_potion_Npc");

            characterid = CharacterID.potion_Npc;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[5].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("7_injured_farmer");

            characterid = CharacterID.injured_farmer;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[6].color = myColor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("8_Guard_Npc");

            characterid = CharacterID.Guard_Npc;
            InitColor();
            Color myColor = new Color32(180, 180, 180, 255);

            UIImage[7].color = myColor;
        }

    }


    void InitColor()
    {

        for (int i = 0; i < UIImage.Length; i++)
        {
            UIImage[i].color = new Color(255, 255, 255);


        }

    }

    public void KeyUPDownchange()
    {
        // wsad
        if (Input.GetKeyUp(KeyCode.A))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[12].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[13].color = myColor;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[10].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[11].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[12].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[13].color = myColor;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[10].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[11].color = myColor;
        }

        ///
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[14].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[15].color = myColor;
        }

   

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[14].color = myColor;

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {



            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[15].color = myColor;

        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {


            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[8].color = myColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[9].color = myColor;
        }


        if (Input.GetKeyUp(KeyCode.Alpha9))
        {


            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[8].color = myColor;
        }

        if (Input.GetKeyUp(KeyCode.Alpha0))
        {

            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[9].color = myColor;
        }

    }

}
