using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject beginMenu;
    public GameObject settingsMenu;
    public GameObject quitMenu;
    public GameObject audioMenu;
    public GameObject fullscreenMenu;
    public GameObject backMenu;
    private Camera cam;
    private bool canPress;
    public AudioSource blop;
    public AudioSource start;
    
    GameObject[] baseMenuList;
    GameObject[] settingsMenuList;

    int currentBaseButton;
    int currentSettingsButton;
    
    bool isSettings;
    bool isAudio;
    bool isFullscreen;

    void Start() {

        // current button highlighted in main menu
        currentBaseButton = 0;

        // current button highlighted in settings 
        currentSettingsButton = 0;
        cam = Camera.main;
        baseMenuList = new GameObject[] {beginMenu, settingsMenu, quitMenu};
        settingsMenuList = new GameObject[] {audioMenu, fullscreenMenu, backMenu};
        isSettings = false;
        isAudio = true;
        isFullscreen = false;
    }

    // almost every check is based on if you're in the settings menu
    void Update() {

        bool reset = false;
        canPress = GameObject.Find("BaseMenu").GetComponent<PressSpaceAppear>().timerReached;

        if (canPress) { 

            // moves left
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                if (isSettings) {
                    currentSettingsButton = LeftMenu(currentSettingsButton);
                }
                if (!isSettings) {
                    currentBaseButton = LeftMenu(currentBaseButton);
                }
                blop.Play();
                reset = true;
            }

            // moves right
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                if (isSettings) {
                    currentSettingsButton = RightMenu(currentSettingsButton);
                }
                if (!isSettings) {
                    currentBaseButton = RightMenu(currentBaseButton);
                }
                blop.Play();
                reset = true;
            }

            // selects current highlighted button
            if (Input.GetKeyDown(KeyCode.Space)) {
                blop.Play();
                if (isSettings) {
                    switch (currentSettingsButton) {
                        case 0: 
                            ToggleAudio();
                            break;
                        case 1:
                            ToggleFullscreen();
                            break;
                        case 2:
                            isSettings = false;
                            break;
                    }   
                }
                else {
                    switch (currentBaseButton) {
                        case 0:
                            PlayGame();
                            break;
                        case 1:
                            isSettings = true;
                            break;
                        case 2:
                            ExitGame();
                            break;
                    }      
                }
            }
        }

            // whichever button is highlighted, color will turn white
            for (int i = 0; i < 3; i++) {
                
                List<Text> baseTexts;
                List<Animator> baseAnimations;
                List<Text> settingsTexts;
                List<Animator> settingsAnimations;

                baseTexts = new List<Text>(baseMenuList[i].GetComponentsInChildren<Text>());
                baseAnimations = new List<Animator>(baseMenuList[i].GetComponentsInChildren<Animator>());
                settingsTexts = new List<Text>(settingsMenuList[i].GetComponentsInChildren<Text>());
                settingsAnimations = new List<Animator>(settingsMenuList[i].GetComponentsInChildren<Animator>());

                foreach (var letter in baseTexts) { 
                    if (!isSettings) {            
                        Color temp;
                        temp = letter.color;

                        if (i == currentBaseButton) {
                            temp.a = 1f;
                        }
                        else {
                            temp.a = 0.5f;
                        }
                        letter.color = temp;
                    }
                    else {
                        Color temp;
                        temp = letter.color;
                        temp.a = 0f;
                        letter.color = temp;
                    }
                }

                foreach (var letter in settingsTexts) { 
                    if (!isSettings) {            
                        Color temp;
                        temp = letter.color;
                        temp.a = 0f;
                        letter.color = temp;
                    }
                    else {
                        Color temp;
                        temp = letter.color;

                        if (i == currentSettingsButton) {
                            temp.a = 1f;
                        }
                        else {
                            temp.a = 0.5f;
                        }
                        letter.color = temp;
                    }
                }
            }
        
    }

    // starts game and loads first scene
    public void PlayGame() {
        start.Play();
        SceneManager.LoadScene(1);
    }

    // quit game
    public void ExitGame() {
        Application.Quit();
    }

    // loops back to right if left arrow is pressed on leftmost button
    public int LeftMenu(int num) {
        if (num == 0) {
            return 2;
        } 
        else {
            return (num - 1);
        }
    }

    // loops back to left if right arrow is pressed on rightmost button
    public int RightMenu(int num) {
        if (num == 2) {
            return 0;
        } 
        else {
            return (num + 1);
        }
    }

    // changes text on audio setting if on or off
    public void ToggleAudio() {
        List<Text> statusText;
        statusText = new List<Text>(audioMenu.GetComponentsInChildren<Text>());
        int last = statusText.Count - 1;
        if (isAudio) {
            statusText[last].text = "F";
            statusText[last-1].text = "F";
            statusText[last-2].text = "O";
            AudioListener.pause = true;
            isAudio = false;
        }
        else {
            statusText[last].text = "";
            statusText[last-1].text = "N";
            statusText[last-2].text = "O";
            AudioListener.pause = false;
            isAudio = true;
        }
    }

// changes text on fullscreen setting if on or off
    public void ToggleFullscreen() {
        List<Text> statusText;
        statusText = new List<Text>(fullscreenMenu.GetComponentsInChildren<Text>());
        int last = statusText.Count - 1;
        if (isFullscreen) {
            statusText[last].text = "F";
            statusText[last-1].text = "F";
            statusText[last-2].text = "O";
            isFullscreen = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else {
            statusText[last].text = "";
            statusText[last-1].text = "N";
            statusText[last-2].text = "O";
            isFullscreen = true;
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
     
    }
}
