using UnityEngine.UI;
using UnityEngine;

public class HP : MonoBehaviour
{

    [SerializeField] private int _lives;
    [SerializeField] private int _healts;

    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite _deadheart;

    public static HP Instance;

    public void GetDamage()
    {
        _lives -= 1;
        Debug.Log(_lives);
    }
}
