using System;
using System.Collections.Generic;
using System.Text;
/* Cryptage.cs  ********************************************************************************************
 **********     @Authors :                                             Date : 04 Décembre 2020    **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Coulibaly                                                    **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 ***********************************************************************************************************/
namespace EncryptionOperation
{
    class Cryptage
    {
        private string data;

        public Cryptage(string data)
        {
            this.data = data;
        }

        //******************************************
        // Methode de Chiffrement
        // @return byte[]
        private byte[] Encodage(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            return bytes;
        }

        //******************************************
        // Methode de Dechiffrement
        // @return string
        private string Decodage(byte[] bytes)
        {
            string data = Encoding.ASCII.GetString(bytes);
            return data;
        }

        private Matrice fillTable(int cle)
        {
            // Calculer la Longueur de la clé --> Ceci équivaut au nombre de colonne
            int nbreColonne = cle.ToString().Length;

            // Calculer la longueur de la chaîne à Chiffré --
            int tailleChaine = data.Length;

            // Calculer le nombre de ligne necessaire
            int nbreLigne = tailleChaine % nbreColonne == 0 ? (tailleChaine / nbreColonne) : ((tailleChaine / nbreColonne) + 1);

            // Remplissage du tableau
            Matrice tableau = new Matrice(nbreLigne, nbreColonne);
            int cpt = 0; // curseur de deplacement
            for (int i = 0; i < nbreLigne; i++)
            {
                for (int j = 0; j < nbreColonne; j++)
                {
                    if (cpt < tailleChaine)
                        tableau[i, j] = data.ToCharArray()[cpt].ToString();
                    cpt++;
                }
            }
            return tableau;
        }

        //******************************************
        // Methode de Transposition
        // @return 
        public string TraspositionString(int cle)
        {
            Matrice tableau = fillTable(cle);
            int row = tableau.Transposee().RowSize;
            int cols = tableau.Transposee().ColSize;
            Matrice mT = new Matrice(row, cols);
            mT = tableau.Transposee();

            return mT.ToString();
        }

   
    }
}
