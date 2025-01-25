using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject optionsPopUp;
    public GameObject Buttons;
    public GameObject PauseGameSet;
    //public AudioManager am;


    private void Awake()
    {
        //am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //MAIN MENU UI
    public void OnStartButtonPressed()
    {

        SceneManager.LoadScene("Game");
        //Play the sound 
    }
    public void OnOptionsButtonPressed()
    {
        optionsPopUp.SetActive(true);
        Buttons.SetActive(false);
        //Play the sound
    }

    public void ClosePopup()
    {
        optionsPopUp.SetActive(false);
        Buttons.SetActive(true);
        //Play the sound
    }


    //IN GAME UI

    public void PauseGame()
    {
        PauseGameSet.SetActive(true);
        Time.timeScale = 0;
        //Play the sound
    }

    public void CountinueGame()
    {
        PauseGameSet.SetActive(false);
        Time.timeScale = 1;
        //Play the sound
    }
    public void HomeGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        //Play the sound
    }
}
