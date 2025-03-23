// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        //PRECONDITIONS: Judul tidak boleh null dan tidak boleh lebih dari 100 karakter
        Debug.Assert(title != null, "Judul tidak boleh null");
        Debug.Assert(title.Length <= 100, "Judul maksimal 100 karakter");

        Random randomizer = new Random();
        this.id = randomizer.Next(10000, 99999);

        this.title = title;
        this.playCount = 0;

        //memastikan bahwa objek video selalu memiliki play count >= 0 (INVARIANT)
        Debug.Assert(this.playCount >= 0, "Play count tidak boleh negatif");
    }

    public void IncreasePlayCount(int count)
    {
        //PRECONDITIONS: Input tambahan play count maksimal 10.000.000
        Debug.Assert(count > 0 && count <= 10000000, "Penambahan play count minimal 1 dan maksimal 10.000.000");

        try
        {
            checked
            {
                this.playCount += count; // Menambahkan play count
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count melebihi batas maksimum integer");
        }

        //POSTCONDITIONS: Memastikan playCount tidak berubah menjadi negatif setelah update
        Debug.Assert(this.playCount >= 0, "Postcondition: Play count tidak boleh negatif setelah penambahan");
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

            video.IncreasePlayCount(5000000); //menambahkan jumlah play count sebanyak 5.000.000
            video.PrintVideoDetails();

            // Pengujian batas maksimal play count dengan perulangan untuk menguji debug handling
            for (int i = 0; i < 5; i++)
            {
                video.IncreasePlayCount(20000000);//akan terjadi semacam alarm/pesan pemberitahuan dari debug jika melebihi batas dari 10.000.000
            }

            video.PrintVideoDetails();
    }
}

