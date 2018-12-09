using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Keyboard : MonoBehaviour {

    void Update()
    {
        SearchBarGuiText.text = SearchBarText;
    }

    //Search bar object + text
    public GameObject SearchBar;
    public Text SearchBarGuiText;
    private string SearchBarText = "";

    //Type of Keyboard
    public GameObject UpperCaseKeyboard;
    //public GameObject CapsLockLight;
   // public GameObject ShiftLight;

    //Caps lock and shift variables
    private bool CapsLock = false;
    private bool Shift = false;

    //Brings up the search bar and keyboard
    public void OpenKeyboard()
    {
        SearchBarText = "";
        CapsLock = false;
        Shift = true;

        SearchBar.SetActive(true);
        UpperCaseKeyboard.SetActive(true);
        //ShiftLight.SetActive(true);
    }
    //Closes the search bar and keyboard
    public void CloseKeyboard()
    {
        SearchBar.SetActive(false);
        UpperCaseKeyboard.SetActive(false);
        //CapsLockLight.SetActive(false);
        //ShiftLight.SetActive(false);
    }

    /*Utility Buttons
     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    */
    public void CapsLockButton()
    {
        if (CapsLock == true)
        {
            CapsLock = false;
            //CapsLockLight.SetActive(false);
        }
        else if (CapsLock == false)
        {
            CapsLock = true;
            //CapsLockLight.SetActive(true);
        }
    }
    public void ShiftButton()
    {
        if (Shift == true)
        {
            Shift = false;
            //ShiftLight.SetActive(false);
        }
        else if (Shift == false)
        {
            Shift = true;
            //ShiftLight.SetActive(true);
        }
    }
    public void BackSpaceButton()
    {
        //if (string.IsNullOrEmpty(SearchBarText))
        //SearchBarText.Substring(SearchBarText.Length - 1);
        if (SearchBarText.Length > 0)
            SearchBarText = SearchBarText.Substring(0, SearchBarText.Length - 1);
    }
    public string EnterButton()
    {
        Debug.Log(SearchBar);
        CloseKeyboard();
        return SearchBarText;
    }
    public void EnterButton2()
    {
        Debug.Log(SearchBarText);
        CloseKeyboard();
        //return SearchBarText;
    }
    /* Upper and Lower case letters
     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    */
    public void Letter_A()
    {
        if (CapsLock == true)
        {
            SearchBarText += "A";
        }
        else if(Shift == true)
        {
            SearchBarText += "A";
            ShiftButton();
        }
        else
            SearchBarText += "a";
    }
    public void Letter_B()
    {
        if (CapsLock == true)
        {
            SearchBarText += "B";
        }
        else if (Shift == true)
        {
            SearchBarText += "B";
            ShiftButton();
        }
        else
            SearchBarText += "b";
    }
    public void Letter_C()
    {
        if (CapsLock == true)
        {
            SearchBarText += "C";
        }
        else if (Shift == true)
        {
            SearchBarText += "C";
            ShiftButton();
        }
        else
            SearchBarText += "c";
    }
    public void Letter_D()
    {
        if (CapsLock == true)
        {
            SearchBarText += "D";
        }
        else if (Shift == true)
        {
            SearchBarText += "D";
            ShiftButton();
        }
        else
        {
            SearchBarText += "d";
        }
    }
    public void Letter_E()
    {
        if (CapsLock == true)
        {
            SearchBarText += "E";
        }
        else if (Shift == true)
        {
            SearchBarText += "E";
            ShiftButton();
        }
        else
            SearchBarText += "e";
    }
    public void Letter_F()
    {
        if (CapsLock == true)
        {
            SearchBarText += "F";
        }
        else if (Shift == true)
        {
            SearchBarText += "F";
            ShiftButton();
        }
        else
            SearchBarText += "f";
    }
    public void Letter_G()
    {
        if (CapsLock == true)
        {
            SearchBarText += "G";
        }
        else if (Shift == true)
        {
            SearchBarText += "G";
            ShiftButton();
        }
        else
            SearchBarText += "g";
    }
    public void Letter_H()
    {
        if (CapsLock == true)
        {
            SearchBarText += "H";
        }
        else if (Shift == true)
        {
            SearchBarText += "H";
            ShiftButton();
        }
        else
            SearchBarText += "h";
    }
    public void Letter_I()
    {
        if (CapsLock == true)
        {
            SearchBarText += "I";
        }
        else if (Shift == true)
        {
            SearchBarText += "I";
            ShiftButton();
        }
        else
            SearchBarText += "i";
    }
    public void Letter_J()
    {
        if (CapsLock == true)
        {
            SearchBarText += "J";
        }
        else if (Shift == true)
        {
            SearchBarText += "J";
            ShiftButton();
        }
        else
            SearchBarText += "j";
    }
    public void Letter_K()
    {
        if (CapsLock == true)
        {
            SearchBarText += "K";
        }
        else if (Shift == true)
        {
            SearchBarText += "K";
            ShiftButton();
        }
        else
            SearchBarText += "k";
    }
    public void Letter_L()
    {
        if (CapsLock == true)
        {
            SearchBarText += "L";
        }
        else if (Shift == true)
        {
            SearchBarText += "L";
            ShiftButton();
        }
        else
            SearchBarText += "l";
    }
    public void Letter_M()
    {
        if (CapsLock == true)
        {
            SearchBarText += "M";
        }
        else if (Shift == true)
        {
            SearchBarText += "M";
            ShiftButton();
        }
        else
            SearchBarText += "m";
    }
    public void Letter_N()
    {
        if (CapsLock == true)
        {
            SearchBarText += "N";
        }
        else if (Shift == true)
        {
            SearchBarText += "N";
            ShiftButton();
        }
        else
            SearchBarText += "n";
    }
    public void Letter_O()
    {
        if (CapsLock == true)
        {
            SearchBarText += "O";
        }
        else if (Shift == true)
        {
            SearchBarText += "O";
            ShiftButton();
        }
        else
            SearchBarText += "o";
    }
    public void Letter_P()
    {
        if (CapsLock == true)
        {
            SearchBarText += "P";
        }
        else if (Shift == true)
        {
            SearchBarText += "P";
            ShiftButton();
        }
        else
            SearchBarText += "p";
    }
    public void Letter_Q()
    {
        if (CapsLock == true)
        {
            SearchBarText += "Q";
        }
        else if (Shift == true)
        {
            SearchBarText += "Q";
            ShiftButton();
        }
        else
            SearchBarText += "q";
    }
    public void Letter_R()
    {
        if (CapsLock == true)
        {
            SearchBarText += "R";
        }
        else if (Shift == true)
        {
            SearchBarText += "R";
            ShiftButton();
        }
        else
            SearchBarText += "r";
    }
    public void Letter_S()
    {
        if (CapsLock == true)
        {
            SearchBarText += "S";
        }
        else if (Shift == true)
        {
            SearchBarText += "S";
            ShiftButton();
        }
        else
            SearchBarText += "";
    }
    public void Letter_T()
    {
        if (CapsLock == true)
        {
            SearchBarText += "T";
        }
        else if (Shift == true)
        {
            SearchBarText += "T";
            ShiftButton();
        }
        else
            SearchBarText += "t";
    }
    public void Letter_U()
    {
        if (CapsLock == true)
        {
            SearchBarText += "U";
        }
        else if (Shift == true)
        {
            SearchBarText += "U";
            ShiftButton();
        }
        else
            SearchBarText += "u";
    }
    public void Letter_V()
    {
        if (CapsLock == true)
        {
            SearchBarText += "V";
        }
        else if (Shift == true)
        {
            SearchBarText += "V";
            ShiftButton();
        }
        else
            SearchBarText += "v";
    }
    public void Letter_W()
    {
        if (CapsLock == true)
        {
            SearchBarText += "W";
        }
        else if (Shift == true)
        {
            SearchBarText += "W";
            ShiftButton();
        }
        else
            SearchBarText += "w";
    }
    public void Letter_X()
    {
        if (CapsLock == true)
        {
            SearchBarText += "X";
        }
        else if (Shift == true)
        {
            SearchBarText += "X";
            ShiftButton();
        }
        else
            SearchBarText += "x";
    }
    public void Letter_Y()
    {
        if (CapsLock == true)
        {
            SearchBarText += "Y";
        }
        else if (Shift == true)
        {
            SearchBarText += "Y";
            ShiftButton();
        }
        else
            SearchBarText += "y";
    }
    public void Letter_Z()
    {
        if (CapsLock == true)
        {
            SearchBarText += "Z";
        }
        else if (Shift == true)
        {
            SearchBarText += "Z";
            ShiftButton();
        }
        else
            SearchBarText += "z";
    }

    /* Numbers + Misc Letters
     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    */
    public void Number_01()
    {
        if (Shift == true)
        {
            SearchBarText += "!";
            ShiftButton();
        }
        else
            SearchBarText += "1";
    }
    public void Number_02()
    {
        if (Shift == true)
        {
            SearchBarText += "@";
            ShiftButton();
        }
        else
            SearchBarText += "2";
    }
    public void Number_03()
    {
        if (Shift == true)
        {
            SearchBarText += "#";
            ShiftButton();
        }
        else
            SearchBarText += "3";
    }
    public void Number_04()
    {
        if (Shift == true)
        {
            SearchBarText += "$";
            ShiftButton();
        }
        else
            SearchBarText += "4";
    }
    public void Number_05()
    {
        if (Shift == true)
        {
            SearchBarText += "%";
            ShiftButton();
        }
        else
            SearchBarText += "5";
    }
    public void Number_06()
    {
        if (Shift == true)
        {
            SearchBarText += "^";
            ShiftButton();
        }
        else
            SearchBarText += "6";
    }
    public void Number_07()
    {
        if (Shift == true)
        {
            SearchBarText += "&";
            ShiftButton();
        }
        else
            SearchBarText += "7";
    }
    public void Number_08()
    {
        if (Shift == true)
        {
            SearchBarText += "*";
            ShiftButton();
        }
        else
            SearchBarText += "8";
    }
    public void Number_09()
    {
        if (Shift == true)
        {
            SearchBarText += "(";
            ShiftButton();
        }
        else
            SearchBarText += "9";
    }
    public void Number_00()
    {
        if (Shift == true)
        {
            SearchBarText += ")";
            ShiftButton();
        }
        else
            SearchBarText += "0";
    }

    /* Misc Letters + Shift Misc Letters
     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    */
    public void Dash()
    {
        if (Shift == true)
        {
            SearchBarText += "_";
            ShiftButton();
        }
        else
            SearchBarText += "-";
    }
    public void Equals()
    {
        if (Shift == true)
        {
            SearchBarText += "+";
            ShiftButton();
        }
        else
            SearchBarText += "=";
    }
    public void BracketLeft()
    {
        if (Shift == true)
        {
            SearchBarText += "{";
            ShiftButton();
        }
        else
            SearchBarText += "[";
    }
    public void BracketRight()
    {
        if (Shift == true)
        {
            SearchBarText += "}";
            ShiftButton();
        }
        else
            SearchBarText += "]";
    }
    public void BackSlash()
    {
        if (Shift == true)
        {
            SearchBarText += "|";
            ShiftButton();
        }
        else
            SearchBarText += "\\";
    }
    public void Semicolon()
    {
        if (Shift == true)
        {
            SearchBarText += ":";
            ShiftButton();
        }
        else
            SearchBarText += ";";
    }
    public void Apostrophe()
    {
        if (Shift == true)
        {
            SearchBarText += "\"";
            ShiftButton();
        }
        else
            SearchBarText += "'";
    }
    public void Comma()
    {
        if (Shift == true)
        {
            SearchBarText += "<";
            ShiftButton();
        }
        else
            SearchBarText += ",";
    }
    public void Period()
    {
        if (Shift == true)
        {
            SearchBarText += ">";
            ShiftButton();
        }
        else
            SearchBarText += ".";
    }
    public void Slash()
    {
        if (Shift == true)
        {
            SearchBarText += "?";
            ShiftButton();
        }
        else
            SearchBarText += "/";
    }
}
