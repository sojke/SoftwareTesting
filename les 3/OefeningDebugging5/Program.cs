// See https://aka.ms/new-console-template for more information

using System.Text;

string w;
int i, t, ttl;
List<TimeSheetEntry> ents = new List<TimeSheetEntry>();
TimeSheetEntry ent = new TimeSheetEntry();
bool cont = false;
do
{
    Console.Write("Wat heb je gedaan, voor wie?");
    w = Console.ReadLine();
    Console.Write("Hoe lang heb je gewerkt?");
    t = int.Parse(Console.ReadLine());
    ents.Add(new TimeSheetEntry());
    ents.Last().WorkDone = w;
    ents.Last().HoursWorked = t;
    Console.Write("Wil je nog een tijdeenheid ingeven? (JA/NEE)");
    if (Console.ReadLine() == "ja")
    {
        cont = true;
    }
    else
    {
        cont = false;
    }
} while (cont == true);
ttl = 0;
for (i = 0; i < ents.Count; i++)
{
    if (ents[i].WorkDone.Contains("AP"))
    {
        ttl += ents[i].HoursWorked;
    }
}
Console.OutputEncoding = Encoding.Default;
Console.WriteLine("Simulatie zenden email naar AP");
Console.WriteLine("De rekening is €" + (ttl * 150) + " voor de gewerkte uren.");
ttl = 0;
for (i = 0; i < ents.Count; i++)
{
    if (ents[i].WorkDone.Contains("Microsoft"))
    {
        ttl += ents[i].HoursWorked;
    }
}
Console.WriteLine("Simulatie zenden email naar Microsoft");
Console.WriteLine("De rekening is €" + (ttl * 125) + " voor de gewerkte uren.");
ttl = 0;
for (i = 0; i < ents.Count; i++)
{
    ttl += ents[i].HoursWorked;
}
if (ttl > 40)
{
    Console.WriteLine("Je verdient €" + (ttl * 15) + " voor je werk.");
}
else
{
    Console.WriteLine("Je verdient €" + (ttl * 10) + " voor je werk.");
}
Console.WriteLine();
Console.Write("Druk op een toets om de applicatie af te sluiten...");
Console.ReadKey();


public class TimeSheetEntry
{
    public string WorkDone;
    public int HoursWorked;
}

