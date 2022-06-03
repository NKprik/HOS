using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leveloader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void LoadSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel01 (int sceneIndex)
    {

        StartCoroutine(LoadAsychronously(sceneIndex));
    }

    IEnumerator LoadAsychronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            yield return null;

                
        }
    }
}
