using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{

    public static string ProcessText(string input)
    {
        //Code goes here:
        //Determine whether user has input a word or number
        //Return the string 'word' if the user enters a word
        //Return the string 'number' if the user enters a number

        string[] words = input.Split(' ');
        int wordCount = 0;
        int numberCount = 0;

        /*if (float.TryParse(input, out float output))
        {
            input = "number";
        }

        else
        {
            input = "word";
        }*/

        foreach(string word in words)
        {
            Debug.Log(word);
            if (float.TryParse(word, out float output))
            {
                numberCount++;
            }

            else
            {
                wordCount++;
            }
        }

        input = wordCount + " words and " + numberCount + " numbers";

        return input;
    }
}
