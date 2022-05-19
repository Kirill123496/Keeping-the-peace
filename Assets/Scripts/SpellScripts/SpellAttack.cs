using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class SpellAttack : MonoBehaviour
{
    private Animator _animSpell;
    private Rigidbody2D _spellRB;
    public GameObject _spellObject;
    [SerializeField] private float _speedSpell;

    private StatesSpell _stateSpell
    {
        set { _animSpell.SetInteger("stateSpell", (int)value); }
    }
    private void Start()
    {
        _spellRB =_spellObject.GetComponent<Rigidbody2D>();
        _animSpell =_spellObject.GetComponent<Animator>();
        CastSpell();
    }
    private void CastSpell()
    {
        _stateSpell = StatesSpell.waterSpell;
        _spellRB.velocity = new Vector2(_speedSpell, 0f);
        Destroy(_spellObject, 2);
    }
}
public enum StatesSpell
{
    waterSpell
}