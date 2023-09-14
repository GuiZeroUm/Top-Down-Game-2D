using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float runSpeed;

    private float initialSpeed;
    bool _isRunning;
    bool _isRolling;

    Rigidbody2D rig;
    Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        onInput();
        onRun();
        onRolling();
    }

    private void FixedUpdate()
    {
        onMove();
    }

    #region Movement

    void onInput ()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void onMove ()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void onRun ()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void onRolling ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isRolling = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _isRolling = false;
        }
    }

    #endregion

}
