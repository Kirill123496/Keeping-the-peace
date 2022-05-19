using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Player play;
    [SerializeField] private MoneyUI mone;
    [SerializeField] private GameObject _itemsObject;
    private ItemUI _itemUINumber;
    [SerializeField] private int _itemNumber;

    public void Start()
    {
        _itemUINumber = _itemsObject.GetComponent<ItemUI>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")&& play._moneyPlayer>=100)
        {
            play._moneyPlayer -= 100;
            mone.MoneyPlayer();
            Destroy(gameObject);
        }
    }
    public void OnMouseEnter()
    {
        Instantiate(_itemsObject);
        _itemUINumber._item = _itemNumber;
        Debug.Log("Наведение");

    }
    public void OnMouseExit()
    {
        Destroy(this._itemsObject);
    }
}
