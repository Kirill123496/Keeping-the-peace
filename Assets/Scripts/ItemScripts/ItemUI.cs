using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField] public int _item;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Sprite _spriteUncommonItem;
    [SerializeField] private Sprite _spriteRareItem;
    [SerializeField] private Sprite _spriteEpicItem;
    [SerializeField] private Sprite _spriteLegendaryItem;
    [SerializeField] private GameObject[] _objectSpriteSlot = new GameObject[6];
    [SerializeField] private Sprite[] _spriteItemSlot = new Sprite[6];

    [SerializeField] private Items _items;

    public void StatePlus()
    {
        
    }
    private void Start()
    {
        _gameObject.GetComponent<SpriteRenderer>().sprite = RareSprite();
        _objectSpriteSlot[SlotItemNum()].GetComponent<SpriteRenderer>().sprite = SlotItem();
        _items.GetComponent<Items>();
    }
    private Sprite RareSprite()
    {
        if (_items.ItemRare(_item) == "uncommon")
        {
            return _spriteUncommonItem;
        }
        if (_items.ItemRare(_item) == "rare")
        {
            return _spriteRareItem;
        }
        if (_items.ItemRare(_item) == "epic")
        {
            return _spriteEpicItem;
        }
        if (_items.ItemRare(_item) == "legendary")
        {
            return _spriteLegendaryItem;
        }
        else return null;
    }

    private int SlotItemNum()
    {
        return _items.ItemSlot(_item);
    }
    private Sprite SlotItem()
    {
        return _items.ItemSlot(_item) == 0 ? _spriteItemSlot[0] :
            _items.ItemSlot(_item) == 1 ? _spriteItemSlot[1]:
            _items.ItemSlot(_item) == 2 ? _spriteItemSlot[2]:
            _items.ItemSlot(_item) == 3 ? _spriteItemSlot[3]:
            _items.ItemSlot(_item) == 4 ? _spriteItemSlot[4]:
            _items.ItemSlot(_item) == 5 ? _spriteItemSlot[5]: null;
        
    }
    private int IntelectItem()
    {
        return _items.ItemIntelect(_item);
    }
    private int AgilityItem()
    {
        return _items.ItemAgility(_item);
    }
    private int StrenghtItem()
    {
        return _items.ItemStrength(_item);
    }
    private int StaminaItem()
    {
        return _items.ItemStamina(_item);
    }
    private string NameItem()
    {
        return _items.ItemName(_item);
    }
    private int CollHand()
    {
        return _items.ItemCollHand(_item);
    }
}
