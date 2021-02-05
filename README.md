DESCRIPTION
    Il vous est demandé de coder une classe permettant de chiffrer un message de texte en utilisant
    la méthode Cipher Block Chaining (CBC), et comme fonction de chiffrement des blocs un
    chiffrement par transposition et ce, en utilisant exactement la stratégie décrite dans les notes de
    cours (voir exemple « ce cours de mathématiques est très intéressant »). Nous allons cependant
    introduire une variante afin de simplifier quelque peu le processus.
    Pour cela, vous devez créer une classe statique « Chiffrement » possédant deux méthodes :
        - String Chiffrer(String message, String cle)
        - String Dechiffrer(String message, String cle)
        
Pour le chiffrement :
    - Dans un premier temps, le message au complet devra subir un chiffrement par
    transposition en utilisant une clé de transposition au choix de l’utilisateur, composée
    d’une chaîne de caractères composée d’une série de nombres séparés par un caractère
    d’espacement (p. ex. « 1 4 6 5 3 2 »). La quantité de nombres dans la série donnera par
    le fait même le nombre de colonnes de transposition.
    Considérez que l’utilisateur entrera une série adéquate.
    - Dans un deuxième temps, vous devez utiliser la méthode de chiffrement par bloc CBC sur
    le message précédemment transposé en considérant que 1 caractère (1 octet) = 1 bloc.
    La clé (fonction) de chiffrement ayant déjà été appliquée préalablement sur le message
    en entier, vous n’avez qu’à effectuer l’opération XOR entre la valeur du bloc clair avec la
    valeur du bloc chiffré précédent (ou le vecteur d’initialisation pour le premier bloc à
    chiffrer).
    
Cela implique que vous devrez transformer la chaîne de caractères comportant le
message en un tableau d’octets (byte[]) qui constituera l’ensemble des blocs clairs. Le
tableau d’octets chiffrés que vous aurez produit suite au chiffrement par CBC devra être
reformé en une chaîne de caractère que vous retournerez à l’appelant et qui formera ainsi
le message chiffré.

Pour le déchiffrement :
    - Vous devez d’abord décomposé le message chiffré en un tableau d’octets, sur lequel vous
    appliquez l’algorithme de déchiffrement avec la méthode CBC sur chacun des blocs
    d’octet. Cela aura alors pour effet de reconstituer le message transposé.
    - Puis, vous devez appliquer la transposition inverse en respectant la clé de transposition
    fournie par l’utilisateur et retourner le message résultant. Avec la même clé detransposition utilisée pour le chiffrement (et un peu de « chance » !), le message retourné
    devrait être celui d’origine.
    
Précisions supplémentaires:
    Le vecteur d’initialisation (VI), si vous le souhaitez, des raisons de simplification, peut être
    prédéterminé et le même à l’intérieur des méthodes de chiffrement et déchiffrement et non
    pas déterminé au hasard.
    La clé de transposition sera la clé transmise lors du chiffrement et la même clé devra être fournie
    lors du déchiffrement afin de pouvoir bien ordonner les colonnes et reconstituer le message
    d’origine ligne par ligne.
    