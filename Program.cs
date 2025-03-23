// See https://aka.ms/new-console-template for more information
using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random randomizer = new Random();
        this.id = randomizer.Next(10000, 99999); //generate angka random untuk ID
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        this.playCount += count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID Video     : {id}");
        Console.WriteLine($"Title        : {title}");
        Console.WriteLine($"Play Count   : {playCount}");
    }
}

class Program
{
    private static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Frizam Dafa Maulana");
        video.PrintVideoDetails();
    }
}

