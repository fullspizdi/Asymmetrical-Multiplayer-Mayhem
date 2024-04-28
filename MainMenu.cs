using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// MainMenu class for handling the main menu UI and navigation.
/// </summary>
public class MainMenu : MonoBehaviour
{
    private Button startGameButton;
    private Button exitGameButton;
    private GameObject mainMenuPanel;

    /// <summary>
    /// Initializes the main menu components.
    /// </summary>
    void Start()
    {
        mainMenuPanel = GameObject.Find("MainMenuPanel");
        startGameButton = GameObject.Find("StartGameButton").GetComponent<Button>();
        exitGameButton = GameObject.Find("ExitGameButton").GetComponent<Button>();

        startGameButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);

        LoadMainMenuAssets();
    }

    /// <summary>
    /// Loads the assets required for the main menu.
    /// </summary>
    private void LoadMainMenuAssets()
    {
        try
        {
            Logger.Log("Loading main menu assets.");
            GameObject background = GameObject.Find("MainMenuBackground");
            background.GetComponent<Image>().sprite = AssetManager.GetAsset("MainMenuBackground") as Sprite;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error loading main menu assets: {ex.Message}");
        }
    }

    /// <summary>
    /// Starts the game by navigating from the main menu to the game scene.
    /// </summary>
    private void StartGame()
    {
        Logger.Log("Start game button clicked.");
        Networking.StartServer(); // Start the server when the game starts
        mainMenuPanel.SetActive(false);
        // Assuming there's a scene manager to handle scene transitions
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    private void ExitGame()
    {
        Logger.Log("Exit game button clicked.");
        Application.Quit();
    }
}
