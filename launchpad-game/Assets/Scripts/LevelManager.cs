using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int enemyCount;
    public static int sacrificeCount;

    [Header("Level Difficulties")]
    // level starts from 0
    public static int level;
    public static int maxLevel = 5;
    public static int[] enemiesByLevel = {2,4,6,8,10};
    public static int[] sacrificesByLevel = { 10,15,20,30, 50 };

}
