using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public float speed = 0.9f;
    public Text loadingText;
    public Text tip;
    public List<string> tipsList = new List<string>() 
    { "Robots are pretty stupid! Except chatgpt! But he not in the game... True?",
    "You can use the wall crystal to protect you from bullets! And also build a house if you want!",
    "Is there easter egg in the game..?",
    "You subscribe to MegaPig yes? If you not the loading screen will become slower for you..",
    "You know that the text here is random? and almost everytime with no useful information. almost...",
    "Beep beep im a sheep, I SAID BEEP BEEP IM A SHEEP!",
    "The cave of the crystals road seems endless! and what the robot protecting? whats in the end..?",
    "A really good tip to kill the robots- shoot them.",
    "The time crystal can slow time! but, can he stop it?? no.",
    "Did you saw all the tips in here? probably not. there is a lot of them.",
    "The lightning crystal can kill almost every enemy! Did you reach to the ones he can not..?",
    ":P",
    ":]",
    "You have good time?? no? oh. so have please.",
    "Wack wack im a duck, I SAID WACK WACK IM A DUCK!" };
    System.Random rand = new System.Random();

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        LoadingScreen.SetActive(true);
        loadingText.text = "Loading";
        int dotCount = 0;
        tip.text = tipsList[rand.Next(0,tipsList.Count)];

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / speed);
            LoadingBarFill.fillAmount = progressValue;

            yield return null;

            // Update loading text every second
            if (Time.frameCount % 60 == 0)
            {
                dotCount++;
                if (dotCount > 3)
                {
                    dotCount = 0;
                }
                loadingText.text = "Loading" + new string('.', dotCount);
            }
        }

        // Reset loading text after loading is complete
        loadingText.text = "Loading";
    }
}