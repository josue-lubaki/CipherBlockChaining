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
            string option_User;
            do
            {

                Console.WriteLine("\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
                Console.WriteLine("\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ MENU PRINCIPAL ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
                Console.WriteLine("\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
                Console.WriteLine("\nVoici les Options disponibles :" +
                   "\n\t1. Chiffrement" +
                   "\n\t2. Dechiffrement" +
                    "\n\t3. Chiffrement et Déchiffrement"+
                    "\n\t4. Quitter\n");
                Console.Write("Selectionner l'Option : ");
                option_User = Console.ReadLine();
                switch (option_User)
                {
                    case "1":
                        {
                            // Option 1 : Afficher le menu des opérations sur les matrices
                            OperationChiffrement();
                            break;

                        }
                    case "2":
                        {
                            // Option 2 : Affciher le menu des Opérations sur les systèmes d'équations matricielles
                            OperationDechiffrement();
                            break;
                        }
                    case "3":
                        {
                            // Option 3 : quitter le programme
                            ChiffrementDechiffrement();
                            
                            break;
                        }
                    case "4":
                        {
                            // Option 3 : quitter le programme
                            Console.WriteLine();
                            Quitter();
                            break;
                        }


                    default:
                        Console.WriteLine("Entrer une Option Valide !\n");
                        break;
                }

            } while (option_User != "1" || option_User != "2" || option_User != "3" || option_User == string.Empty);
            //****************************************************************************************************//

           
            //***************************************** Chiffrement  *******************************************///
            static void OperationChiffrement()
            {
                
                string message_user = string.Empty;
                Console.Write("Veuillez entrer un message : ");
                message_user = Console.ReadLine();

                string cle_user = string.Empty;
                Console.Write("Veuillez entrer une clé (exemple :9 1 4 5 7) : \n");
                cle_user = Console.ReadLine();
                //chiffrer
                Console.WriteLine("Votre message : " + message_user + '\n');
                Console.WriteLine("Message chiffré : "+ Chiffrement.Chiffrer(message_user, cle_user) + '\n');


            }
            //********************************************************************************///

            //********************************** Dechiffrement *******************************///
            static void OperationDechiffrement()
            {
                
                string message_user = string.Empty;
                Console.Write("Veuillez entrer un message : ");
                message_user = Console.ReadLine();

                string cle_user = string.Empty;
                Console.Write("Veuillez entrer une clé (exemple :9 1 4 5 7) : \n");
                cle_user = Console.ReadLine();
                //Dechiffrer
                Console.WriteLine("Votre message : " + message_user+'\n');
                Console.WriteLine("Message déchiffré : \n");
                Console.WriteLine(Chiffrement.Dechiffrer(message_user, cle_user) + '\n');


            }
            //********************************************************************************///

            //************************* Chiffrement et Dechiffrement *************************///
            static void ChiffrementDechiffrement()
            {
                
                string message_user=string.Empty;
                Console.Write("Veuillez entrer un message : ");
                message_user = Console.ReadLine();

                string cle_user = string.Empty;
                Console.Write("Veuillez entrer une clé (exemple :9 1 4 5 7) : \n");
                cle_user = Console.ReadLine();
                //chiffrer
                Console.WriteLine("Votre message : " + message_user);
                string messageChiffre = Chiffrement.Chiffrer(message_user, cle_user);
                Console.WriteLine("Message chiffré : " + messageChiffre + '\n');

                //dechiffrement
                Console.WriteLine("Message déchiffré : \n");
                Console.WriteLine(Chiffrement.Dechiffrer(messageChiffre, cle_user)+'\n');

            }
            //********************************************************************************///




            //*********************************** Quitter() ************************************///
            static void Quitter()
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
                Console.WriteLine("\t\t\t■ ■ ■ ■ ■ ■ ■ Copyright 2020 - Ghost Team ■ ■ ■ ■ ■ ■ ■ ■");
                Console.WriteLine("\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
                Console.ResetColor();
                Console.ReadLine();
                Environment.Exit(0);

            }
            //********************************************************************************///


        }
    }
}
