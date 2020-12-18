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
            string message = "ce cours de mathématiques est très intéressant";
            string cle = "7 1 4 5 2 3 8 6";
            string message2 = Chiffrement.Transposition(message, cle);
            Console.WriteLine("Message chiffre : " + message2);

            string nom = "S";
            byte[] tab = Chiffrement.Encodage(nom);
            for(int i=0;  i< tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }

            Console.WriteLine(Chiffrement.AsciiToBinary(nom));
        }
    }
}
