using System;
/* Matrice.cs  *********************************************************************************************
 **********     @Authors :                                             Date : 23 Décembre 2020    **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Coulibaly                                                    **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 ***********************************************************************************************************/
namespace EncryptionOperation
{
    class Matrice
    {
        /**********************************************************************************************/
        /***************                VARIABLES INSTANCES & CONSTRUCTEUR              ***************/
        /**********************************************************************************************/
        private string[,] data;
        public Matrice(int nombreLigne, int nombreColonne)
        {
            this.data = new string[nombreLigne, nombreColonne];
        }
        public string[,] Data
        {
            get { return data; }
            set { data = value; }
        }


        /**********************************************************************************************/
        /***************                    DIMENSION DE LA MATRICE                     ***************/
        /**********************************************************************************************/
        /** Obtenir la Taille de la Matrice : Ligne et Colonne 
         *  RowSize : Nombre des lignes contenues dans la matrice
         *  ColSize : Nombre des Colonnes contenues dans la matrice 
         *  
         *  @return int    */
        public int RowSize
        {
            get { return data.GetLength(0); }
        }
        public int ColSize
        {
            get { return data.GetLength(1); }
        }


        /**********************************************************************************************/
        /****************                FORMAT DE SORTIE                               ***************/
        /**********************************************************************************************/
        /** Indexeur de la matrice 
         *  1er Paramètre : Correspond au numero de Ligne 
         *  2ème Paramètre : Correspond au numero de la Colonne 
         *  
         *  @return double  */
        public string this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                {
                    output += this[i, j];
                }
            }
            return output;
        }
    }
}
