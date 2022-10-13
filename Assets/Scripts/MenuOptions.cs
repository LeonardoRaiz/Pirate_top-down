using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuOptions : MonoBehaviour
{
    private Animator transitionAnim;
    [SerializeField] private TMP_InputField sessionTime;
    [SerializeField] private TMP_InputField spawnTime;

    private void Start()
    {
        transitionAnim = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        string text = sessionTime.GetComponent<TMP_InputField>().text;
        int number;
        int.TryParse(text, out number);
        GameManager.instance.timeGame = number;
        text = spawnTime.GetComponent<TMP_InputField>().text;
        int.TryParse(text, out number);
        GameManager.instance.spawnGame = number;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
