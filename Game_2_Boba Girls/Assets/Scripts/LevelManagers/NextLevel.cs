using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour {

    public int levelSelect;
    public void switchLevel()
    {
        SceneManager.LoadScene(levelSelect);
    }
}
