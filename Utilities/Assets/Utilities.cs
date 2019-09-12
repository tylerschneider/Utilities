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

    public static string ProcessAverage(string input)
    {
        
        string[] words = input.Split(' ');
        //make a new array with the same length as the amount of words input
        float[] numberLetters = new float[words.Length];
        float average = 0;

        //go through the array and set the number of letters in each word in a new array
        for (int i = 0; i < words.Length; i++)
        {
            numberLetters[i] = words[i].Length;
        }

        //add the number of letters in each word to the average
        foreach (int num in numberLetters)
        {
            average += num;
        }

        //divide the average by the number of words there are
        average /= words.Length;
        input = average + " Letters Per Word";

        return input;
    }
}
