using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gc;
    private static Doorman[] _doormen;
    public byte levelIndex;

    private void Awake()
    {
        _doormen = FindObjectsByType<Doorman>(FindObjectsSortMode.None);
        if (!gc)
            gc = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    
    public void ResetDoormen()
    {
        foreach (var dm in _doormen)
        {
            dm.ResetChildren();
        }
    }

    public void NextLevel()
    {
        levelIndex++;
        var nextSceneIndex = levelIndex % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}