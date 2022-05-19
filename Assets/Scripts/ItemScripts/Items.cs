using System.IO;
using UnityEngine;

public class Items : MonoBehaviour
{
    #region Pole
    private readonly string _itemSave = @"Assets\\Items\Items.txt";

    private string[] _item;
    private string[,] _itemState;
    private string[] _stroke;
    #endregion
    public void FileSave()
    {
        _itemState = new string[80, 11];
        _item = File.ReadAllLines(_itemSave);

        for (int i = 0; i < _item.Length; i++)
        {
            _stroke = _item[i].Split(' ');

            for (int j = 0; j < _stroke.Length; j++)
            {
                _itemState[i, j] = _stroke[j];
            }
        }
    }
    #region Metods
    public int ItemPrice( int _item)
    {
        return int.Parse(_itemState[_item, 10]);
    }
    public int ItemPriceSell(int _item)
    {
        return ItemPrice(_item) / 10;
    }
    
    public string ItemName(int _item)
    {
        FileSave();
        return _itemState[_item, 0] + " " + _itemState[_item, 1];
    }
    public int ItemSlot(int _item)
    {
        FileSave();
        return int.Parse(_itemState[_item, 2]);
    }
    public int ItemCollHand(int _item)
    {
        FileSave();
        return int.Parse(_itemState[_item, 3]);
    }
    public string ItemRare(int _item)
    {
        FileSave();
        return _itemState[_item, 4];
    }
    public string ItemType(int _item)
    {
        FileSave();
        return _itemState[_item, 5];
    }
    public int ItemIntelect(int _item)
    {
        FileSave();
        return int.Parse(_itemState[_item, 6]);
    }
    public int ItemAgility(int _item)
    {
        FileSave();
        return int.Parse(_itemState[_item, 7]);
    }
    public int ItemStrength(int _item)
    {
        FileSave();
        return int.Parse(_itemState[_item, 8]);
    }
    public int ItemStamina(int _item)
    {
        FileSave();
        return int.Parse(_itemState[_item, 9]);
    }
    #endregion
}