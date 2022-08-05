using Assets.HeroEditor4D.Common.CharacterScripts;
using HeroEditor4D.Common.Enums;
using UnityEngine;
using DG.Tweening;


/// <summary>
/// An example of how to handle user input, play animations and move a character.
/// </summary>
public class Movement : MonoBehaviour
{
    public Character4D character;
    public Transform greenBase;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpDistance;

    public int movementSpeed;

    private static readonly int SPEED = Animator.StringToHash("speed");

    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private float jumpTime;

    public bool initDirection;
    public bool moving;
    private bool isJumping;

    public void Start()
    {
        character.AnimationManager.SetState(CharacterState.Idle);

        if (initDirection)
        {
            character.SetDirection(Vector2.down);
        }
    }

    public void Update()
    {
        SetSpeed();
        SetDirection();
        Move();
        Actions();
    }

    private void SetSpeed()
    {
        float speedPercent = GetComponent<Rigidbody2D>().velocity.magnitude / movementSpeed;
        character.AnimationManager.Animator.SetFloat(SPEED, speedPercent);
    }

    private void SetDirection()
    {
        Vector2 direction;

        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else { return; }

        character.SetDirection(direction);
    }

    private void Move()
    {
        if (movementSpeed == 0) return;

        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (direction == Vector2.zero)
        {
            if (moving)
            {
                character.AnimationManager.SetState(CharacterState.Idle);
                moving = false;
            }
        }
        else
        {
            character.AnimationManager.SetState(CharacterState.Run);
            character.transform.position += (Vector3)direction.normalized * movementSpeed * Time.deltaTime;
            moving = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            character.AnimationManager.SetState(CharacterState.Jump);
            float yPos = transform.position.y;
            if (character.Direction == Vector2.left)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(rb.DOJump(new Vector3(transform.position.x - jumpDistance, transform.position.y, 0),
                    jumpPower, 1,
                    jumpTime));
                sequence.Insert(0,
                    greenBase.DOMove(new Vector3(transform.position.x - jumpDistance, yPos, 0), jumpTime));
            }

            if (character.Direction == Vector2.right)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(rb.DOJump(new Vector3(transform.position.x + jumpDistance, transform.position.y, 0),
                    jumpTime, 1, 
                    jumpTime));
                sequence.Insert(0,
                    greenBase.DOMove(new Vector3(transform.position.x + jumpDistance, yPos, 0), jumpTime));
            }

            isJumping = false;
        }
    }

    private void Actions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            character.AnimationManager.Slash(character.WeaponType == WeaponType.Melee2H);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            character.AnimationManager.Jab();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            character.AnimationManager.SecondaryShot();
        }
    }
}