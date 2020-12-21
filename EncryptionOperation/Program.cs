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
            string message = "ce cours de mathematiques est tres interessant";
            string cle = "7 1 4 5 2 3 8 6";
            //string message2 = Chiffrement.Transposition(message, cle);
           // string message3 = Chiffrement.Transposition(message2, cle);
            //Console.WriteLine("Message chiffre : " + message2);
            //Console.WriteLine("Message chiffre : " + message3);


            char nom = 'S';
            byte[] tabA = Chiffrement.ToBinary(nom);
            byte[] tabB = Chiffrement.ToBinary('F');
            byte[] tab = Chiffrement.ToBinary(nom);
            for(int i=0;  i< tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }
            byte[] c = Chiffrement.ToBinary('A');
            //Console.WriteLine(Chiffrement.AsciiToBinary(nom));
            byte[] unTab = (Chiffrement.OperationXor(tabA,tabB));
            Chiffrement.AfficheTabBytes(unTab);

            

            Console.WriteLine("message chiffre---> "+Chiffrement.Chiffrer(message, cle));
        }
    }
}
