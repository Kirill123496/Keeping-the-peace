using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelList : MonoBehaviour
{
    public void OpenLevelsList()
    {
        SceneManager.LoadScene(1);
    }
}
