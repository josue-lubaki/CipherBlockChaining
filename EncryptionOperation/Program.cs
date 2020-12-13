using System;
using System.Text;
/* Program.cs  *********************************************************************************************
 **********     @Authors :                                             Date : 04 Décembre 2020    **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Coulibaly                                                    **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 ***********************************************************************************************************/
namespace EncryptionOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Cryptage m = new Cryptage("Bonjour, je m'ap");
            string mot = m.TraspositionString(1234);
            Console.WriteLine(mot);

            // Transposition de nouveau pour revenir à la phrase initiale
            Cryptage p = new Cryptage(mot);
            string mots = p.TraspositionString(1234);
            Console.WriteLine(mots);
        }
    }
}
