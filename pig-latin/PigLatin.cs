﻿using System.Text;

public static class PigLatin
{
    public static string Translate(string word)
    {
        string[] words = word.Split(' ');
        string translation = "";
        string[] vowels = new string[] { "a", "e", "i", "o", "u", "y" };
        StringBuilder output = new StringBuilder();
        string result = "";

        foreach (string wrd in words)
        {
            string firstLetter = wrd.Substring(0, 1);
            string secondLetter = wrd.Substring(1, 1);
            string thirdLetter = (wrd.Length > 2) ? wrd.Substring(2, 1) : null;

            switch (firstLetter)
            {
                case "a":
                    translation = wrd + "ay";
                    output.Append(translation);
                    break;
                case "e":
                    translation = wrd + "ay";
                    output.Append(translation);
                    break;
                case "i":
                    translation = wrd + "ay";
                    output.Append(translation);
                    break;
                case "o":
                    translation = wrd + "ay";
                    output.Append(translation);
                    break;
                case "u":
                    translation = wrd + "ay";
                    output.Append(translation);
                    break;
                default:
                    // The word starts with a consonant

                    // Handle "qu", for example "queen" becomes "eenquay"
                    // see: http://stesie.github.io/2016/08/pig-latin-kata
                    if (firstLetter == "q" && secondLetter == "u")
                    {
                        translation = wrd.Substring(2) + firstLetter + secondLetter + "ay";
                        output.Append(translation);
                        break;
                    }

                    // Handle "xr" and "yt"
                    // see: http://stesie.github.io/2016/08/pig-latin-kata
                    if ((firstLetter == "x" && secondLetter == "r") || (firstLetter == "y" && secondLetter == "t"))
                    {
                        translation = wrd + "ay";
                        output.Append(translation);
                        break;
                    }


                    // check if the second letter is also a consonant, essentially verifying that the word starts with a consonant cluster
                    bool isVowel = false;
                    foreach (string letter in vowels)
                    {
                        if (secondLetter == letter)
                        {
                            isVowel = true;
                        }
                    }

                    if (isVowel)
                    {
                        // the second letter is a vowel
                        translation = wrd.Substring(1) + firstLetter + "ay";
                        output.Append(translation);
                    }
                    else
                    {
                        // check if the third letter is also a consonant, essentially verifying that the word starts with a consonant cluster                    
                        isVowel = false; // reset value
                        foreach (string letter in vowels)
                        {
                            if (thirdLetter == letter)
                            {
                                if (thirdLetter != "u")
                                {
                                    // Handle any consonant + "qu" at the word's beginning, example "square" becomes "aresquay"
                                    // see: http://stesie.github.io/2016/08/pig-latin-kata
                                    isVowel = true;
                                }
                            }
                        }

                        if (isVowel)
                        {
                            // the second letter is a consonant
                            translation = wrd.Substring(2) + firstLetter + secondLetter + "ay";
                            output.Append(translation);
                        }
                        else
                        {
                            translation = wrd.Substring(3) + firstLetter + secondLetter + thirdLetter + "ay";
                            output.Append(translation);
                        }
                    }

                    break;
            }

            output.Append(" "); // adds space between words
        }

        result = output.ToString().TrimEnd();
        return result;
    }
}
