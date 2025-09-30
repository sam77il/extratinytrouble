using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject playerPrefab;

    public Game CurrentGame { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnPlayer(Vector3 position)
    {
        Instantiate(playerPrefab, position, Quaternion.identity);
    }

    private void SaveGameToJson()
    {
        string path = Application.persistentDataPath + "/games.json";

        // Wenn keine Datei existiert → leeren Wrapper speichern
        if (!System.IO.File.Exists(path))
        {
            GameListWrapper emptyWrapper = new GameListWrapper { games = new Game[0] };
            System.IO.File.WriteAllText(path, JsonUtility.ToJson(emptyWrapper, true));
        }

        // JSON einlesen
        string json = System.IO.File.ReadAllText(path);

        // In Wrapper konvertieren
        GameListWrapper wrapper = JsonUtility.FromJson<GameListWrapper>(json);

        // In Liste umwandeln
        List<Game> gameList = new List<Game>(wrapper.games);

        // Neues Spiel hinzufügen
        gameList.Add(CurrentGame);

        // Zurück in Wrapper packen
        wrapper.games = gameList.ToArray();

        // JSON speichern (mit prettyPrint = true)
        json = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, json);

        Debug.Log("Game saved to " + path);
    }

    public List<Game> LoadAllGamesFromJson()
    {
        string path = Application.persistentDataPath + "/games.json";

        if (!System.IO.File.Exists(path))
        {
            Debug.LogWarning("No save file found at " + path);
            return new List<Game>();
        }

        string json = System.IO.File.ReadAllText(path);
        GameListWrapper wrapper = JsonUtility.FromJson<GameListWrapper>(json);
        return new List<Game>(wrapper.games);
    }

    public void NewGame(string name, int diff = 0)
    {
        int finalLives = 10;
        if (diff == 1) finalLives = 5;
        else if (diff == 2) finalLives = 1;
        CurrentGame = new Game
        {
            gameName = name,
            difficulty = diff,
            level = 1,
            lifes = finalLives,
            date = System.DateTime.Now
        };
        SaveGameToJson();
        LoadGame(CurrentGame);
    }

    public void LoadGame(Game game)
    {
        CurrentGame = game;
        // Load the saved scene
        SceneManager.LoadScene(game.level);
    }

    public void UpdateLifes(string operation, int amount)
    {
        if (CurrentGame != null)
        {
            if (operation == "add") CurrentGame.lifes += amount;
            else if (operation == "rem") CurrentGame.lifes -= amount;
            else if (operation == "set") CurrentGame.lifes = amount;

            SaveGameToJson();
        }
    }
}
