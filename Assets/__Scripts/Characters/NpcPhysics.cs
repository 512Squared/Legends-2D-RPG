using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class NpcPhysics : MonoBehaviour
{
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public float speed;

    public float changeTime;

    private float timer;
    private int direction = 1;
    public bool startLeft;


    [SerializeField] private bool vertical;

    [SerializeField]
    private Transform characterTransform;

    private new Rigidbody2D rigidbody2D;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        changeTime = 5.0f;
        timer = changeTime;
        speed = 1.0f;
        if (startLeft) { direction = -direction; }
    }


    private void Update()
    {
        // transform.position = new Vector3(
        //     Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
        //     Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
        //     Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        // );


        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            //vertical = !vertical;
            timer = changeTime;
            characterTransform.localScale =
                new Vector3(characterTransform.localScale.x * -1, characterTransform.localScale.y, characterTransform
                    .localScale.z);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y += Time.deltaTime * speed * direction;
        }

        else
        {
            position.x += Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
    {
        bottomLeftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
    }
}