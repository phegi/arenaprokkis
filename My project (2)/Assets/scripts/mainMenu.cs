using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
public void playButton()
{
    SceneManager.LoadScene("SampleScene");
}
public void settingsButton()
{
    //GameObject.SetGameObjectsActive(true);
    
}
public void exitButton()
{
    Application.Quit();
}
}