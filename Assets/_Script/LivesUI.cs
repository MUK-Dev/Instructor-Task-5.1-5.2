using System;
using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    private void Start()
    {
        GameManager.Instance.OnLivesChange += GM_OnLivesChange;
        livesText.text = "Lives: " + GameManager.Instance.GetLives().ToString();
    }

    private void GM_OnLivesChange(object sender, EventArgs e)
    {
        livesText.text = "Lives: " + GameManager.Instance.GetLives().ToString();
    }
}
