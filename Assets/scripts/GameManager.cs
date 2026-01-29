using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject EndScreen; 
    public GameObject CenterCircle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartScreen.SetActive(true);
        CenterCircle.SetActive(true);
        EndScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        StartScreen.SetActive(false);
        CenterCircle.SetActive(false);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(1);
    }
}
