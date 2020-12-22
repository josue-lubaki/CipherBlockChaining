using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EncryptionOperation
{

    public static class Chiffrement
    {
        private static byte[] VI = StringToByteArray("S");

        //******************************************
        // Methode de Chiffrement
        // @return 
        public static string Chiffrer(string message, string cle)
        {
            //chiffrement par transposition
            string messageTranspose = Transposition(message, cle);
            Console.WriteLine("Message transpose --> " + messageTranspose);


            //CBC
            int[] resultatCBC =ChiffrementCbc(messageTranspose, VI);

            string resultatFinal = "";
            foreach(int i in resultatCBC)
            {
                resultatFinal += ByteArrayToString(IntToByteArray(i))[0];
            }
          
            return resultatFinal;
        }



        //******************************************
        // Methode de Dechiffrement
        // @return 
        public static string Dechiffrer(string messageChiffre, string cle)
        {
           
            //Decomposition du message chiffré en un tableau de bytes
            byte[] messageDecompose = StringToByteArray(messageChiffre);

            //Dechiffrement CBC
            int[] resultatCBC = DechiffrementCbc(messageDecompose, VI);

            string resultatFinal = "";
            foreach (int i in resultatCBC)
            {
                resultatFinal += ByteArrayToString(IntToByteArray(i));
            }

            //transposition message chiffre
            string messageTranspose = TranspositionInverse(messageChiffre, cle);
            Console.WriteLine("Message transpose :" + messageTranspose);


            return resultatFinal;
            

        }

        public static byte[] OperationXor(byte[] tabA, byte[] tabB)
        {
            byte[] unTab = new byte[tabA.Length];
            for (int i = 0; i < tabA.Length; i++)
            {
                unTab[i] = (byte)(tabA[i] ^ tabB[i]);
            }

            return unTab;
        }


        /**
         *  Remplissage de la Matrice à partir du message lors de la Transoposition
         *  @return Matrice
         */
        private static Matrice FillMatrice(string message, string cle)
        {
            string messageSansUnicode = message.Replace("\0", string.Empty);
            string[] cleSansEspace = cle.Split(' ');// on recupere la cle sans espace
            //longueur de la cle sans espace (=nombre colonne de transposition)
            int longueurCle = cleSansEspace.Length;
            int longueurMessage = messageSansUnicode.Length;

            //il s'agit du nbLigne que notre Matrice de transposition comporte
            int nbLigne = longueurMessage % longueurCle == 0 ? (longueurMessage / longueurCle) : ((longueurMessage / longueurCle) + 1);
            Matrice uneMatrice = new Matrice(nbLigne, longueurCle);

            
            int curseur = 0; // curseur de deplacement dans la matrice qui designe le caractere courant
            for (int i = 0; i < nbLigne; i++)
            {
                for (int j = 0; j < longueurCle; j++)
                {
                    if (curseur <= (nbLigne * longueurCle))
                    {
                        if (curseur >= messageSansUnicode.Length)
                            uneMatrice[i, j] = " ";
                        else
                            uneMatrice[i, j] = messageSansUnicode.ToCharArray()[curseur].ToString();
                    }
                        
                    curseur++;
                }
            }

            return uneMatrice;
        }


        /**
         *  Remplissage de la Matrice à partir du message lors de la Transoposition
         *  @return Matrice
         */
        private static Matrice FillMatriceTransInvers(string message, string cle)
        {
            string messageSansUnicode = message.Replace("\0", string.Empty);
            string[] cleSansEspace = cle.Split(' ');// on recupere la cle sans espace
            //longueur de la cle sans espace (=nombre colonne de transposition)
            int longueurCle = cleSansEspace.Length;
            int longueurMessage = messageSansUnicode.Length;

            //il s'agit du nbLigne que notre Matrice de transposition comporte
            int nbLigne = longueurMessage % longueurCle == 0 ? (longueurMessage / longueurCle) : ((longueurMessage / longueurCle) + 1);
            Matrice uneMatrice = new Matrice(nbLigne, longueurCle);

            //Associer chaque colonne de la Matrice avec son numero de la clé
            SortedList listeTransposition = new SortedList();//on associe a chaque chiffre de la cle sa position dans la cle

            for (int i = 0; i < cleSansEspace.Length; i++)
            {
                listeTransposition.Add(int.Parse(cleSansEspace[i]), i);
            }

            int curseur = 0;
            for (int j = 0; j <= 9; j++)
            {

                if (listeTransposition[j] == null)
                {
                    continue;
                }

                else
                {
                    int positionDansCle = (int)listeTransposition[j];
                    for (int k = 0; k < uneMatrice.RowSize; k++)
                    {
                        if (uneMatrice[k, positionDansCle] == null) {
                            uneMatrice[k, positionDansCle] = messageSansUnicode.Substring(curseur, 1);
                            curseur++;
                        }
                            

                    }

                }
            }

            //lecture de la matrice 

            return uneMatrice;
        }




        public static string Transposition(string message, string cle)
        {
            Matrice uneMatrice = FillMatrice(message, cle);

            string[] cleSansEspace = cle.Split(' ');
            // il va falloir trier le tableau de caractère

            string messageTranspose = "";//varible qui capture le message qu'on transpose

            SortedList listeTransposition = new SortedList();//on associe a chaque chiffre de la cle sa position dans la cle

            for (int i = 0; i < cleSansEspace.Length; i++)
            {
                listeTransposition.Add(int.Parse(cleSansEspace[i]), i);
            }

            IList listKeys = listeTransposition.GetKeyList();

            for (int j = 0; j <= 9; j++)
            {
                if (listeTransposition[j] == null) { continue; }
                else
                {
                    int positionDansCle = (int)listeTransposition[j];


                    for (int k = 0; k < uneMatrice.RowSize; k++)
                    {

                        if (uneMatrice[k, positionDansCle] != null)
                            messageTranspose += uneMatrice[k, positionDansCle];

                    }
                }
            }

            return messageTranspose;
        }

        public static string TranspositionInverse(string message, string cle)
        {
            Matrice uneMatrice = FillMatrice(message, cle);            
           
            return uneMatrice.ToString();
        }

        public static string TranspositionInvers(string message, string cle)
        {
            Matrice uneMatrice = FillMatriceTransInvers(message, cle);

            return uneMatrice.ToString();
        }



        /**
         *  Methode Permettant de transformer un char en Binaire
         *  @return string
         */
        public static List<byte> AsciiToBinary(string message)
        {
            int taille = message.Length;
            List<byte> result = new List<byte>();

            // Tant qu'on n'a pas terminer de parcourir chaque lettre du message
            for (int i = 0; i < taille; i++)
            {
                // Decoupage de chaque caractère composant le message | Recupère une lettre
                char letter = Char.Parse(message.Substring(i, 1));

                // Methode  ary() transforme chaque caractère en tableau de 5 bits (ex : S = 10011)
                byte[] bytes = ToBinary(letter);

                // On ajoute chaque bit dans la liste de bit
                foreach (byte b in bytes)
                {
                    result.Add(b);
                }
            }

            return result;
        }

        /**
        *  Methode Permettant de transformer un char en Binaire
        *  @return byte[]
        */
        public static byte[] ToBinary(char character)
        {
            byte[] bytes = new byte[7]; //Besoin de 7 bits pour un caractère
            string st = (Convert.ToString((int)character, 2));// on convertit la lettre sur 7 bits;

            // on a 7 bits, On insère chaque bit dans le tableau de bits
            for (int i = 0; i < st.Length; i++)
            {
                bytes[i] = byte.Parse(st.Substring(i, 1));
            }

            return bytes;
        }

        /**
         * Methode qui permet d'afficher les contenues byte par byte d'un character (ex: S -> 10010)
         * 
         */
        public static void AfficheListBytes(List<byte> table)
        {
            foreach (byte b in table)
            {
                Console.Write(b);
            }
        }





        /**
         * Methode qui permet d'afficher les contenues byte par byte d'un character (ex: S -> 10010)
         */
        public static void AfficheTabBytes(byte[] table)
        {
            foreach (byte b in table)
            {
                Console.Write("/"+b);
            }
        }

        /** Methode ChiffrementCbc(): permet d'effectuer les operations XOR à partir du message transpos
         * on retourne un tableau contenant les valeurs entieres des operations
         */
        public static int[] ChiffrementCbc(string messageTranspose, byte[] VI)
        {
            int[] result= new int[messageTranspose.Length];
            byte[] msgToByte = StringToByteArray(messageTranspose);
            for(int i = 0; i < msgToByte.Length; i++)
            { 
                if (i == 0)
                {
                    result[i] = msgToByte[i] ^ VI[0];
                    
                }
                else
                {
                    result[i] = msgToByte[i] ^ result[i - 1];
                }
            }

            return result;
        }

        /** Methode
         * 
         */
        public static int[] DechiffrementCbc(byte[] messageChiffre, byte[] VI)
        {
            int[] result = new int [messageChiffre.Length];

            for (int i = 0; i < messageChiffre.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = messageChiffre[i] ^ VI[0];

                }
                else
                {
                    result[i] = messageChiffre[i] ^ messageChiffre[i-1];
                }
            }


            return result;
        }



        /**Methode StringToByteArray(): permet de passer d'une chaine string à un tableau de byte
         *
         */
        public static byte[] StringToByteArray(string chaine)
        {
            return Encoding.Default.GetBytes(chaine);
        }


        /**Methode IntToByteArray(): permet de passer d'un entier int à un tableau de byte
        *
        */
        public static byte[] IntToByteArray(int value)
        {
            return BitConverter.GetBytes(value);
        }

        /**Methode ByteArrayToString(): permet de passer d'un tableau de byte à une chaine string
         * 
         */
        public static string ByteArrayToString(byte[] byteArray)
        {
            return Encoding.ASCII.GetString(byteArray);
        }


       
        public static string fromCbcToString(List<byte[]> list)
        {
            string result = "";
            string str = "";
            for(int i= 0;i < list.Count;i++)
            {
                str = Encoding.UTF8.GetString(list[i], 0, list[i].Length);

                result += str;
            }
            return result;
        }


    }
}
