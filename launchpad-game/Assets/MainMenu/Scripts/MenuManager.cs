using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [Header("Level Screen")]
    public GameObject levelScreen;
    public Transform spawnPoint;
    
    public void ChangeScene(int level)
    {
        LevelManager.level = level;
        LevelManager.enemyCount = LevelManager.enemiesByLevel[level];
        LevelManager.sacrificeCount = LevelManager.sacrificesByLevel[level];
        SceneManager.LoadScene("Game");
    }
    public void OpenLevelScreen()
    {
        Instantiate(levelScreen, spawnPoint.position, Quaternion.identity);
    }
    public void CloseLevelScreen(GameObject levelScreen)
    {
        Destroy(levelScreen);
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlayNextLevel()
    {
        ChangeScene(LevelManager.level + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
