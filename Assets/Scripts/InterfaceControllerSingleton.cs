using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public static InterfaceController ic;
    private TMP_Text level;
    public string Level
    {
        get { return level.text; }
        set { level.text = value; }
    }
    private TMP_Text hp;
    public TMP_Asset playerMode;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (ic == null)
            ic = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        gameOverPanel.SetActive(false);
    }

}
