using System;
using System.Collections.Generic;
void LyricGen(int endOn)
{
    //lovely Christmas colour scheme of red and white:-)
    Console.BackgroundColor = ConsoleColor.DarkRed; //https://www.codegrepper.com/code-examples/csharp/change+text+color+in+console+c%23
    Console.ForegroundColor = ConsoleColor.White;
    //List of days for inserting into the text - copied from task
    List<string> days = new List<string> {
    "first", "second", "third", "fourth", "fifth", "sixth",
    "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
};
    //Present list - copied from task
    List<string> items = new List<string> {
    "Twelve drummers drumming",
    "Eleven pipers piping",
    "Ten lords a leaping",
    "Nine ladies dancing",
    "Eight maids a milking",
    "Seven swans a swimming",
    "Six geese a laying",
    "Five gold rings, badam-pam-pam",
    "Four calling birds",
    "Three French hens",
    "Two turtle doves",
    "A partridge in a pear tree",
};
    //Sets up a new list called Previous Items for the repeation of the presents 
    List<string> previousItems = new List<string> { };
    items.Reverse();
    int counter = 0;
    for (int dayNumber = 0; dayNumber < endOn; dayNumber++)
    {//If its the first day there is no repeat required
        if (dayNumber == 0)
        {
            //Output for the first line of the song    
            Console.WriteLine("On the " + days[dayNumber] + " day of Christmas, my true love sent to me, " + items[counter].ToLower()+"\n");
            counter += 1;
        }
        else
        {
            //for every other day there is a repeat requirement. This is the code to enact the correct repeat    
            for (int previousCounter = 0; previousCounter <= counter; previousCounter++)
            {
                previousItems.Add(items[previousCounter]);
            }
            counter += 1;
            previousItems.Reverse();
            //Output for the start of the repeat sequence    
            Console.Write("On the " + days[dayNumber] + " day of Christmas, my true love sent to me, ");
            foreach (string item in previousItems)
            {
                //Outputs for the correct grammar and new line requirements. Also converts to lower case.    
                if (item == "Two turtle doves")
                {
                    Console.Write(item.ToLower() + " and ");
                }
                else if (item != previousItems[previousItems.Count - 1])
                {
                    Console.Write(item.ToLower() + ", ");
                }
                else
                {
                    Console.WriteLine(item.ToLower() + "\n");
                }
            }
            previousItems.Clear();
        }
    }
}
void daymatch()
{
    //Extra feature to output only the relevant line(s) for the day when run during the actual 12 day period (25 Dec to 5 Jan).
    //Also functionality to ensure that this works on the correct 12 day period whether it is a leap year or not.
    if (DateTime.IsLeapYear(DateTime.Now.Year) == false)
    {
        switch (DateTime.Now.DayOfYear)
        {
            case 359: LyricGen(1); break;
            case 360: LyricGen(2); break;
            case 361: LyricGen(3); break;
            case 362: LyricGen(4); break;
            case 363: LyricGen(5); break;
            case 364: LyricGen(6); break;
            case 365: LyricGen(7); break;
            case 1: LyricGen(8); break;
            case 2: LyricGen(9); break;
            case 3: LyricGen(10); break;
            case 4: LyricGen(11); break;
            default: LyricGen(12); break;
        }
    }
    if (DateTime.IsLeapYear(DateTime.Now.Year) == true)
    {
        switch (DateTime.Now.DayOfYear)
        {
            case 360: LyricGen(1); break;
            case 361: LyricGen(2); break;
            case 362: LyricGen(3); break;
            case 363: LyricGen(4); break;
            case 364: LyricGen(5); break;
            case 365: LyricGen(6); break;
            case 366: LyricGen(7); break;
            case 1: LyricGen(8); break;
            case 2: LyricGen(9); break;
            case 3: LyricGen(10); break;
            case 4: LyricGen(11); break;
            default: LyricGen(12); break;
        }
    }
}
daymatch();


