using System;
/* Matrice.cs  *********************************************************************************************
 **********     @Authors :                                             Date : 04 Décembre 2020    **********
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
        /***************                    OPERATION SUR LES MATRICES                  ***************/
        /**********************************************************************************************/


        /** Opération : Est Carree ? 
         *  Cette fonction renvoi <<True>> si la Matrice est Carrée (2 par 2 || 3 par 3 ||...) 
         *  Condition : Nombre de Colonne == Nombres de ligne 
         *
         *  @return bool */
        public bool EstCarree
        {
            get
            {
                return (RowSize == ColSize) ? true : false;
            }
        }

        /** Opération : Transposé d'une Matrice 
         *  Condition : La Matrice doit être Carrée afin de trouver sa Transposée 
         *  
         *  @return Matrice */
        public Matrice Transposee()
        {
            if (!EstCarree)
            {
                Matrice matrice = new Matrice(ColSize, RowSize);
                for (int i = 0; i < RowSize; i++)
                {
                    for (int j = 0; j < ColSize; j++)
                    {
                        matrice[j, i] = Data[i, j];
                    }
                }
                return matrice;
            }

            Matrice matrix = new Matrice(RowSize, ColSize);
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                {
                    if (i == j) // Pour ne pas modifier la Trace
                    {
                        matrix[i, j] = Data[i, j];
                        break;
                    }
                    // Swap
                    string tempo = Data[i, j];
                    matrix[i, j] = Data[j, i];
                    matrix[j, i] = tempo;
                }
            }
            return matrix;

        }

       
        /**********************************************************************************************/
        /***************                MANIPULATION DES DONNEES DE LA MATRICE          ***************/
        /**********************************************************************************************/
        /** Obtenir un élement en particulier du Tableau 
         *  1er Paramètre : Correspond au numero de Ligne 
         *  2ème Paramètre : Correspond au numero de la Colonne 
         *  
         *  @return double  
         */
        public string GetElement(int ligne, int colonne)
        {
            return Data[ligne, colonne];
        }

        /** Modifier un élement en particulier du Tableau
         *  1er Paramètre : Correspond au numero de Ligne 
         *  2ème Paramètre : Correspond au numero de la Colonne 
         *  3ième Paramètre : Correspond à la nouvelle Valeur à Insérer 
         *  
         *  @return void    */
        public void SetElement(int ligne, int colonne, string value)
        {
            Data[ligne, colonne] = value;
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
