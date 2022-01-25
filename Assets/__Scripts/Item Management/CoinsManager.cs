using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Sirenix.OdinInspector;
using System.Linq;


// handles coins, mana and HP animations in Equipment panel.
// interacts with MenuManager for displaying sell and use items UpdateInventoryItems()
// interacts with Inventory for updating and interacting with UI display functions on MenuManager. Inventory functions and SellItem(), UseAndRemoveItem().
// item button controls 

public class CoinsManager : MonoBehaviour
{

    public static CoinsManager instance;
    
    [Header("Main connectors")]
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject animatedCoinPrefab;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject animatedHPPrefab;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject animatedManaPrefab;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] Transform targetCoin;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] Transform targetHP;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] Transform targetMana;

    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private Transform sourceTransformCoin;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private Transform sourceTransformHP;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private Transform sourceTransformMana;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI coinUIText;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI hpUIText;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TextMeshProUGUI manaUIText;


    private Vector2 sourceCoins;
    private Vector2 sourceHP;
    private Vector2 sourceMana;

    public PlayerStats[] chosenCharacters;

    Vector2 targetPositionCoins;
    Vector2 targetPositionHP;
    Vector2 targetPositionMana;


    [Header("Available coins : (coins to pool)")]
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] int maxCoins;
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] int maxHP;
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] int maxMana;
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]


    Queue<GameObject> coinsQueue = new Queue<GameObject>();
    Queue<GameObject> hpQueue = new Queue<GameObject>();
    Queue<GameObject> manaQueue = new Queue<GameObject>();

    [Header("Animation settings")]
    [TabGroup("New Group", "Animation settings")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
    [TabGroup("New Group", "Animation settings")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] [Range(0.9f, 2f)] float maxAnimDuration;
    [TabGroup("New Group", "Animation settings")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] Ease easeType;
    [TabGroup("New Group", "Animation settings")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField] float spread;



    // STRATEGIES

    // Could use the RemoveItems code to add in a variable for which animation trigger to use.  MenuManager.instance.animTrigger = item.GetComponent<Animator>().SetTrigger("ItemSold");

    // MenuManager is the only script that currently successful activates a trigger, with                 itemSlot.GetComponent<Animator>().SetTrigger("animatePlease");

    // As ever, the choice is between where to put the script and where to call the data that is thereby missing to make the script work


    public int _c;
    public int chosenCharacter;


    public int Coins
    {
        get { return _c; }
        set
        {
            _c = value;

            //update UI Text whenever "Coins variable is changed


            coinUIText.text = Coins.ToString();


        }
    }

    private int _hp;

    public int Hp
    {
        get { return _hp; }
        set
        {


            //update UI Text whenever HP variable is changed
            if (chosenCharacter == 0 && Hp < chosenCharacters[0].maxHP + 1)

            {
                _hp = value;
                hpUIText.text = Hp.ToString() + "/" + chosenCharacters[0].maxHP;
            }
        }
    }

    private int _mana;

    public int Mana
    {
        get { return _mana; }
        set
        {


            //update UI Text whenever Mana variable is changed

            if (chosenCharacter == 0 && Mana < chosenCharacters[0].maxMana + 1)
            {
                _mana = value;
                manaUIText.text = Mana.ToString() + "/" + chosenCharacters[0].maxMana;
            }
        }
    }



    void Awake()
    {



    }


    private void Start()
    {
        instance = this;
        chosenCharacters = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();

        PrepareCoins();
        PrepareHP();
        PrepareMana();

        _c += chosenCharacters[0].thulGold;
        _hp += chosenCharacters[0].npcHP;
        _mana += chosenCharacters[0].npcMana;
        coinUIText.text = _c.ToString();
        hpUIText.text = _hp.ToString() + "/" + chosenCharacters[0].maxHP;
        manaUIText.text = _mana.ToString() + "/" + chosenCharacters[0].maxMana;

    }

    void PrepareCoins()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            GameObject coin;
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.SetParent(sourceTransformCoin, false);
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);

        }
    }

    void PrepareHP()
    {
        for (int i = 0; i < maxHP; i++)
        {
            GameObject hp;
            hp = Instantiate(animatedHPPrefab);
            hp.transform.SetParent(sourceTransformHP, false);
            hp.SetActive(false);
            hpQueue.Enqueue(hp);

        }
    }

    void PrepareMana()
    {
        for (int i = 0; i < maxMana; i++)
        {
            GameObject mana;
            mana = Instantiate(animatedManaPrefab);
            mana.transform.SetParent(sourceTransformMana, false);
            mana.SetActive(false);
            manaQueue.Enqueue(mana);

        }
    }





    public void Animate(Vector2 source, int valueInCoins) //previously 'collectedCoinPosition'
    {

        Debug.Log("Animate coins called");
        for (int i = 0; i < valueInCoins; i++)
        {
            // check if there's coins in the pool
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);

                // move coin to the collected coin position
                coin.transform.position = source + new Vector2(Random.Range(-spread, spread), 0f);


                // animate coin to target position
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPositionCoins, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever coin reach target position;
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);
                        Coins++;
                    });

            }
        }


    }

    public void AnimateHP(Vector2 sourceHP, int amountOfEffect, Vector2 receivedTarget) //previously 'collectedCoinPosition' // amountOfEffect is called in Inventory.cs
    {

        // trying to assign a target position to player image

        targetPositionHP = receivedTarget;


        Debug.Log("Animate HP called");
        for (int i = 0; i < amountOfEffect; i++)
        {
            // check if there's hearts in the pool
            if (hpQueue.Count > 0)
            {
                GameObject hp = hpQueue.Dequeue();
                hp.SetActive(true);

                // move hearts to the collected heart position
                hp.transform.position = sourceHP + new Vector2(Random.Range(-spread, spread), 0f);


                // animate hearts to target position
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                hp.transform.DOMove(targetPositionHP, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever heart reaches target position;
                        hp.SetActive(false);
                        coinsQueue.Enqueue(hp);
                        Hp++;
                    });

            }
        }


    }

    public void AnimateMana(Vector2 sourceMana, int amountOfEffect, Vector2 receivedTarget) //previously 'collectedCoinPosition' // amountOfEffect is called in Inventory.cs
    {
        // assigning target position to polayer image

        targetPositionMana = receivedTarget;

        Debug.Log("Animate runes called");
        for (int i = 0; i < amountOfEffect; i++)
        {
            // check if there's coins in the pool
            if (manaQueue.Count > 0)
            {
                GameObject mana = manaQueue.Dequeue();
                mana.SetActive(true);

                // move coin to the collected coin position
                mana.transform.position = sourceMana + new Vector2(Random.Range(-spread, spread), 0f);


                // animate coin to target position
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                mana.transform.DOMove(targetPositionMana, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever mana runes reach target position;
                        mana.SetActive(false);
                        manaQueue.Enqueue(mana);
                        Mana++;
                    });

            }
        }


    }



    public void UIAddCoins(int valueInCoins, int selectedCharacter) //previously 'collectedCoinPosition'
    {
        Debug.Log("UIAddCoins called from CoinsManager");

        Animate(sourceCoins, valueInCoins);

    }

    public void UIAddHp(int amountOfEffect, Vector2 target, int selectedCharacter) //previously 'collectedCoinPosition'
    {
        chosenCharacter = selectedCharacter;

        AnimateHP(sourceHP, amountOfEffect, target);

        Debug.Log("UIAddHP called from CoinsManager");


    }

    public void UIAddMana(int amountOfEffect, Vector2 target, int selectedCharacter) //previously 'collectedCoinPosition'
    {
        chosenCharacter = selectedCharacter;

        AnimateMana(sourceMana, amountOfEffect, target);

        Debug.Log("UIAddMana called from CoinsManager");


    }


    public void updateCoins()
    {
        targetPositionCoins = targetCoin.position;
        sourceCoins = sourceTransformCoin.position;
    }

    public void updateHP()
    {
        targetPositionHP = targetHP.position;
        sourceHP = sourceTransformHP.position;
    }

    public void updateMana()
    {
        targetPositionMana = targetMana.position;
        sourceMana = sourceTransformMana.position;
    }
}