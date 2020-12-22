using System;
using System.Collections;
using System.Text;

/* Chiffrement.cs  *****************************************************************************************
 **********     @Authors :                                             Date : 23 Décembre 2020    **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Coulibaly                                                    **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 ***********************************************************************************************************/
namespace EncryptionOperation
{
    public static class Chiffrement
    {
        // Vecteur d'Initialisation
        // @see StringToByteArray : Passage de string en byte[]
        private static readonly byte[] VI = StringToByteArray("S");

        /**********************************************************************************************/
        /***************                METHODE CHIFFREMENT ET DECHIFFREMENT            ***************/
        /**********************************************************************************************/

        /**
        * Methode de Chiffrement : Methode Permettant de Chiffrer le message grâce à une clé de Transposition
        * @param message : Message à chiffrer (String)
        * @param cle : Correspond à la clé de transposition, utile pour retrouver le message chiffré
        * 
        * @return string
        * */
        public static string Chiffrer(string message, string cle)
        {
            // Transposition du Messsage
            string messageTranspose = Transposition(message, cle);
            Console.WriteLine($"Voici le message transposé de \"{message}\" :\n\t>>> {messageTranspose}\n");

            // Appel de la Methode de chiffrement par CBC sur le message transposé
            int[] resultatCBC = ChiffrementCBC(messageTranspose, VI);

            // Transformation de chaque bit du Resultat de CBC en String
            // @see IntToByteArray()    : Passage de int à byte[]
            // @see ByteArrayToString() : Passage de byte[] à string
            string resultatFinal = "";
            foreach (int i in resultatCBC)
            {
                resultatFinal += ByteArrayToString(IntToByteArray(i))[0];
            }
          
            return resultatFinal;
        }

       
        /** Methode Dechiffrer : Methode Permettant de Chiffrer le message grâce à une clé de Transposition
        * @param messageChiffre : Correspond au message préalablement chiffré, dont on veux dechiffrer.
        * @param cle : Correspond à la clé de transposition, utile pour retrouver le message Original
        * 
        * @return string
        * */
        public static string Dechiffrer(string messageChiffre, string cle)
        {
            // Décomposition du message chiffré en byte[]
            // @see StringToByteArray() : Passage de string en byte[]
            byte[] messageDecompose = StringToByteArray(messageChiffre);

            // Appel de la Methode de Dechiffrement par CBC
            int[] resultatCBC = DechiffrementCBC(messageDecompose, VI);

            // Transformation de chaque int de la variable ResultatCBC en String
            // @see IntToByteArray()    : Passage de int à byte[]
            // @see ByteArrayToString() : Passage de byte[] à string
            string translate = "";
            foreach (int i in resultatCBC)
            {
                translate += ByteArrayToString(IntToByteArray(i));
            }

            // Transposition du message déchiffré pour retourner au message Original
            string resultatFinal = TranspositionInverse(translate, cle);

            return resultatFinal;
        }


        /**********************************************************************************************/
        /******************             REMPLISSAGE DE LA MATRICE                    ******************/
        /**********************************************************************************************/

        /** Methode FillMatrice : Remplissage de la Matrice à partir du message
         *  Methode Utilisé pour remplir le tableau lors du CHIFFREMENT
         *  @param message : Le message à remplir dans la Matrice
         *  @param cle : la cle de Transposition, Utile pour determiner le nombre de colonne de la Matrice
         *  
         *  @return Matrice
         */
        private static Matrice FillMatrice(string message, string cle)
        {
            // Supprimer le '\0' accompagnant le message lors de l'encodage par l'espace vide
            string messageSansUnicode = message.Replace("\0", string.Empty);
            string[] cleSansEspace = cle.Split(' ');// on recupere la cle sans espace
            // longueur de la cle = nombre colonne de la Matrice
            int nbreColonne = cleSansEspace.Length;
            int sizeMessage = messageSansUnicode.Length;

            //il s'agit du nbreLigne que notre Matrice de transposition comporte
            int nbreLigne = sizeMessage % nbreColonne == 0 ? (sizeMessage / nbreColonne) : ((sizeMessage / nbreColonne) + 1);
            Matrice uneMatrice = new Matrice(nbreLigne, nbreColonne);

            // Remplissage de la Matrice
            int curseur = 0; // curseur de deplacement dans la matrice qui designe le caractere courant
            for (int i = 0; i < nbreLigne; i++)
            {
                for (int j = 0; j < nbreColonne; j++)
                {
                    if (curseur <= (nbreLigne * nbreColonne))
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


        /** Methode FillMatriceTransInvers : Remplissage de la Matrice à partir du message
         *  Methode Utilisé pour remplir le tableau lors du DECHIFFREMENT
         *  @param message : Le message à remplir dans la Matrice
         *  @param cle : la cle de Transposition, Utile pour determiner le nombre de colonne de la Matrice
         *  
         *  @return Matrice
         */
        private static Matrice FillMatriceTransInverse(string message, string cle)
        {
            // Supprimer le '\0' accompagnant le message lors de l'encodage par l'espace vide
            string messageSansUnicode = message.Replace("\0", string.Empty);
            string[] cleSansEspace = cle.Split(' ');// on recupere la cle sans espace
            // longueur de la cle = nombre colonne de la Matrice
            int nbreColonne = cleSansEspace.Length;
            int sizeMessage = messageSansUnicode.Length;

            // il s'agit du nbLigne que notre Matrice de transposition comporte
            int nbreLigne = sizeMessage % nbreColonne == 0 ? (sizeMessage / nbreColonne) : ((sizeMessage / nbreColonne) + 1);
            Matrice uneMatrice = new Matrice(nbreLigne, nbreColonne);

            // Associer chaque colonne de la Matrice avec son numero de la clé
            SortedList listeTransposition = new SortedList();

            // On remplit la Liste de correspondance de Colonne de la Matrice à la Clé de Transposition
            for (int i = 0; i < cleSansEspace.Length; i++)
            {
                listeTransposition.Add(int.Parse(cleSansEspace[i]), i);
            }

            // Constituer la Matrice avec le message à dechiffrer, tout en respectant l'ordre de la clé
            int curseur = 0; // Element courant sur le message
            for (int j = 0; j <= 9; j++)
            {
                if (listeTransposition[j] == null)
                {
                    continue;
                }
                else
                {
                    int positionDansCle = (int)listeTransposition[j]; // Position de la Colonne à remplir

                    for (int k = 0; k < uneMatrice.RowSize; k++)
                    {
                        if (uneMatrice[k, positionDansCle] == null) {
                            uneMatrice[k, positionDansCle] = messageSansUnicode.Substring(curseur, 1);
                            curseur++;
                        }
                    }
                }
            }

            return uneMatrice;
        }


        /**********************************************************************************************/
        /**************                   TRANSPOSITION DES MESSAGES                    ***************/
        /**********************************************************************************************/
        /** Methode de Transposition : Methode permettant de Transposer le Message lors du Chiffrement
         * @param message : Le message à Transposer
         * @param cle : La clé de transposition à respecter lors de la transposition du message
         * 
         * @return string
         */
        public static string Transposition(string message, string cle)
        {
            // on remplit la Matrice des caractères constituant le message
            // @see FillMatrice() : permet de remplir le atrice lors du Chiffrement
            Matrice uneMatrice = FillMatrice(message, cle);

            string[] cleSansEspace = cle.Split(' ');
            string messageTranspose = ""; //varible qui capture le message qu'on transpose

            //on associe a chaque chiffre de la cle sa position dans la cle
            SortedList listeTransposition = new SortedList();

            try
            {
                for (int i = 0; i < cleSansEspace.Length; i++)
                {
                    listeTransposition.Add(int.Parse(cleSansEspace[i]), i);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("1. Assurez-vous de ne pas avoir du blanc ' ' après avoir entrer la clé !\n" +
                    "2. Veuillez entrer des chiffres !");
                Environment.Exit(-1);
            }

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

        /** Methode de TranspositionInverse : Methode permettant de Transposer le Message lors du Dechiffrement
         * @param message : Le message à Transposer
         * @param cle : La clé de transposition à respecter lors de la transposition du message
         * 
         * @return string
         */
        public static string TranspositionInverse(string message, string cle)
        {
            // @see FillMatriceTransInverse() : Methode permettant de Remplir une matrice 
            // lors de l'opération de Dechiffrement
            Matrice uneMatrice = FillMatriceTransInverse(message, cle);

            return uneMatrice.ToString();
        }

        /**********************************************************************************************/
        /***********     CHIFFREMENT ET DECHIFFREMENT PAR CIPHER BLOCK CHAINING (CBC)       ***********/
        /**********************************************************************************************/

        /** Methode ChiffrementCBC : Permet de Chiffrer le message tout en faisant l'opération XOR sur chacune de byte
         * qui constitue le message.
         * @param message : le message à chiffrer, préalablement transposé.
         * @param VI : Le Vecteur d'Initialisation
         * @return int[]
         */
        public static int[] ChiffrementCBC(string messageTranspose, byte[] VI)
        {
            int[] result= new int[messageTranspose.Length];
            // @see StringToByteArray : Passage de string à byte[]
            byte[] msgToByte = StringToByteArray(messageTranspose);
            for(int i = 0; i < msgToByte.Length; i++)
                result[i] = (i == 0) ? (msgToByte[0] ^ VI[0]) : (msgToByte[i] ^ result[i - 1]);

            return result;
        }

        /** Methode ChiffrementCBC : Permet de Chiffrer le message tout en faisant l'opération XOR sur chacune de byte
         * qui constitue le message.
         * @param message : le message à chiffrer, préalablement transposé.
         * @param VI : Le Vecteur d'Initialisation
         * @return int[]
         */
        public static int[] DechiffrementCBC(byte[] messageChiffre, byte[] VI)
        {
            int[] result = new int [messageChiffre.Length];
            for (int i = 0; i < messageChiffre.Length; i++)
                result[i] = (i == 0) ? (messageChiffre[i] ^ VI[0]) : (messageChiffre[i] ^ messageChiffre[i - 1]);

            return result;
        }


        /**********************************************************************************************/
        /***************                    METHODES DE CONVERSION                      ***************/
        /**********************************************************************************************/

        /** Methode StringToByteArray(): permet de passer d'une chaine string à un tableau de byte
         * @param chaine : string dont on veut transformer en byte[]
         * @return byte[]
         */
        public static byte[] StringToByteArray(string chaine)
        {
            return Encoding.Default.GetBytes(chaine);
        }


        /** Methode IntToByteArray(): permet de passer d'un entier int à un tableau de byte
         * @param value : L'entier dont on veut transformer en byte[] 
         * @return byte[]
         */
        public static byte[] IntToByteArray(int value)
        {
            return BitConverter.GetBytes(value);
        }

        /** Methode ByteArrayToString(): permet de passer d'un tableau de byte à une chaine string
         * @param byteArray : le tableau de byte dont on veut transformer en string
         * @return string
         */
        public static string ByteArrayToString(byte[] byteArray)
        {
            return Encoding.ASCII.GetString(byteArray);
        }

    }
}
