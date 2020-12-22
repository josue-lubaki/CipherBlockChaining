using System;

/* Program.cs  *********************************************************************************************
 **********     @Authors :                                             Date : 23 Décembre 2020    **********
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
            string message = "etudiant";
            string cle = "7 1 4 5";
            Console.WriteLine("Votre Message : " + message);
            string messageChiffre = Chiffrement.Chiffrer(message,cle);
            Console.WriteLine("Message Chiffré : " + messageChiffre);
            string messageDechiffre = Chiffrement.Dechiffrer(messageChiffre, cle);
            Console.WriteLine("Message Dechiffré : " + messageDechiffre);
            
        }
    }
}
