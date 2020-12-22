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
            string message = "josue";
            string cle = "9 1 4 5";
            string messageChiffre = Chiffrement.Chiffrer(message,cle);
            Console.WriteLine("Message chiffre ---> "+messageChiffre);
            string messageDechiffre = Chiffrement.Dechiffrer(messageChiffre, cle);
            Console.WriteLine("Message Dechiffre ---> " + messageDechiffre);
            Console.WriteLine("TRanspose du msg dechiffre = " + Chiffrement.TranspositionInvers(messageDechiffre, cle));
            

            /*byte[] vi = Encoding.ASCII.GetBytes("S");
            Chiffrement.AfficheTabBytes(vi);
            Console.WriteLine("vi[0] : "+vi[0]);

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

            */





        }
    }
}
