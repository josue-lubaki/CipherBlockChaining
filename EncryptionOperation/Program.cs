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
            Console.WriteLine("Message ---> " + message);
            string messageChiffre = Chiffrement.Chiffrer(message,cle);
            Console.WriteLine("Message chiffre ---> "+messageChiffre);
            string messageDechiffre = Chiffrement.Dechiffrer(messageChiffre, cle);
            Console.WriteLine("Message Dechiffre ---> " + messageDechiffre);
            
        }
    }
}
