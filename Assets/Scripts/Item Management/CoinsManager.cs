using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Sirenix.OdinInspector;


public class CoinsManager : MonoBehaviour
{
    [Header("Main connectors")]
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject animatedCoinPrefab;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] GameObject animatedHPPrefab;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] Transform target;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] Transform targetHP;

    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private Transform sourceTransform;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private Transform sourceTransformHP;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TMP_Text coinUIText;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] TMP_Text hpUIText;




    private Vector2 source;
    private Vector2 sourceHP;




    [Header("Available coins : (coins to pool)")]
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] int maxCoins;
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] int maxHP;
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] PlayerStats player;
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    private ItemsManager item;

    Queue<GameObject> coinsQueue = new Queue<GameObject>();
    Queue<GameObject> hpQueue = new Queue<GameObject>();

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




    Vector2 targetPosition;
    Vector2 targetPositionHP;

    // STRATEGIES

    // Could use the RemoveItems code to add in a variable for which animation trigger to use.  MenuManager.instance.animTrigger = item.GetComponent<Animator>().SetTrigger("ItemSold");

    // MenuManager is the only script that currently successful activates a trigger, with                 itemSlot.GetComponent<Animator>().SetTrigger("animatePlease");

    // As ever, the choice is between where to put the script and where to call the data that is thereby missing to make the script work


    private int _c = 0;

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

    private int _hp = 0;

    public int Hp
    {
        get { return _hp; }
        set
        {
            _hp = value;

            //update UI Text whenever "Coins variable is changed
            coinUIText.text = Hp.ToString();

        }
    }



    void Awake() {
       
        // prepare coins
        PrepareCoins();
        coinUIText.text = Coins.ToString();
        PrepareHP();
        hpUIText.text = Hp.ToString();

    }


    private void Start()
    {
        
    }

    void PrepareCoins() {
        for (int i = 0; i < maxCoins; i++)
        {
            GameObject coin;
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.SetParent(sourceTransform, false);
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





    public void Animate(Vector2 source, int valueInCoins) //previously 'collectedCoinPosition'
    {
        
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
                coin.transform.DOMove(targetPosition, duration)
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

    public void AnimateHP(Vector2 sourceHP, int amountOfEffect) //previously 'collectedCoinPosition' // amountOfEffect is called in Inventory.cs
    {

        for (int i = 0; i < amountOfEffect; i++)
        {
            // check if there's coins in the pool
            if (hpQueue.Count > 0)
            {
                GameObject hp = hpQueue.Dequeue();
                hp.SetActive(true);

                // move coin to the collected coin position
                hp.transform.position = sourceHP + new Vector2(Random.Range(-spread, spread), 0f);


                // animate coin to target position
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                hp.transform.DOMove(targetPositionHP, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever coin reach target position;
                        hp.SetActive(false);
                        coinsQueue.Enqueue(hp);
                        Hp++;
                    });

            }
        }


    }

    public void AddCoins(int valueInCoins) //previously 'collectedCoinPosition'
    {
        Animate(source, valueInCoins);
        
    }

    public void UIAddHp(int amountOfEffect) //previously 'collectedCoinPosition'
    {
        AnimateHP(sourceHP, amountOfEffect);

    }


    public void updateCoins() 
    {
        targetPosition = target.position;
        source = sourceTransform.position;
    }

    public void updateHP()
    {
        targetPositionHP = targetHP.position;
        sourceHP = sourceTransformHP.position;
    }
}