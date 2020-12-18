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

            return null;
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


        public static string AsciiToBinary(string message)
        {
            string result="";

            foreach(char ch in message)
            {
                result +=(Convert.ToString((int)ch, 2)).Substring(2);// on convertit les lettres sur 5 bits
            }

            return result;
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

    }
}
