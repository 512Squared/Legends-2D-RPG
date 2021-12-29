using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : Abilities
{

    //private Abilities abilities;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestMethod()
    {
        if (PlayerGlobalData.instance.arrivedAt == "test")
        {
            Fireball(20);
            gameObject.transform.position = new Vector2(1f, 1f);
        }
    }
}
