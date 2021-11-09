using System;
using System.IO;

namespace Report
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dammi l'indirizzo del file");
            string indirizzo = Console.ReadLine();

            string testoFile = LeggiIlFile(indirizzo);

            if (testoFile == null)
            {
                return;
            }


        


            Console.WriteLine("Vuoi un Nuovo file o vuoi Sovrascrivere il precedente?");
            Console.WriteLine("Seleziona N per nuovo e S per sovrascrivere");
            string sceltaNuovo = Console.ReadLine();

            
            Console.WriteLine(" Report");

            int sceltaFunzione = Convert.ToInt32(Console.ReadLine());

            switch (sceltaFunzione)
            {
               
                case 3:
                    Console.WriteLine("Dammi la parola da contare");
                    string parolaDaContare = Console.ReadLine();

                 string testoReport = Report(testoFile, parolaDaContare);

                ScriviIlFile(testoReport, indirizzo, sceltaNuovo);
                    break;

                 
            }



}

            private static string Report(string testoFile, string parolaDaContare)
{
             string[] parole = testoFile.Split(new[] { '\n', '\r', ' ', '\t' });

              int contoTutteParole = parole.Length;

              int indice = 0;

              int contoParole = 0;

    do
    {
        indice = testoFile.IndexOf(parolaDaContare, indice);
        if (indice != -1)
        {
            contoParole++;
        }
    } while (indice != -1);

    //for (int i = 0; i < parole.Length; i++)
    //{
    //    string parola = parole[i];

    //    if (parola.Contains(parolaDaContare))
    //    {
    //        contoParole++;
    //    }

    //}

                  string report = "Il numero totale delle parole è: " + contoTutteParole
                    + Environment.NewLine +
                    "La parola " + parolaDaContare + "appare: " + contoParole + " volte"
                    + Environment.NewLine +
                    "La percentuale di occorrenza è: " + ((contoParole / contoTutteParole) * 100) + "%";

                    string testoPiuReport = testoFile
                            + Environment.NewLine
                            + Environment.NewLine
                            + report;

                    return testoPiuReport;

}



public static string LeggiIlFile(string indirizzo)
{
    if (File.Exists(indirizzo))
    {
        try
        {
            string testoDelFile = File.ReadAllText(indirizzo);
            return testoDelFile;
        }
        catch (Exception)
        {
            Console.WriteLine("File non accessibile");
            return null;
        }
    }
    else
    {
        Console.WriteLine("Il file non esiste");
        return null;
    }
}

public static void ScriviIlFile(string testoDaSalvare, string indirizzo, string sceltaNuovo)
{
    if (sceltaNuovo.Equals("N"))
    {
        string[] percorso = indirizzo.Split("\\");
        percorso[percorso.Length - 1] = "copia.txt";
        string nuovoIndirizzo = string.Join("\\", percorso);
        try
        {
            File.WriteAllText(nuovoIndirizzo, testoDaSalvare);
        }
        catch (Exception)
        {
            Console.WriteLine("Impossibile Salvare");
        }

    }
    else
    {
        try
        {
            File.WriteAllText(indirizzo, testoDaSalvare);
        }
        catch (Exception)
        {

            Console.WriteLine("Impossibile Salvare");
        }

    }
}


        //public static string Maiuscolizza(string stringa)
        //{
        //    return stringa[0].ToString().ToUpper() + stringa.Substring(1);
        //}
    }
}
