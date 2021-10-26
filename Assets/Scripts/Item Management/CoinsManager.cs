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
    [SerializeField] Transform target;
    [TabGroup("UI references")]
    [GUIColor(1f, 1f, 0.215f)]
    [SerializeField] private Transform sourceTransform;
    private Vector2 source;




    [Header("Available coins : (coins to pool)")]
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] int maxCoins;
    [TabGroup("Miscellaneous")]
    [GUIColor(0.670f, 1, 0.560f)]
    [SerializeField] PlayerStats player;
    
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

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





    Vector2 targetPosition;

    // STRATEGIES

    // Could use the RemoveItems code to add in a variable for which animation trigger to use.  MenuManager.instance.animTrigger = item.GetComponent<Animator>().SetTrigger("ItemSold");

    // MenuManager is the only script that currently successful activates a trigger, with                 itemSlot.GetComponent<Animator>().SetTrigger("animatePlease");

    // As ever, the choice is between where to put the script and where to call the data that is thereby missing to make the script work


    void Awake() {
       
        // prepare coins
        PrepareCoins();
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

    public void Animate(Vector2 source, int amount) //previously 'collectedCoinPosition'
    {
        
        for (int i = 0; i < amount; i++)
        {
            // check if there's coins in the pool
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);

                // move coin to the collected coin position
                coin.transform.position = sourceTransform.position;


                // animate coin to target position
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPosition, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // executes whenever coin reach target position;
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);


                    });

            }
        }

    }

    public void AddCoins(int amount) //previously 'collectedCoinPosition'
    {
        //amount = 7;
        Animate(source, amount);
    }


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void updateCoins() 
        {
        targetPosition = target.position;
        source = sourceTransform.position;
    }
}
