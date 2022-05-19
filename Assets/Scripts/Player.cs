using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields
    public LayerMask _whatIsGround;
    public LayerMask _wathIsWall;
    public Transform _groundCheck;
    public Transform _wallCheck;
    public bool _isGrounded;
    public bool _isWall;

    public int _moneyPlayer;
    public MoneyUI money;

    [SerializeField] public float _jumpForce;
    [SerializeField] public float _speed;

    private Rigidbody2D _rb;
    public bool _isLookingLeft;
    private Animator _anim;
    [SerializeField]private GameObject _spellObject;

    private int _mana = 100;
    private int _hp = 100;
    private int _stamina;
    private int _intelect;
    private int _agility;
    private int _lvl = 1;
    private float _expLvlUp =100f;
    private float _exp;
    private int _speedAtack;
    private int _protect;
    
    public bool active;
    public float cooldown;
    public float timer;
    #endregion
    public static Player Instance;
    private States _state
    {
        get { return (States)_anim.GetInteger("state"); }
        set { _anim.SetInteger("state", (int)value); }
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_isGrounded) _state = States.idle;
        if (Input.GetButton("Horizontal")) Run();
            if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
            _isGrounded = false;
        }
        if (Input.GetButton("Fire1")) Attack1();
        if (Input.GetButton("Fire1") && !_isGrounded) AirAttack1();
        if (Input.GetButton("Fire2")) Attack2();
        if(Input.GetButton("Fire2") && !_isGrounded) AirAttack2();
        if (active) timer -= Time.deltaTime;

    }
    private void Run()
    {
        if (_isGrounded) _state = States.run;
        float _x = Input.GetAxis("Horizontal");
        Vector3 _move = new Vector3(_x * _speed, _rb.velocity.y, 0f);
        _rb.velocity = _move;
        if (_x < 0 && !_isLookingLeft)
            Turn();
        if (_x > 0 && _isLookingLeft)
            Turn();
    }
    private void FixedUpdate()
    {
        CheckGround();
        Fall();
        WallCheck();
        if (Input.GetButton("Spell")&& !active)
        {
            _spellObject.transform.position = new Vector3(_wallCheck.position.x,_wallCheck.position.y + 0.3f,0f);
            Instantiate(_spellObject);
            active = true;
            timer = cooldown;
        }
        if (timer < 0)
        {
            timer = 0;
            active = false;
        }
        Stats();
    }
    #region Stats
    private void Stats()
    {
        if (_exp == _expLvlUp)
        {
            LvlUP();

        }
        HP();
        Mana();
    }
    private int Agality(int agility)
    {
        return agility * 7;
    }
    private void SpeedAndProtect()
    {
        _speed += Agality(_agility) / 14;
        _speedAtack += Agality(_agility);
        _protect += Agality(_agility) * 2;
    }
    private int Intelect(int intelect)
    {
        return intelect * 8;
    }
    private void Mana()
    {
        _mana += Intelect(_intelect);
    }
    private int Stamina(int stamina)
    {
        return stamina*10;
    }
    private void HP()
    {
        _hp += Stamina(_stamina);
    }

    private void LvlUP()
    {
        _lvl += 1;
        _stamina += Random.Range(1, 2);
        _intelect += Random.Range(1, 2);
        _agility += Random.Range(1, 2);
        _expLvlUp += Mathf.Floor(_expLvlUp / 2.5f);
    }
    #endregion

    #region Move
    private void Fall()
    {
        if (_rb.velocity.y < 0) _state = States.fall;
    }
    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapPoint(_groundCheck.position, _whatIsGround);
        if (!_isGrounded) _state = States.jump;
    }
    private void WallCheck()
    {
        _isWall = Physics2D.OverlapPoint(_wallCheck.position, _wathIsWall);
        if (_isWall) _state = States.wall;
    }
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
    private void Turn()
    {
        _isLookingLeft = !_isLookingLeft;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void Attack1()
    {
        _state = States.attack1;
    }
    private void Attack2()
    {
        _state = States.attack2;
    }
    private void AirAttack1()
    {
        _state = States.airAttack1;
    }
    private void AirAttack2()
    {
        _state = States.airAttack2;
    }
    #endregion
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Money"))
        {
            money.CoinPlus();
        }
    }
}

public enum States
{
    idle,
    run,
    jump,
    fall,
    attack1,
    attack2,
    wall,
    airAttack1,
    airAttack2,
    castSpell
}
