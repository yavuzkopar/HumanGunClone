using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FirstSceneLoader : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI _loadingText;
    void Start()
    {
        if (GameManager.LastSceneIndex > 0)
            StartCoroutine(Load(GameManager.LastSceneIndex));
        else
            StartCoroutine(Load(1));
    }

    IEnumerator Load(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            _loadingText.text = "Loading..." + progress*100;
            yield return null;
        }
    }
}
