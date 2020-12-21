using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EncryptionOperation
{
    public static class Chiffrement
    {
        //******************************************
        // Methode de Chiffrement
        // @return 
        public static string Chiffrer(string message, string cle)
        {
            //chiffrement par transposition
            string messageTranspose = Transposition(message, cle);


            //CBC
            byte[] VI = ToBinary('F');

            List<byte[]> listBytes = ChiffrementCbc(messageTranspose,VI);

            string text = fromCbcToString(listBytes);

       

            return text;
        }



        private static Matrice FillMatrice(string message, string cle)
        {

            string[] cleSansEspace = cle.Split(' ');// on recupere la cle sans espace
            //longueur de la cle sans espace (=nombre colonne de transposition)
            int longueurCle = cleSansEspace.Length;
            int longueurMessage = message.Length;

            //il s'agit du nbLigne que notre Matrice de transposition comporte
            int nbLigne = longueurMessage % longueurCle == 0 ? (longueurMessage / longueurCle) : ((longueurMessage / longueurCle) + 1);
            Matrice uneMatrice = new Matrice(nbLigne, longueurCle);

            int curseur = 0; // curseur de deplacement dans la matrice qui designe le caractere courant
            for (int i = 0; i < nbLigne; i++)
            {
                for (int j = 0; j < longueurCle; j++)
                {
                    if (curseur < longueurMessage)
                        uneMatrice[i, j] = message.ToCharArray()[curseur].ToString();
                    curseur++;
                }
            }

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

            for (int j = (int)listKeys[0]; j <= listKeys.Count; j++)
            {

                int positionDansCle = (int)listeTransposition[j];

                for (int k = 0; k < uneMatrice.RowSize; k++)
                {

                    if (uneMatrice[k, positionDansCle] != null)
                        messageTranspose += uneMatrice[k, positionDansCle];

                }
            }

            return messageTranspose;
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





        //******************************************
        // Methode de Dechiffrement
        // @return 
        public static string Dechiffrer(string message, string cle)
        {


            return null;
        }



        //******************************************
        // Methode de Chiffrement
        // @return byte[]
        public static byte[] Encodage(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            return bytes;
        }

        //******************************************
        // Methode de Dechiffrement
        // @return string
        private static string Decodage(byte[] bytes)
        {
            string data = Encoding.ASCII.GetString(bytes);
            return data;
        }



        public static byte[] OperationXor(byte[] tabA, byte[] tabB)
        {
            byte[] unTab = new byte[tabA.Length];
            for(int i =0; i< tabA.Length; i++)
            {
                unTab[i] = (byte)(tabA[i] ^ tabB[i]); 
            }

            return unTab;
        }

        /**
         * Methode qui permet d'afficher les contenues byte par byte d'un character (ex: S -> 10010)
         */
        public static void AfficheTabBytes(byte[] table)
        {
            foreach (byte b in table)
            {
                Console.Write(b);
            }
        }

        public static List<byte[]> ChiffrementCbc(string messageTranspose, byte[] VI)
        {
            List<byte[]> result= new List<byte[]>();
            for(int i = 0; i < messageTranspose.Length; i++)
            {
                char letter = Char.Parse(messageTranspose.Substring(i, 1));
                byte[] tabLetter = ToBinary(letter);
              
                if (i == 0)
                {
                    byte[] Einitial = OperationXor(tabLetter, VI);
                    result.Add(Einitial);
                    
                }
                else
                {   
                    byte[] Ecourant = OperationXor(tabLetter, result[i - 1]);
                    result.Add(Ecourant);
                }
            }

            return result;
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
