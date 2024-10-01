using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : State
{
    [SerializeField] Animator animator;
    [SerializeField] RoadLine roadLine;
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] float speed = 25.0f;
    [SerializeField] float positionX = 2.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private new void OnEnable()
    {
        base.OnEnable();

        InputManager.Instance.action += OnkeyUpdate;
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    private void OnkeyUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine != RoadLine.LEFT)
            {
                animator.Play("Left Avoid");

                roadLine--;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(roadLine != RoadLine.RIGHT)
            {
                animator.Play("Right Avoid");

                roadLine++;
            }
        }
    }

    private void Move()
    {
        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position,
            new Vector3((int)roadLine * positionX, 0, 0),
            speed * Time.fixedDeltaTime
        );
    }

    private void FixedUpdate()
    {
        if (state == false) return;

        Move();
    }

    private new void OnDisable()
    {
        base.OnDisable();

        InputManager.Instance.action -= OnkeyUpdate;
    }
}
