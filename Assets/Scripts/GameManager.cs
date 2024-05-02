using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int p1HP;
    public int p2HP;
    public int p1DMG;
    public int p2DMG;
    public float multiplier;
    public bool p1Turn;
    public bool p2Turn;
    void Start()
    {
        p1Turn = true;
        p2Turn = false;
        p1HP = 100;
        p2HP = 100;
        p1DMG = 0;
        p2DMG = 0;
        multiplier = 1;

    }
    
    void Update()
    {
        if (p1Turn)
        {
            
        }

        if (p2Turn)
        {
            
        }
    }

    public void ChangeTurns()
    {
        if (p1Turn == true && p2Turn == false)
        {
            p1Turn = false;
            p2Turn = true;
        }
        else
        {
            p2Turn = false;
            p1Turn = true;
        }
    }
}
