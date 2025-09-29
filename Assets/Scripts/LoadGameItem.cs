using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadGameItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameNameText;
    [SerializeField] private TextMeshProUGUI gameDateText;
    [SerializeField] private TextMeshProUGUI gameDifficultyText;
    [SerializeField] private TextMeshProUGUI gameLevelText;
    [SerializeField] private TextMeshProUGUI gameDeathsText;

    public void SetData(Game game)
    {
        gameNameText.text = game.gameName;
        gameDateText.text = game.date.ToString("dd.MM.yyyy");
        gameLevelText.text = game.level.ToString();
        gameDeathsText.text = game.deaths.ToString();

        if (game.difficulty == 0) gameDifficultyText.text = "Einfach";
        else if (game.difficulty == 1) gameDifficultyText.text = "Mittel";
        else if (game.difficulty == 2) gameDifficultyText.text = "Schwer";

        gameObject.GetComponent<Button>().onClick.AddListener(() => LoadGame(game));
    }

    private void LoadGame(Game game)
    {
        GameManager.Instance.LoadGame(game);
    }
}
