using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionsManager : MonoBehaviour
{
    public static LevelTransitionsManager thisInstance;

    private void Awake()
    {
        thisInstance = this;
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    public void StartAgain()
    {
        GameData.ReseScore();
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        HUD.thisInstance.ToggleCurbain(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
