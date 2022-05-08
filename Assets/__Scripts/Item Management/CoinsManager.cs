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

    public static CoinsManager Instance;

    [Header("Main connectors")] [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private GameObject animatedCoinPrefab;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private GameObject animatedHpPrefab;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private GameObject animatedManaPrefab;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private Transform targetCoin;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private Transform targetHp;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private Transform targetMana;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private Transform sourceTransformCoin;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private Transform sourceTransformHp;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private Transform sourceTransformMana;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private TextMeshProUGUI coinUIText;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private TextMeshProUGUI hpUIText;

    [TabGroup("UI references")] [GUIColor(1f, 1f, 0.215f)] [SerializeField]
    private TextMeshProUGUI manaUIText;


    private Vector2 _sourceCoins;
    private Vector2 _sourceHp;
    private Vector2 _sourceMana;

    private Vector2 _targetPositionCoins;
    private Vector2 _targetPositionHp;
    private Vector2 _targetPositionMana;


    [Header("Available coins : (coins to pool)")]
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField]
    private int maxCoins;

    [TabGroup("Miscellaneous")] [GUIColor(0.670f, 1, 0.560f)] [SerializeField]
    private int maxHp;

    [TabGroup("Miscellaneous")] [GUIColor(0.670f, 1, 0.560f)] [SerializeField]
    private int maxMana;

    [TabGroup("Miscellaneous")] [GUIColor(0.670f, 1, 0.560f)]
    private Queue<GameObject> _coinsQueue = new();

    private Queue<GameObject> _hpQueue = new();
    private Queue<GameObject> _manaQueue = new();

    [Header("Animation settings")]
    [TabGroup("New Group", "Animation settings")]
    [GUIColor(0.447f, 0.654f, 0.996f)]
    [SerializeField]
    [Range(0.5f, 0.9f)]
    private float minAnimDuration;

    [TabGroup("New Group", "Animation settings")] [GUIColor(0.447f, 0.654f, 0.996f)] [SerializeField] [Range(0.9f, 2f)]
    private float maxAnimDuration;

    [TabGroup("New Group", "Animation settings")] [GUIColor(0.447f, 0.654f, 0.996f)] [SerializeField]
    private Ease easeType;

    [TabGroup("New Group", "Animation settings")] [GUIColor(0.447f, 0.654f, 0.996f)] [SerializeField]
    private float spread;

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
        Instance = this;

        PrepareCoins();
        PrepareHp();
        PrepareMana();
    }

    private void PrepareCoins()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            GameObject coin;
            coin = Instantiate(animatedCoinPrefab, sourceTransformCoin, false);
            coin.SetActive(false);
            _coinsQueue.Enqueue(coin);
        }
    }

    private void PrepareHp()
    {
        for (int i = 0; i < maxHp; i++)
        {
            GameObject hp;
            hp = Instantiate(animatedHpPrefab, sourceTransformHp, false);
            hp.SetActive(false);
            _hpQueue.Enqueue(hp);
        }
    }

    private void PrepareMana()
    {
        for (int i = 0; i < maxMana; i++)
        {
            GameObject mana;
            mana = Instantiate(animatedManaPrefab, sourceTransformMana, false);
            mana.SetActive(false);
            _manaQueue.Enqueue(mana);
        }
    }

    public void AnimateCoins(Vector2 source, int valueInCoins)
    {
        if (maxCoins < valueInCoins)
        {
            for (int j = 0; j < valueInCoins - maxCoins + 1; j++)
            {
                GameObject coin;
                coin = Instantiate(animatedCoinPrefab, sourceTransformCoin, false);
                coin.SetActive(false);
                _coinsQueue.Enqueue(coin);
            }

            maxCoins = valueInCoins;
        }

        // check if there's coins in the pool
        for (int i = 0; i < valueInCoins; i++)
        {
            if (_coinsQueue.Count <= 0) { continue; }

            GameObject coin;
            coin = _coinsQueue.Dequeue();
            coin.SetActive(true);

            // move coin to the collected coin position
            coin.transform.position = source + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);

            // animate coin to target position
            float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
            coin.transform.DOMove(_targetPositionCoins, duration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    // executes whenever coin reach target position;
                    coin.SetActive(false);
                    _coinsQueue.Enqueue(coin);
                    Thulgran.ThulgranGold++;
                });
        }
    }

    public void AnimateHp(Vector2 sourceHp, int amountOfEffect, Vector2 receivedTarget)
    {
        // trying to assign a target position to player image

        _targetPositionHp = receivedTarget;

        Debug.Log("Animate HP called");
        for (int i = 0; i < amountOfEffect; i++)
        {
            // check if there's hearts in the pool
            if (_hpQueue.Count > 0)
            {
                GameObject heart = _hpQueue.Dequeue();
                heart.SetActive(true);

                // move hearts to the collected heart position
                heart.transform.position = sourceHp + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);


                // animate hearts to target position
                float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
                heart.transform.DOMove(_targetPositionHp, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever heart reaches target position;
                        heart.SetActive(false);
                        _hpQueue.Enqueue(heart);
                    });
            }
        }
    }

    public void AnimateMana(Vector2 sourceMana, int amountOfEffect, Vector2 receivedTarget)
    {
        // assigning target position to polayer image

        _targetPositionMana = receivedTarget;

        Debug.Log("Animate runes called");
        for (int i = 0; i < amountOfEffect; i++)
        {
            // check if there's coins in the pool
            if (_manaQueue.Count > 0)
            {
                GameObject rune = _manaQueue.Dequeue();
                rune.SetActive(true);

                // move coin to the collected coin position
                rune.transform.position = sourceMana + new Vector2(UnityEngine.Random.Range(-spread, spread), 0f);


                // animate coin to target position
                float duration = UnityEngine.Random.Range(minAnimDuration, maxAnimDuration);
                rune.transform.DOMove(_targetPositionMana, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever mana runes reach target position;
                        rune.SetActive(false);
                        _manaQueue.Enqueue(rune);
                    });
            }
        }
    }


    public void UseItem(Item item, int selectedCharacter, Vector2 target)
    {
        if (item.affectType == AffectType.Hp)
        {
            UpdateHpTarget();
            chosenCharacter = selectedCharacter;
            AnimateHp(_sourceHp, item.amountOfEffect, target);
            Debug.Log("UIAddHP called from CoinsManager");
        }

        if (item.affectType == AffectType.Mana)
        {
            UpdateManaTarget();
            chosenCharacter = selectedCharacter;
            AnimateMana(_sourceMana, item.amountOfEffect, target);
            Debug.Log("UIAddMana called from CoinsManager");
        }
    }

    public void SellItem(Item item)
    {
        UpdateCoins();
        AnimateCoins(_sourceCoins, item.valueInCoins);
    }

    public void UpdateCoins()
    {
        _targetPositionCoins = targetCoin.position;
        _sourceCoins = sourceTransformCoin.position;
    }

    public void UpdateHpTarget()
    {
        _targetPositionHp = targetHp.position;
        _sourceHp = sourceTransformHp.position;
    }

    public void UpdateManaTarget()
    {
        _targetPositionMana = targetMana.position;
        _sourceMana = sourceTransformMana.position;
    }

    public void CoinUpdate(Item item)
    {
        Thulgran.ThulgranGold -= item.valueInCoins;
    }
}