using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;

public class LevelFinish : MonoBehaviour
{
    public Transform player; 
    public Transform endPoint; 
    public TMP_Text finishText;
    public float detectionRadius = 3f; 

    void Update()
    {
        if (Vector3.Distance(player.position, endPoint.position) < detectionRadius)
        {
            finishText.text = "Finish!";
            finishText.gameObject.SetActive(true);

            Invoke("LoadMainMenu", 3f);
        }
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
