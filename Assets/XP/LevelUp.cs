using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUp : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel = 1; 
    int totalExperience;
    int previousLevelsExperience, nextLevelsExperience;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image experienceFill;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI strengthText;

    [Header("Player Reference")]
    [SerializeField] Player player;

    void Start()
    {
        UpdateLevel();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddExperience(5);
        }
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        if (currentLevel < 5 && totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            player.IncreaseStats();
            UpdateLevel();
        }
    }

    void UpdateLevel()
    {
        previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

        levelText.text = currentLevel.ToString();
        experienceFill.fillAmount = (float)start / (float)end;
        healthText.text = player.GetHealth().ToString();
        strengthText.text = player.GetAttack().ToString();
    }
}
