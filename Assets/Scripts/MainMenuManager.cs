using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour
{
    private int difficulty;
    private string currentTab = "none";
    [SerializeField] private TMP_InputField gameNameInputField;
    [SerializeField] private GameObject newGameBox;
    [SerializeField] private GameObject loadGameBox;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform itemContainer;

    public void NewGame_Btn()
    {
        // SceneManager.LoadScene(1);
        // // Execute code in the next scene
        // SceneManager.sceneLoaded += OnSceneLoaded;
        ChangeTab("newgame");
    }

    public void LoadGame_Btn()
    {
        ChangeTab("loadgame");
        // Clear previous items
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }
        // Load saved games
        List<Game> savedGames = GameManager.Instance.LoadAllGamesFromJson();

        foreach (Game game in savedGames)
        {
            GameObject item = Instantiate(itemPrefab, itemContainer);
            item.GetComponent<LoadGameItem>().SetData(game);
        }
    }

    private void ChangeTab(string tabName)
    {
        newGameBox.SetActive(currentTab == tabName ? false : tabName == "newgame");
        loadGameBox.SetActive(currentTab == tabName ? false : tabName == "loadgame");
        if (currentTab == tabName) tabName = "none";
        currentTab = tabName;
    }

    public void Dropdown_Changed(int value)
    {
        difficulty = value;
    }

    public void CreateNewGame()
    {
        GameManager.Instance.NewGame(gameNameInputField.text, difficulty);
    }

    public void CloseNewGameBox()
    {
        newGameBox.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            GameManager.Instance.SpawnPlayer(new Vector3(-1.802f, 0.376f, -0.705f));
            // Unsubscribe from the event to avoid multiple calls
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
