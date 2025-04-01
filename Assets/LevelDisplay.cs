using UnityEngine;
using TMPro; 

public class LevelDisplay : MonoBehaviour
{
    [System.Serializable]
    public class LevelInfo
    {
        public string levelName; 
        public Vector3 startPosition;
        public float detectionRadius = 3f; 
    }

    public LevelInfo[] levels; 
    public Transform player; 
    public TMP_Text levelText; 

    private string currentLevel = "";

    void Update()
    {
        foreach (LevelInfo level in levels) 
        {
            if (Vector3.Distance(player.position, level.startPosition) < level.detectionRadius)
            {
                levelText.text = level.levelName; 
                levelText.gameObject.SetActive(true); 
                currentLevel = level.levelName; 
                return;
            }
        }

        if (!string.IsNullOrEmpty(currentLevel))
        {
            levelText.text = currentLevel;
            levelText.gameObject.SetActive(true);
        }
    }
}

