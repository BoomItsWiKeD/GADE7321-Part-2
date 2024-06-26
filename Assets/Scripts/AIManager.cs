using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AIManager : MonoBehaviour
{
    public string AIDifficulty;
    public int AIRoll;
    public int QuestionDifficultyRoll;
    
    public int p1HP;
    public int p2HP;
    public int p1DMG;
    public int p2DMG;
    public int potentialDMG;
    public int multiplier;
    public bool p1Turn;
    public bool p1TurnComplete;
    public bool p2Turn;
    public bool p2TurnComplete;
    public float timerTime;
    public bool timerRunning;

    public Slider p1HPBar;
    public Slider p2HPBar;
    
    public GameObject easyButtons1;
    public GameObject easyButtons2;
    public GameObject easyButtons3;
    public GameObject easyButtons4;
    public GameObject easyButtons5;
    
    public GameObject mediumButtons1;
    public GameObject mediumButtons2;
    public GameObject mediumButtons3;
    public GameObject mediumButtons4;
    public GameObject mediumButtons5;
    
    public GameObject hardButtons1;
    public GameObject hardButtons2;
    public GameObject hardButtons3;
    public GameObject hardButtons4;
    public GameObject hardButtons5;
    
    public GameObject extremeButtons1;
    public GameObject extremeButtons2;
    public GameObject extremeButtons3;
    public GameObject extremeButtons4;
    public GameObject extremeButtons5;
    
    public TMP_Text turnText;
    public TMP_Text dialogueText;
    public TMP_Text timerText;
    public TMP_Text multiplierText;

    public GameObject difficultyButtons;
    public GameObject p1VictoryScreen;
    public GameObject p2VictoryScreen;
    public GameObject tieScreen;
    
    void Start()
    {
        AIDifficulty = SceneManager.GetActiveScene().name;
        p1Turn = true;
        p2Turn = false;
        p1HP = 100;
        p2HP = 100;
        p1DMG = 0;
        p2DMG = 0;
        multiplier = 1;
        turnText.color = Color.blue;
        Debug.Log("START");
        DifficultyPhase();
    }
    
    void Update()
    {
        p1HPBar.value = Mathf.MoveTowards(p1HPBar.value, p1HP / 100f, .3f * Time.deltaTime);
        p2HPBar.value = Mathf.MoveTowards(p2HPBar.value, p2HP / 100f, .3f * Time.deltaTime);
        multiplierText.text = "x" + multiplier + " DMG";
        
        if (timerRunning)
        {
            timerText.enabled = true;
            timerText.text = "" + Mathf.Round(timerTime);
            timerTime -= Time.deltaTime;
        }

        if (timerTime < 0 && timerRunning)
        {
            onIncorrectAnswerClick();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void DifficultyPhase()
    {
        if (p1Turn)
        {
            difficultyButtons.SetActive(true);
            dialogueText.text = "Select a difficulty at the bottom.";
        }
        if (p2Turn)
        {
            dialogueText.text = "AI is selecting a difficulty";
        }
    }

    public void DamagePhase()
    {
        p1HP = p1HP - p2DMG;
        p2HP = p2HP - p1DMG;

        multiplier = multiplier + 1;

        if (p2HP <= 0 && p1HP > 0)
        {
            P1Victory();
        }
        if (p1HP <= 0 && p2HP > 0)
        {
            P2Victory();
        }

        if (p1HP <= 0 && p2HP <= 0)
        {
            if (p1HP > p2HP)
            {
                P1Victory();
            }
            if (p2HP > p1HP)
            {
                P2Victory();
            }

            if (p1HP == p2HP)
            {
                Tie();
            }
        }
        DifficultyPhase();
    }

    public void ChangeTurns()
    {
        if (p1Turn == true)
        {
            p1Turn = false;
            p2Turn = true;
            turnText.text = "P2 Turn";
            turnText.color = Color.yellow;
            
            easyButtons1.SetActive(false);
            easyButtons2.SetActive(false);
            easyButtons3.SetActive(false);
            easyButtons4.SetActive(false);
            easyButtons5.SetActive(false);
            mediumButtons1.SetActive(false);
            mediumButtons2.SetActive(false);
            mediumButtons3.SetActive(false);
            mediumButtons4.SetActive(false);
            mediumButtons5.SetActive(false);
            hardButtons1.SetActive(false);
            hardButtons2.SetActive(false);
            hardButtons3.SetActive(false);
            hardButtons4.SetActive(false);
            hardButtons5.SetActive(false);
            extremeButtons1.SetActive(false);
            extremeButtons2.SetActive(false);
            extremeButtons3.SetActive(false);
            extremeButtons4.SetActive(false);
            extremeButtons5.SetActive(false);
            
            AITurnController();
        }
        else if (p2Turn == true)
        {
            p2Turn = false;
            p1Turn = true;
            turnText.text = "P1 Turn";
            turnText.color = Color.blue;
        }
    }

    public void AITurnController()
    {
        dialogueText.text = "Player 2 is choosing a difficulty...";
        StartCoroutine(AIDifficultySelect());
    }

    IEnumerator AIDifficultySelect()
    {
        yield return new WaitForSeconds(3);
        
        QuestionDifficultyRoll = Random.Range(1, 5);

        switch (QuestionDifficultyRoll)
        {
            case 1:
                dialogueText.text = "Player 2 selects Easy";
                StartCoroutine(WaitForDifficultySelect());
                onEasyButtonClick();
                break;
            case 2:
                dialogueText.text = "Player 2 selects Medium";
                StartCoroutine(WaitForDifficultySelect());
                onMediumButtonClick();
                break;
            case 3:
                dialogueText.text = "Player 2 selects Hard";
                StartCoroutine(WaitForDifficultySelect());
                onHardButtonClick();
                break;
            case 4:
                dialogueText.text = "Player 2 selects Extreme";
                StartCoroutine(WaitForDifficultySelect());
                onExtremeButtonClick();
                break;
        }

        dialogueText.text = "AI is choosing an answer...";
        
        easyButtons1.SetActive(false);
        easyButtons2.SetActive(false);
        easyButtons3.SetActive(false);
        easyButtons4.SetActive(false);
        easyButtons5.SetActive(false);
        mediumButtons1.SetActive(false);
        mediumButtons2.SetActive(false);
        mediumButtons3.SetActive(false);
        mediumButtons4.SetActive(false);
        mediumButtons5.SetActive(false);
        hardButtons1.SetActive(false);
        hardButtons2.SetActive(false);
        hardButtons3.SetActive(false);
        hardButtons4.SetActive(false);
        hardButtons5.SetActive(false);
        extremeButtons1.SetActive(false);
        extremeButtons2.SetActive(false);
        extremeButtons3.SetActive(false);
        extremeButtons4.SetActive(false);
        extremeButtons5.SetActive(false);
        
        yield return new WaitForSeconds(2);
        AIAnswerSelect();
    }

    public void AIAnswerSelect()
    {
        AIRoll = Random.Range(1, 101);
        if (AIDifficulty == "Easy")
        {
            if (AIRoll > 0 && AIRoll <= 60) //AI has 40% chance to answering the question correctly
            {
                onIncorrectAnswerClick();
            }
            else
            {
                onCorrectAnswerClick();
            }
        }
        else if (AIDifficulty == "Medium")
        {
            if (AIRoll > 0 && AIRoll <= 30) //AI has 70% chance to answering the question correctly
            {
                onIncorrectAnswerClick();
            }
            else
            {
                onCorrectAnswerClick();
            }
        }
        else if (AIDifficulty == "Hard")
        {
            if (AIRoll > 0 && AIRoll <= 10) //AI has 90% chance to answering the question correctly
            {
                onIncorrectAnswerClick();
            }
            else
            {
                onCorrectAnswerClick();
            }
        }
    }

    IEnumerator WaitForDifficultySelect()
    {
        yield return new WaitForSeconds(5);
    }
    
    public void onCorrectAnswerClick()
    {
        timerTime = 5;
        timerRunning = false;
        timerText.enabled = false;
        
        easyButtons1.SetActive(false);
        easyButtons2.SetActive(false);
        easyButtons3.SetActive(false);
        easyButtons4.SetActive(false);
        easyButtons5.SetActive(false);
        mediumButtons1.SetActive(false);
        mediumButtons2.SetActive(false);
        mediumButtons3.SetActive(false);
        mediumButtons4.SetActive(false);
        mediumButtons5.SetActive(false);
        hardButtons1.SetActive(false);
        hardButtons2.SetActive(false);
        hardButtons3.SetActive(false);
        hardButtons4.SetActive(false);
        hardButtons5.SetActive(false);
        extremeButtons1.SetActive(false);
        extremeButtons2.SetActive(false);
        extremeButtons3.SetActive(false);
        extremeButtons4.SetActive(false);
        extremeButtons5.SetActive(false);
        
        if (p1Turn)
        {
            p1DMG = potentialDMG * multiplier; 
            p1TurnComplete = true;
            ChangeTurns();
            DifficultyPhase();
        }

        else if (p2Turn)
        {
            p2DMG = potentialDMG * multiplier;
            p2TurnComplete = true;
            ChangeTurns();
            DamagePhase();
        }
        
    }

    public void P1Victory()
    {
        p1VictoryScreen.SetActive(true);
    }

    public void P2Victory()
    {
        p2VictoryScreen.SetActive(true);
    }

    public void Tie()
    {
        tieScreen.SetActive(true);
    }
    
    public void onIncorrectAnswerClick()
    {
        timerTime = 5;
        timerRunning = false;
        timerText.enabled = false;
        
        easyButtons1.SetActive(false);
        easyButtons2.SetActive(false);
        easyButtons3.SetActive(false);
        easyButtons4.SetActive(false);
        easyButtons5.SetActive(false);
        mediumButtons1.SetActive(false);
        mediumButtons2.SetActive(false);
        mediumButtons3.SetActive(false);
        mediumButtons4.SetActive(false);
        mediumButtons5.SetActive(false);
        hardButtons1.SetActive(false);
        hardButtons2.SetActive(false);
        hardButtons3.SetActive(false);
        hardButtons4.SetActive(false);
        hardButtons5.SetActive(false);
        extremeButtons1.SetActive(false);
        extremeButtons2.SetActive(false);
        extremeButtons3.SetActive(false);
        extremeButtons4.SetActive(false);
        extremeButtons5.SetActive(false);
        
        if (p1Turn)
        {
            p1TurnComplete = true;
            p1DMG = 0;
            ChangeTurns();
            DifficultyPhase();
        }

        else if (p2Turn)
        {
            p2TurnComplete = true;
            p2DMG = 0;
            ChangeTurns();
            DamagePhase();
        }
    }
    
    public void onEasyButtonClick()
    {
        difficultyButtons.SetActive(false);
        timerTime = 5;
        timerRunning = true;
        
        int randomNum = Random.Range(1, 5);
        potentialDMG = 5;

        if (randomNum == 1)
        {
            dialogueText.text = "What is 10-7?";
            easyButtons1.SetActive(true);
        }
        if (randomNum == 2)
        {
            dialogueText.text = "What is 5+8?";
            easyButtons2.SetActive(true);
        }
        if (randomNum == 3)
        {
            dialogueText.text = "What is 9+10?";
            easyButtons3.SetActive(true);
        }
        if (randomNum == 4)
        {
            dialogueText.text = "What is 4÷2?";
            easyButtons4.SetActive(true);
        }
        if (randomNum == 5)
        {
            dialogueText.text = "What is 3x3?";
            easyButtons5.SetActive(true);
        }
    }
    
    public void onMediumButtonClick()
    {
        difficultyButtons.SetActive(false);
        timerTime = 5;
        timerRunning = true;
        int randomNum = Random.Range(1, 5);
        potentialDMG = 8;

        if (randomNum == 1)
        {
            dialogueText.text = "What is 21+17?";
            mediumButtons1.SetActive(true);
        }
        if (randomNum == 2)
        {
            dialogueText.text = "What is 9x7?";
            mediumButtons2.SetActive(true);
        }
        if (randomNum == 3)
        {
            dialogueText.text = "What is 36÷6?";
            mediumButtons3.SetActive(true);
        }
        if (randomNum == 4)
        {
            dialogueText.text = "What is 91-13?";
            mediumButtons4.SetActive(true);
        }
        if (randomNum == 5)
        {
            dialogueText.text = "What is 32+67?";
            mediumButtons5.SetActive(true);
        }
    }
    
    public void onHardButtonClick()
    {
        difficultyButtons.SetActive(false);
        timerTime = 5;
        timerRunning = true;
        int randomNum = Random.Range(1, 5);
        potentialDMG = 13;

        if (randomNum == 1)
        {
            dialogueText.text = "What is 144÷12?";
            hardButtons1.SetActive(true);
        }
        if (randomNum == 2)
        {
            dialogueText.text = "What is 23x5?";
            hardButtons2.SetActive(true);
        }
        if (randomNum == 3)
        {
            dialogueText.text = "What is 2(a+b)?";
            hardButtons3.SetActive(true);
        }
        if (randomNum == 4)
        {
            dialogueText.text = "What is 100÷3?";
            hardButtons4.SetActive(true);
        }
        if (randomNum == 5)
        {
            dialogueText.text = "What is 177-58?";
            hardButtons5.SetActive(true);
        }
    }
    
    public void onExtremeButtonClick()
    {
        difficultyButtons.SetActive(false);
        timerTime = 5;
        timerRunning = true;
        int randomNum = Random.Range(1, 5);
        potentialDMG = 20;

        if (randomNum == 1)
        {
            dialogueText.text = "What is (5x7)+11?";
            extremeButtons1.SetActive(true);
        }
        if (randomNum == 2)
        {
            dialogueText.text = "What is 50-15÷3?";
            extremeButtons2.SetActive(true);
        }
        if (randomNum == 3)
        {
            dialogueText.text = "What is the next number in 2, 5, 10, 17..?";
            extremeButtons3.SetActive(true);
        }
        if (randomNum == 4)
        {
            dialogueText.text = "What is x if 12=x-31?";
            extremeButtons4.SetActive(true);
        }
        if (randomNum == 5)
        {
            dialogueText.text = "What is 3498-1145?";
            extremeButtons5.SetActive(true);
        }
    }

    public void onRestartClick()
    {
        if (AIDifficulty == "Easy")
        {
            SceneManager.LoadScene("Easy");
        }
        else if (AIDifficulty == "Medium")
        {
            SceneManager.LoadScene("Medium");
        }
        else if (AIDifficulty == "Hard")
        {
            SceneManager.LoadScene("Hard");
        }
    }

    public void onMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

