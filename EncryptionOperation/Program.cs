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
            string message2 = Chiffrement.Transposition(message, cle);
           // string message3 = Chiffrement.Transposition(message2, cle);
            //Console.WriteLine("Message chiffre : " + message2);
            //Console.WriteLine("Message chiffre : " + message3);


            char nom = 'S';
            byte[] tabA = Chiffrement.ToBinary(nom);
            byte[] tabB = Chiffrement.ToBinary('F');
            byte[] tab = Chiffrement.ToBinary(nom);
           
            

            Console.WriteLine("message chiffre---> "+Chiffrement.Chiffrer(message, cle));
            byte[] vi = Encoding.ASCII.GetBytes("S");
            Chiffrement.AfficheTabBytes(vi);
            Console.WriteLine("$$$$$$$$$$$$$$$$");

           byte[] msgToBytes = Encoding.ASCII.GetBytes(message2);
            int[] decValue = new int[message2.Length];
            Chiffrement.AfficheTabBytes(msgToBytes);
            Console.WriteLine("$"+Encoding.Default.GetString(msgToBytes));



            decValue[0] = msgToBytes[0] ^ vi[0];
            Console.WriteLine("$ cash:" + msgToBytes[0]);
            Console.WriteLine("decavlue  "+decValue[0]);


            byte[] untableau = Encoding.ASCII.GetBytes(decValue[0].ToString());
            Chiffrement.AfficheTabBytes(untableau);

            Console.WriteLine("resultat final :"+Encoding.UTF8.GetString(BitConverter.GetBytes(decValue[0])));


        }
    }
}
