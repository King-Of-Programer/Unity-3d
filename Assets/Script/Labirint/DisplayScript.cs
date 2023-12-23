using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]
    private TMPro.TextMeshProUGUI score;
    [SerializeField]
    private TMPro.TextMeshProUGUI level;
    [SerializeField]
    private Image image1;
    [SerializeField]
    private Image image2;
    private float gameTime;
    void Start()
    {
        LabirintState.AddPropertyListener(nameof(LabirintState.checkPoint1Amount), OnCheckpoint1AmountChanged);
        LabirintState.AddPropertyListener(nameof(LabirintState.checkPoint2Amount), OnCheckpoint2AmountChanged);
        LabirintState.AddPropertyListener(nameof(LabirintState.gameLevel), OnGameLevelChanged);
        gameTime = 0f;
        LabirintState.score = 100;
        LabirintState.gameLevel = 1;
        score.text = $"Score: {LabirintState.score}";
    }
    void Update()
    {
        gameTime += Time.deltaTime;
    }
    private void LateUpdate()
    {
        int time = (int)gameTime;
        int hour = time / 3600;
        int minute = (time % 3600) / 60;
        int second = time % 60;
        int decisecond = (int)((gameTime - time) * 10);
        clock.text = $"{hour:00}:{minute:00}:{second:00}.{decisecond:0}";
        if (second % 5 == 0 && LabirintState.score > 0)
        {
            LabirintState.score -= 1;
            score.text = $"Score: {LabirintState.score}";
        }
    }
    private void OnCheckpoint1AmountChanged()
    {
        image1.fillAmount = LabirintState.checkPoint1Amount;
    }
    private void OnCheckpoint2AmountChanged()
    {
        image2.fillAmount = LabirintState.checkPoint2Amount;
    }
    private void OnGameLevelChanged()
    {
        level.text = $"Level: {LabirintState.gameLevel}";
    }
    private void OnDestroy()
    {
        LabirintState.RemovePropertyListener(nameof(LabirintState.checkPoint1Amount), OnCheckpoint1AmountChanged);
        LabirintState.RemovePropertyListener(nameof(LabirintState.checkPoint2Amount), OnCheckpoint2AmountChanged);
        LabirintState.RemovePropertyListener(nameof(LabirintState.gameLevel), OnGameLevelChanged);
    }
}
