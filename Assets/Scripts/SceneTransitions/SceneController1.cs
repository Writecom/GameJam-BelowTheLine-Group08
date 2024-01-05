using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController1 : MonoBehaviour
{

    public static SceneController1 instance;

    [SerializeField] Animator transitionAnim;

    public void NextScene()
    {
        StartCoroutine(LoadScene());
    }

    public void PlayWinningScene()
    {
        StartCoroutine (LoadWinningScene());
    }

    public void GetMainMenu()
    {
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        transitionAnim.SetTrigger("Start");
    }

    IEnumerator LoadWinningScene()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);

        transitionAnim.SetTrigger("Start");
    }

    IEnumerator LoadMainMenu()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync("Main Menu");

        transitionAnim.SetTrigger("Start");
    }
}
