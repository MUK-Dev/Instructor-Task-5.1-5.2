using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    private void Start()
    {
        GameManager.Instance.OnScoreChange += GM_OnScoreChange;
        livesText.text = "Score: " + GameManager.Instance.GetScore().ToString();
    }

    private void GM_OnScoreChange(object sender, EventArgs e)
    {
        livesText.text = "Score: " + GameManager.Instance.GetScore().ToString();
    }
}
