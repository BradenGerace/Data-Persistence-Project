using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public static string username;

    public static MenuUI Instance;

    public TextMeshProUGUI highScoreText;

    public static int highScore;

    public TextMeshProUGUI playerNameSaved;

    private void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (username != null)
        {
            usernameInput.text = username;
        }

        highScoreText.text = ("High Score: " + highScore);

        playerNameSaved.text = username;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public TMP_InputField usernameInput;
    }

    

    public void SaveUsername(string newName)
    {
        username = newName;
    }

    public void PlayGame()
    {
        SaveUsername(username);

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
