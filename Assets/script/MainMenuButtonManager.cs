using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenubuttonmanager : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    
    public void StartGamePressed()
    {
        Debug.Log($"{Pressed("New Game")}");
        
    }

    
    public void OptionsPressed()
    { var text = Pressed("Options");
    Debug.Log(text);
    }

    private string Pressed(string button)
    {
        return button + "Button Pressed";
    }

    public static void QuitPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
    }
#endif
    }
}