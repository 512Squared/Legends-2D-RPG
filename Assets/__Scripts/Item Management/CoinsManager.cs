using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Sirenix.OdinInspector;
using System.Linq;
using System;


public class CoinsManager : MonoBehaviour
{

    #region Serialisation



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

    #endregion

    private void OnEnable()
    {
        Actions.OnSellItem += SellItem; // subscriber 
        Actions.OnUseItem += UseItem; // subscriber
        Actions.OnBuyItem += CoinUpdate; // subscriber
    }

    private void OnDisable()
    {
        Actions.OnSellItem -= SellItem; // subscriber 
        Actions.OnUseItem -= UseItem; // subscriber
        Actions.OnBuyItem -= CoinUpdate; // subscriber
    }

    public int chosenCharacter;

    private void Start()
    {
        instance = this;

        PrepareCoins();
        PrepareHP();
        PrepareMana();
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
        if (maxCoins < valueInCoins)
        {
            for (int j = 0; j < (valueInCoins - maxCoins + 1); j++)
            {
                GameObject coin;
                coin = Instantiate(animatedCoinPrefab);
                coin.transform.SetParent(sourceTransformCoin, false);
                coin.SetActive(false);
                coinsQueue.Enqueue(coin);
            }
            maxCoins = valueInCoins;
        }

        // check if there's coins in the pool
        for (int i = 0; i < valueInCoins; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin;
                coin = coinsQueue.Dequeue();
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
                        Thulgran.ThulgranGold++;
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
                GameObject heart = hpQueue.Dequeue();
                heart.SetActive(true);

                // move hearts to the collected heart position
                heart.transform.position = sourceHP + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);


                // animate hearts to target position
                float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
                heart.transform.DOMove(targetPositionHP, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever heart reaches target position;
                        heart.SetActive(false);
                        hpQueue.Enqueue(heart);
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
                GameObject rune = manaQueue.Dequeue();
                rune.SetActive(true);

                // move coin to the collected coin position
                rune.transform.position = sourceMana + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);


                // animate coin to target position
                float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
                rune.transform.DOMove(targetPositionMana, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever mana runes reach target position;
                        rune.SetActive(false);
                        manaQueue.Enqueue(rune);
                    });
            }
        }
    }


    public void UseItem(ItemsManager item, int selectedCharacter, Vector2 target)
    {
        if (item.affectType == ItemsManager.AffectType.Hp)
        {
            UpdateHPTarget();
            chosenCharacter = selectedCharacter;
            AnimateHP(sourceHP, item.amountOfEffect, target);
            Debug.Log("UIAddHP called from CoinsManager");
        }

        if (item.affectType == ItemsManager.AffectType.Mana)
        {
            UpdateManaTarget();
            chosenCharacter = selectedCharacter;
            AnimateMana(sourceMana, item.amountOfEffect, target);
            Debug.Log("UIAddMana called from CoinsManager");
        }
    }

    public void SellItem(ItemsManager item)
    {
        UpdateCoins();
        AnimateCoins(sourceCoins, item.valueInCoins);
    }

    public void UpdateCoins()
    {
        targetPositionCoins = targetCoin.position;
        sourceCoins = sourceTransformCoin.position;
    }

    public void UpdateHPTarget()
    {
        targetPositionHP = targetHP.position;
        sourceHP = sourceTransformHP.position;
    }

    public void UpdateManaTarget()
    {
        targetPositionMana = targetMana.position;
        sourceMana = sourceTransformMana.position;
    }

    public void CoinUpdate(ItemsManager item)
    {
        Thulgran.ThulgranGold -= item.valueInCoins;
    }
}
