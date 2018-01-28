using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    // Controls the GUI State
    public enum UIState
    {
        Initial,
        Game,
        Statistics
    }
    public UIState currentState;

    // INITIAL
    public string instruction; // instruction to give the player at the beginning

    // GAME
    private float timerValue; // the current time value
    private string timerText; // the time value in text
    public Texture2D timerTexture; // the clock texture

    // STATISTICS
    private string accuracyText; // the player accuracy

    // PAUSED
    private bool isPaused; // controls if the game is paused
    public Texture2D background;
    public Texture2D logo;

    public GUISkin skin; // GUI Skin

    void Update()
    {
        if (currentState == UIState.Game)
        {
            // increase the timer each second
            timerValue += Time.deltaTime;
        }
    }

    // OnGUI is called for rendering and handling GUI events.
    void OnGUI()
    {
        // Assign a new skin to the GUI
        GUI.skin = skin;

        if (isPaused)
        {
            // Background
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background, ScaleMode.StretchToFill);

            // Logo
            GUI.DrawTexture(new Rect(Screen.width * 0.05f,
                                     Screen.height * 0.05f,
                                     Screen.width * 0.9f,
                                     Screen.height * 0.2f), logo, ScaleMode.ScaleToFit);

            // Menu Rect
            Rect menuRect = new Rect(Screen.width * 0.05f,
                                Screen.height * 0.3f,
                                Screen.width * 0.2f,
                                Screen.height * 0.4f);

            // Menu
            GUILayout.BeginArea(menuRect);

            GUILayout.Label("Menu", skin.GetStyle("StatisticsTitle"));

            if (GUILayout.Button("Resume"))
            {

            }

            if (GUILayout.Button("Restart"))
            {

            }

            if (GUILayout.Button("Back"))
            {

            }

            GUILayout.EndArea();
        }

        switch (currentState)
        {
            case UIState.Initial:

                if (!isPaused)
                {
                    // Display the instructions
                    GUI.Label(new Rect(Screen.width * 0.2f,
                                       Screen.height * 0.03f,
                                       Screen.width * 0.6f,
                                       Screen.height * 0.05f),
                              instruction,
                              skin.GetStyle("InstructionLabel"));
                }

                break;

            case UIState.Game:

                if (!isPaused)
                {
                    // Get the timer value nicely formatted
                    timerText = GetTimerValue(timerValue);

                    // Display the timer value
                    GUI.Label(new Rect(Screen.width * 0.35f,
                                   Screen.height * 0.025f,
                                   Screen.width * 0.3f,
                                   Screen.height * 0.1f),
                              new GUIContent(timerText, timerTexture),
                              skin.GetStyle("TimerLabel"));
                }
                break;

            case UIState.Statistics:

                if (isPaused)
                {
                    // Statistics
                    Rect rect = new Rect(Screen.width * 0.35f,
                                         Screen.height * 0.3f,
                                         Screen.width * 0.3f,
                                         Screen.height * 0.4f);

                    GUILayout.BeginArea(rect);

                    GUILayout.Label("Statistics", skin.GetStyle("StatisticsTitle"));

                    // TIMER
                    GUILayout.BeginHorizontal();

                    GUILayout.Label("Total Time: ", skin.GetStyle("StatisticsLabel"));
                    GUILayout.Label(timerText, skin.GetStyle("StatisticsValue"));

                    GUILayout.EndHorizontal();

                    // TIMER    
                    GUILayout.BeginHorizontal();

                    GUILayout.Label("Accuracy: ", skin.GetStyle("StatisticsLabel"));
                    GUILayout.Label(accuracyText, skin.GetStyle("StatisticsValue"));

                    GUILayout.EndHorizontal();

                    GUILayout.EndArea();
                }

                break;
        }
    }

    public void StartGame()
    {
        currentState = UIState.Game;
    }

    private string GetTimerValue(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60F); // number of minutes equals the total time in seconds divide per 60
        int seconds = Mathf.FloorToInt(timer - minutes * 60); // the seconds need to reset each 60 seconds passed so we subtract the value of the minutes times 60

        // string with two items (0 - minutes and 1 - seconds) and both with 2 digits
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameIsOver(float totalTime, float accuracy)
    {
        // Change the GUI State
        currentState = UIState.Statistics;

        // Get the timer value nicely formatted
        timerText = GetTimerValue(totalTime);

        // Rounc to 2 decimals
        accuracyText = string.Format("{0:0.00} %", accuracy);
    }

    public void IsPaused(bool isPaused)
    {
        this.isPaused = isPaused;
    }
}