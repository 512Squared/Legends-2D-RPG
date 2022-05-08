using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    [SerializeField] private MagicUnit unitPrefab;
    private MagicUnit _spawn;

    private List<MagicUnit> _magicUnits = newt is called before the first frame update
    private void Start()
    {
        //_spawn.magicSlots = new GameObject[7];

        //Vector3 position = PlayerGlobalData.instance.GetComponent<Transform>().position;
        //_spawn = Instantiate(_unitPrefab, position+(transform.forward*4), transform.rotation);
        //_spawn.GetComponent<SpriteRenderer>().sortingLayerName = "Objects"; 

        //_spawn.Level = 2;

        //for (int i = 0; i < 5; i++)
        //{
        //    _MagicUnits.Add(Instantiate(_unitPrefab));
        //}
    }

    // Update is called once per frame
    private void Update()
    {
        //_spawn.transform.position = Random.insideUnitSphere;
        //foreach (var unit in _MagicUnits)
        //{
        //    unit.transform.position = Random.insideUnitSphere;
        //}
    }

    public void UseMagic(int characterToUseOn)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("You picked up a " + _spawn.magicName);
            SelfDestroy();
            Inventory.AddMagic(this);
        }
    }

    public void SelfDestroy()
    {
        gameObject.SetActive(false);
    }
}