using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    } 
     public void QuitGame() {
        Application.Quit();
     }
      public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
      }
    public Text levelText;
    public Text[] buttonTexts;
    public int lives = 3;
    private int level = 1;
    private int correctNumber = 0;
    private List<int> usedNumbers = new List<int>();

    public void StartGame()
    {
        level = 1;
        lives = 3;
        LoadLevel();
    }

    public void LoadLevel()
    {
        if (level <= 10)
        {
            correctNumber = Random.Range(0, 11);
            usedNumbers.Add(correctNumber);

            // Generate the numbers for the buttons
            List<int> buttonNumbers = new List<int>();
            for (int i = 0; i < buttonTexts.Length; i++)
            {
                int number = Random.Range(0, 11);
                while (buttonNumbers.Contains(number) || number == correctNumber)
                {
                    number = Random.Range(0, 11);
                }
                buttonNumbers.Add(number);
                buttonTexts[i].text = number.ToString();
            }

            int correctButtonIndex = Random.Range(0, buttonTexts.Length);
            buttonTexts[correctButtonIndex].text = correctNumber.ToString();

            // Update the UI
            levelText.text = "Level: " + level.ToString();
        }
        else
        {
            LoadScene2(); // Game win
        }
    }

    public void CheckAnswer(int answer)
    {
        if (answer == correctNumber)
        {
            level++;
            LoadLevel();
        }
        else
        {
            lives--;

            if (lives <= 0)
            {
                LoadScene1(); // Game over
            }
            else
            {
                LoadLevel();
            }
        }
    }

    private void LoadScene1()
    {
        // Code to load scene 1
    }

    private void LoadScene2()
    {
        // Code to load scene 2
    }
}
