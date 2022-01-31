using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Sirenix.OdinInspector;
using System.Linq;
using System;


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

    private void OnEnable()
    {
        Actions.OnSellItem += SellItem; // subscriber 
        Actions.OnUseItem += UseItem; // subscriber
        Actions._cUpdate += Update_c; // subscriber
    }

    private void OnDisable()
    {
        Actions.OnSellItem -= SellItem; // subscriber 
        Actions.OnUseItem -= UseItem; // subscriber
        Actions._cUpdate -= Update_c; // subscriber
    }

    public int _c;
    public int chosenCharacter;
    private int _hp;
    private int _mana;

    int thulGold;
    int thulHP;
    int thulMana;

    private void Start()
    {
        instance = this;        chosenCharacters = FindObjectsOfType<PlayerStats>().OrderBy(m => m.transform.position.z).ToArray();

        thulGold = Thulgran.thulgranGold;
        thulHP = Thulgran.thulgranHP;
        thulMana = Thulgran.thulgranMana;


        PrepareCoins();
        PrepareHP();
        PrepareMana();

        _c += thulGold;
        _hp += thulHP;
        _mana += thulMana;
        coinUIText.text = _c.ToString();
        hpUIText.text = _hp.ToString() + " / " + Thulgran.maxThulgranHP;
        manaUIText.text = _mana.ToString() + " / " + Thulgran.maxThulgranMana;

    }

    private void Update()
    {

    }


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

    public int Hp
    {
        get { return _hp; }
        set
        {
            //update UI Text whenever HP variable is changed
            if (chosenCharacter == 0 && Hp < Thulgran.maxThulgranHP)

            {
                _hp = value;
                hpUIText.text = Hp.ToString() + "/" + Thulgran.maxThulgranHP;
            }
        }
    }

    public int Mana
    {
        get { return _mana; }
        set
        {
            //update UI Text whenever Mana variable is changed

            if (chosenCharacter == 0 && Mana < Thulgran.maxThulgranMana)
            {
                _mana = value;
                manaUIText.text = Mana.ToString() + "/" + Thulgran.maxThulgranMana;
            }
        }
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

    public void AnimateCoins(Vector2 source, int valueInCoins) 
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
                coin.transform.position = source + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);


                // animate coin to target position
                float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
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

    public void AnimateHP(Vector2 sourceHP, int amountOfEffect, Vector2 receivedTarget) 
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
                hp.transform.position = sourceHP + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);


                // animate hearts to target position
                float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
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

    public void AnimateMana(Vector2 sourceMana, int amountOfEffect, Vector2 receivedTarget) 
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
                mana.transform.position = sourceMana + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);


                // animate coin to target position
                float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
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


    public void UseItem(ItemsManager item, int selectedCharacter, Vector2 target)
    {
        if (item.affectType == ItemsManager.AffectType.HP)
        {
            UpdateHP();
            chosenCharacter = selectedCharacter;
            AnimateHP(sourceHP, item.amountOfEffect, target);
            Debug.Log("UIAddHP called from CoinsManager");
        }

        if (item.affectType == ItemsManager.AffectType.Mana)
        {
            UpdateMana();
            chosenCharacter = selectedCharacter;
            AnimateMana(sourceMana, item.amountOfEffect, target);
            Debug.Log("UIAddMana called from CoinsManager");
        }
    }

    public void SellItem(ItemsManager item)
    {
            UpdateCoins();
            AnimateCoins(sourceCoins, item.valueInCoins);
            Debug.Log("UIAddCoins called from CoinsManager");
    }

    public void UpdateCoins()
    {
        targetPositionCoins = targetCoin.position;
        sourceCoins = sourceTransformCoin.position;
    }

    public void UpdateHP()
    {
        targetPositionHP = targetHP.position;
        sourceHP = sourceTransformHP.position;
    }

    public void UpdateMana()
    {
        targetPositionMana = targetMana.position;
        sourceMana = sourceTransformMana.position;
    }

    public void Update_c(ItemsManager item)
    {
        _c -= item.valueInCoins;
    }
}
