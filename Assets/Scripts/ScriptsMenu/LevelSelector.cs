using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] _levels;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = 0; i < _levels.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                _levels[i].interactable = false;
            }
        }
    }

   
    public void Select(int numberInBuild)
    {
        SceneManager.LoadScene(numberInBuild);
    }
}
