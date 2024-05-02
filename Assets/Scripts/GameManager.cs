using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
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

    public GameObject difficultyButtons;
    void Start()
    {
        p1Turn = true;
        p2Turn = false;
        p1HP = 100;
        p2HP = 100;
        p1DMG = 0;
        p2DMG = 0;
        multiplier = 1;
        
        DifficultyPhase();

    }
    
    void Update()
    {
        
    }

    public void DifficultyPhase()
    {
        dialogueText.text = "Select a difficulty at the bottom.";
        difficultyButtons.SetActive(true);
    }

    public void DamagePhase()
    {
        
    }

    public void ChangeTurns()
    {
        if (p1Turn == true)
        {
            p1Turn = false;
            p2Turn = true;
            turnText.text = "P2 Turn";
        }
        else if (p2Turn == true)
        {
            p2Turn = false;
            p1Turn = true;
            turnText.text = "P1 Turn";
        }
    }
    public void onCorrectAnswerClick()
    {
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
    public void onIncorrectAnswerClick()
    {
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
            p1Turn = false;
            p1TurnComplete = true;
            ChangeTurns();
            DifficultyPhase();
        }

        if (p2Turn)
        {
            p2Turn = false;
            p2TurnComplete = true;
            ChangeTurns();
            DamagePhase();
        }
    }
    public void onEasyButtonClick()
    {
        difficultyButtons.SetActive(false);
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
}
