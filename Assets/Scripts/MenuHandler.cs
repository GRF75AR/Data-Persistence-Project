using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public GameObject inputField;
    public TMP_Text bestScoreText;

    private void Start()
    {
        bestScoreText.text = UiManager.Instance.BestScorePlayer + " - " + UiManager.Instance.BestScore;
    }

    public void StartNew()
    {
        UiManager.Instance.PlayerName = inputField.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
