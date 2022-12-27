using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinal
{
    class Program
    {
        static void BesoinAutreChose()
        {
            Console.WriteLine("  ");
            Console.WriteLine("Besoin d'autre chose ?");      //Retour au menu principal?
            Console.WriteLine("1. OUI          2. NON");
            int S = Convert.ToInt32(Console.ReadLine());
            if (S == 1)
            {
                Sommaire();
            }
            else if (S == 2)
            {
                Console.WriteLine("Merci, à bientôt");
            }
        }
        #region SommePuissance
        /// <summary>
        /// Demande à l’utilisateur de saisir deux nombres entiers positifs puis calcule et affiche la somme des chiffres se trouvant dans n^m
        /// </summary>
        static void SommePuissance()
        {
            ///1. Saisir le choix de l'utilisateur (un nombre n et sa puissance m)
            Console.WriteLine("Veuillez saisir un nombre et sa puissance");   //Demander le nombre et sa puissance
            int n, m;
            n = Convert.ToInt32(Console.ReadLine());                          //Lire le nombre (EXEMPLE: 2)
            m = Convert.ToInt32(Console.ReadLine());                          //Lire la puissance (EXEMPLE: 13)
            ///2. Affecter à la variable nombre: n^m
            int nombre = n;
            for (int k = 1; k <= m - 1; k++)                                  //Affecter a nombre la valeur du nombre et sa puissance (EXEMPLE: 2^13 = 8192)
            {
                nombre = nombre * n;
            }
            Console.WriteLine(n + "^" + m + " = " + nombre);                  //Afficher le résultat (EXEMPLE: 2^13=8192)
            string nom = Convert.ToString(nombre);
            ///3. Sépare chaque chiffre de "nombre" et les additionne
            n = nom.Length;                                                  //Affecter a n le nombre de chiffre dans le resultat (EXEMPLE: 4)
            int S = 0;
            string ligne = null;
            while (nombre > 9)                                               //Tant que nombre est composé de deux chiffres
            {
                n = n - 1;                                                   //(EXEMPLE: 4-1=3)
                int DixPuisN = 1;
                for (int i = 1; i <= n; i++)                                //(EXEMPLE: DixPuisN = 10^3)
                {
                    DixPuisN = DixPuisN * 10;
                }
                float y = nombre / DixPuisN;                                //(EXEMPLE: 8192/8000 = 8)
                int chiffre = (int)y;
                ligne = ligne + chiffre + " + ";                            //(EXEMPLE: 8 +)
                nombre = nombre - chiffre * DixPuisN;                       //(EXEMPLE: 8192-8000 = 192)
                S = S + chiffre;                                            //(EXEMPLE: S= 0+8 = 8)
            }
            S = S + nombre;                                                 //(EXEMPLE: Somme = 8+1+9+2=20)
            ///4. Afficher le résultat à l'utilisateur
            Console.WriteLine(ligne + nombre + " = " + S);                  //(EXEMPLE: Affiche" 8+1+9+2=20)
            BesoinAutreChose();
        }
        #endregion SommePuissance
        #region SommeDiviseur
        /// <summary>
        /// Saisie de l'utilisateur
        /// </summary>
        /// <returns> nbDiviseurs </returns> Le nombre saisi par l'utilisateur
        static int saisie()
        {
            //1. Saisie et initialisation des variables
            int nbDiviseurs = 0;
            Console.Write("Veuillez saisir un nombre entier positif : ");
            nbDiviseurs = Convert.ToInt32(Console.ReadLine());
            return nbDiviseurs;
        }

        /// <summary>
        /// Saisie du nombre et recherche des diviseurs
        /// </summary>
        /// <param name="nbDiviseurs"></param> Le nombre saisi par l'utilisateur
        /// <returns> tabValeur </returns> Il retourne la liste des diviseurs(sous forme de tableau)
        static List<int> afficherDiviseur(int nbDiviseurs)
        {
            int i = 0;
            int reste = 0;

            //2. Recherche des diviseurs
            List<int> tabValeurs;
            tabValeurs = new List<int>();

            for (i = 1; i <= nbDiviseurs; i++)
            {
                reste = nbDiviseurs % i;
                if (reste == 0)
                {
                    tabValeurs.Add(i);
                }
            }
            return tabValeurs;
        }
        /// <summary>
        /// il additione les diviseurs de nombre saisi
        /// </summary>
        /// <param name="tabValeurs"></param> Liste des diviseurs(sous forme de tableau)
        /// <param name="nbDiviseurs"></param> Le nombre saisi par l'utilisateur
        /// <returns> somme </returns> Il retourne la somme des diviseurs
        static int afficherSomme(List<int> tabValeurs, int nbDiviseurs)
        {
            int somme = 0;

            //3. Somme des diviseurs
            for (int i = 0; i < tabValeurs.Count; i++)
            {
                somme = tabValeurs.ElementAt(i) + somme;
            }

            return somme;
        }
        /// <summary>
        /// Affichage des diviseurs et de la somme
        /// </summary>
        /// <param name="tabValeurs"></param> Liste des diviseurs(sous forme de tableau)
        /// <param name="somme"></param> Somme des diviseurs
        /// <param name="nbDiviseurs"></param> Le nombre saisi par l'utilisateur
        static void reponse(List<int> tabValeurs, int somme, int nbDiviseurs)
        {
            Console.WriteLine("Les diviseurs de " + nbDiviseurs + " sont : ");
            Console.Write(" ");
            for (int i = 0; i < tabValeurs.Count; i++)
            {
                if (tabValeurs[i] == nbDiviseurs)
                {
                    Console.Write(tabValeurs.ElementAt(i).ToString());
                }
                else
                {
                    Console.Write(tabValeurs.ElementAt(i).ToString() + " ; ");
                }
            }
            Console.Write("\n");

            Console.WriteLine("La somme des diviseurs de " + nbDiviseurs + " est : ");
            Console.Write(" ");
            for (int i = 0; i < tabValeurs.Count; i++)
            {
                if (tabValeurs[i] == nbDiviseurs)
                {
                    Console.Write(tabValeurs.ElementAt(i).ToString());
                }
                else
                {
                    Console.Write(tabValeurs.ElementAt(i).ToString() + " + ");
                }
            }
            Console.WriteLine(" = " + somme);
        }
        /// <summary>
        /// Calcul de la somme des diviseurs d’un nombre entier positif
        /// </summary>
        static void SommeDiviseur()
        {
            List<int> tabValeurs = null;
            int somme = 0;
            int nbDiviseurs = 0;

            nbDiviseurs = saisie();
            tabValeurs = afficherDiviseur(nbDiviseurs);
            somme = afficherSomme(tabValeurs, nbDiviseurs);
            reponse(tabValeurs, somme, nbDiviseurs);
            BesoinAutreChose();
        }
        #endregion SommeDiviseur
        #region DecouverteAnnee
        /// <summary>
        /// Jeu avec un nombre d'essai illimité
        /// </summary>
        static void DecouverteAnneeSimple()
        {
            /// <summary>
            /// Deviner l'année choisi par l'ordinateur entre 1 et 2018
            /// Le nombre de coups sera affiché
            /// </summary>
            //1. Generateur d'année aléatoire
            Random generateur = new Random();
            int anneeCachee = generateur.Next(1, 2018);
            int coups = 0;
            Console.WriteLine("Veuillez saisir une année comprise entre 1 et 2018, elle devra être égale à celle déterminée par l'ordinateur.");
            int donneeEntree = 0;

            //2. Phase de recherche de l'année Cachée et compteur d'essai
            while (donneeEntree != anneeCachee)
            {
                Console.WriteLine(" ");
                Console.Write("Saisir une année : ");
                donneeEntree = Convert.ToInt32(Console.ReadLine());

                if (donneeEntree < anneeCachee)
                {
                    Console.WriteLine("Trop petite");
                    Console.WriteLine(" ");
                }
                else if (donneeEntree > anneeCachee)
                {
                    Console.WriteLine("Trop grand");
                    Console.WriteLine(" ");
                }
                else if (donneeEntree == anneeCachee)
                {
                    Console.WriteLine("Gagné !!");
                }
                coups++;
            }
            Console.WriteLine("Vous avez gagné au bout de " + coups + " coups.");
        }
        /// <summary>
        /// Jeu avec un nombre d'essai limité
        /// </summary>
        static void DecouverteAnneeLimite()
        {
            /// <summary>
            /// Deviner l'année choisi par l'ordinateur entre 1 et 2018
            /// il y aura un nombre d'essai limité saisi par l'utilisateur
            /// </summary>
            //1. Generateur d'année aléatoire
            Random generateur = new Random();
            int anneeCachee = generateur.Next(1, 2018);
            int coups = 0;
            int nbe = 0;

            //2. saisie du nombre d'essai maximun
            Console.WriteLine("Veuillez saisir un nombre d'essai maximum : ");
            nbe = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez saisir une année comprise entre 1 et 2018, elle devra être égale à celle déterminée par l'ordinateur.");
            int donneeEntree = 0;
            int essai = 0;
            Console.WriteLine(" ");

            //3. Phase de recherche de l'année Cachée et compteur d'essai
            while (donneeEntree != anneeCachee && coups < nbe)
            {
                coups++;
                essai = coups;
                Console.Write("Essai n° ");
                Console.WriteLine(essai);
                Console.Write("Saisir une année : ");
                donneeEntree = Convert.ToInt32(Console.ReadLine());

                if (donneeEntree < anneeCachee)
                {
                    Console.WriteLine("Trop petite");
                    Console.WriteLine(" ");
                }
                else if (donneeEntree > anneeCachee)
                {
                    Console.WriteLine("Trop grand");
                    Console.WriteLine(" ");
                }
            }
            if (donneeEntree == anneeCachee && coups <= nbe)
            {
                Console.WriteLine("Gagné !!");
                Console.WriteLine("Vous avez gagné au bout de " + coups + " coups.");
            }
            else
            {
                Console.WriteLine("Vous avez dépassé le nombre de coups jouable, vous avez perdu :-(");
            }

        }
        /// <summary>
        /// Affichage du Sommaire et demande à l'utilisateur quel mode de jeu adopter
        /// </summary>
        static void SommaireDecouverteAnnee()
        {
            Console.WriteLine("Selectionnez un mode de jeu :");
            Console.WriteLine("1. Decouverte d'une année simple");
            Console.WriteLine("2. Decouverte d'une année avec limite de coups");
            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix != 1 && choix != 2)
            {
                while (choix != 1 && choix != 2)
                {
                    Console.WriteLine("Cette option n'est pas valide veuillez choisir une option valide.");
                    choix = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (choix == 1)
            {
                DecouverteAnneeSimple();
            }
            else if (choix == 2)
            {
                DecouverteAnneeLimite();
            }
        }
        /// <summary>
        /// Jeu: Decouvrir l'année cachée par l'ordinateur
        /// </summary>
        static void DecouverteAnnee()
        {
            SommaireDecouverteAnnee();
            BesoinAutreChose();
        }
        #endregion DecouverteAnnee
        #region ConversionOctalDecimal
        /// <summary>
        /// 1. saisie d'un nombre en octal, verification des conditions pour la conversion et insertion du nombre dans un tableau pour le convertir plus facilement
        /// </summary>
        /// <returns> tabValeurs </returns> liste de chaque chiffre sous forme de tableeau
        static List<int> entreValeur()
        {
            string n = null;
            List<int> tabValeurs;
            tabValeurs = new List<int>();
            Console.Write("Saisir un nombre entier positif composé d'une suite de chiffres de 0 à 7 : ");
            n = Console.ReadLine();

            for (int i = 0; i < n.Length; i++)
            {
                //Si la saisie est negative
                int result = Int32.Parse(n);
                if (result < 0)
                {
                    while (result < 0)
                    {
                        result = Convert.ToInt32(result);
                        Console.Write("Les nombres négatifs ne sont pas acceptés, veuillez saisir un nombre positif : ");
                        result = Convert.ToInt32(Console.ReadLine());
                    }
                }
                string a = result.ToString();
                n = a;
                tabValeurs.Add(int.Parse(n[i].ToString()));

                //Si la saisie comporte un chiffre superieur à 8
                if (tabValeurs[i] > 7)
                {
                    while (tabValeurs[i] > 7)
                    {
                        Console.Write("Veuillez saisir une chaine de caractère valide : ");
                        result = Convert.ToInt32(Console.ReadLine());
                        string b = result.ToString();
                        n = b;

                        //Si dans la nouvelle saisie, le nombre est negatif
                        if (result < 0)
                        {
                            while (result < 0)
                            {
                                result = Convert.ToInt32(result);
                                Console.Write("Les nombres négatifs ne sont pas acceptés, veuillez saisir un nombre positif : ");
                                result = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        string c = result.ToString();
                        n = c;
                        tabValeurs[i] = int.Parse(n[i].ToString());
                    }
                }
            }
            Console.Write("Le nombre octal " + n + " vaut ");
            return tabValeurs;
        }
        /// <summary>
        /// 2. conversion du nombre octal en décimal et insertion de ce nombre convertis dans un autre tableau pour l'additionner
        /// </summary>
        /// <param name="tabValeurs"> de type List de int (tableau des chiffres du nombre saisi, séparés) </param>
        /// <returns> tabConvertie </returns> liste des chiffres convertis sous forme de tableau
        static List<double> conversion(List<int> tabValeurs)
        {
            double valeurOctal = 0;
            int valeur = 0;
            int n = 0;
            List<double> tabConvertie;
            tabConvertie = new List<double>();

            //conversion chiffre par chiffre
            for (int j = tabValeurs.Count - 1; j >= 0; j--)
            {
                valeur = tabValeurs[j];
                valeurOctal = valeur * Math.Pow(8, n);
                n++;
                tabConvertie.Add(valeurOctal);
            }
            return tabConvertie;
        }
        /// <summary>
        /// addition des chiffres convertis
        /// </summary>
        /// <param name="tabConvertie"> de type List de int (tableau des chiffres convertis) </param>
        static void somme(List<double> tabConvertie)
        {
            //Addition des chiffres convertis
            double somme = 0;
            for (int j = 0; j < tabConvertie.Count; j++)
            {
                somme = somme + tabConvertie[j];
            }
            Console.Write(somme + " en décimal.");
        }
        /// <summary>
        /// Conversion d'un nombre octal en décimal
        /// </summary>
        static void ConversionOctDec()
        {
            List<int> tabValeurs = null;
            List<double> tabConvertie = null;
            tabValeurs = entreValeur();
            tabConvertie = conversion(tabValeurs);
            somme(tabConvertie);
            BesoinAutreChose();

        }
        #endregion ConversionOctalDecimal
        #region ConversionDecimalOctal
        /// <summary>
        /// Conversion d'un nombre décimal en octal
        /// </summary>
        static void ConversionDecOct()
        {
            ///1. Saisie par l'utilisateur du nombre à convertir
            Console.WriteLine("Veuillez saisir un nombre entier à convertir: ");  //Demander un nombre à convertir
            int m = Convert.ToInt32(Console.ReadLine());                          //(EXEMPLE: 22)
            int n = m;
            string ligne = null;
            ///2. Conversion du nombr en utilisant la methode de la division successive
            if (n != 0)
            {
                while (n != 0)                                                    //Tant que le nombre est à valeur
                {
                    float valeur = n / 8;                                         //(EXEMPLE: valeur = 22/8 = 2.75)
                    int reste = n % 8;                                            //(EXEMPLE: reste = n%8 = 6)
                    ligne = reste + ligne;                                        //(EXEMPLE: ligne = 26)
                    n = (int)valeur;
                }
            }
            ///3. Affichage du résultat à l'utilis&ateur
            Console.WriteLine(m + " en décimal vaut " + ligne + " en octal.");    //(EXEMPLE: 22 en décimal vaut 26 en octal.)
            BesoinAutreChose();                                                   // Retour au menu principal ?
        }
        #endregion ConversionDecimalOctal
        #region TrianglePascal
        /// <summary>
        /// Affiche le triangle de Pascal d'une hauteur donnée par l'utilisateur
        /// </summary>
        static void TrianglePascal()
        {
            ///1. Saisie par l'utilisateur de la hauteur du triangle souhaité
            Console.WriteLine("Veuillez saisir la hauteur du triangle souhaité :");    //Demande à l'utilisateur la hauteur du triangle (EXEMPLE: 5)
            int h = Convert.ToInt32(Console.ReadLine());
            int m = h;
            string ligne = null;
            for (int i = 0; i < h; i++)                                                //Pour chaque ligne du triangle (EXEMPLE: 5),
            {
                int coef = 1;
                ligne = "1";
                //2. Tracer les espaces
                for (int k = 0; k < m; k++)                                            //Mettre autant d'espaces que le nombre de lignes à venir (EXEMPLE: "     ")
                {
                    Console.Write(" ");
                }
                m = (m - 1);
                //3. Placer les valeurs
                for (int j = 0; j < i; j++)                                            //Mettre les valeurs des nombre selon la ligne et la colonne séparé d'un espace (EXEMPLE: "1 1")
                {
                    coef = coef * (i - j) / (j + 1);
                    if (coef > 0)
                    {
                        ligne = (ligne + " " + coef);
                    }
                }
                Console.WriteLine(ligne);
            }
            BesoinAutreChose();
        }
        #endregion TrianglePascal
        #region Chiffrement/Dechiffrement
        #region Chiffrement Cesar
        /// <summary>
        /// Chiffrement d'un mot en utilisant la methode Cesar
        /// </summary>
        static void ChiffrementCesar()
        {
            /// <summary>
            /// Saisie d'une chaine de caractère et addition avec la clé
            /// </summary>
            //1. Saisies et initialisations des variables
            Console.Write("Veuillez saisir une chaîne de caractère : ");
            string mot = Convert.ToString(Console.ReadLine());
            Console.Write("Veuillez saisir un nombre entier pour le chiffrage : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int clé = (3 * n) / 2;
            Console.Write("Le chiffrage de " + mot + " est : ");

            //2. Addition de la clé sur chaque caractères
            for (int i = 0; i <= mot.Length - 1; i++)
            {
                int valeur = mot[i];
                int nValeur = 0;
                if (mot[i] > 31 && mot[i] < 48)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 47)              //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {
                        while (valeur > 47)
                        {
                            nValeur = valeur - 16;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 32;
                        }
                    }
                }
                if (mot[i] > 47 && mot[i] < 58)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 57)                //Pour rester dans le même dommaine afin de différencier chaque classe (chiffres)
                    {

                        while (valeur > 57)
                        {
                            nValeur = valeur - 10;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 48;
                        }
                    }
                }
                if (mot[i] > 57 && mot[i] < 65)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 64)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur > 64)
                        {
                            nValeur = valeur - 7;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 58;
                        }
                    }
                }
                if (mot[i] > 64 && mot[i] < 91)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 90)                //Pour rester dans le même dommaine afin de différencier chaque classe (majuscules)
                    {

                        while (valeur > 90)
                        {
                            nValeur = valeur - 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 65;
                        }
                    }
                }
                if (mot[i] > 90 && mot[i] < 97)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 96)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur > 96)
                        {
                            nValeur = valeur - 6;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 91;
                        }
                    }
                }
                if (mot[i] > 96 && mot[i] < 123)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 122)               //Pour rester dans le même dommaine afin de différencier chaque classe (minuscules)
                    {

                        while (valeur > 122)
                        {
                            nValeur = valeur - 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 97;
                        }
                    }
                }
                if (mot[i] > 122 && mot[i] <= 126)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 125)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur > 125)
                        {
                            nValeur = valeur - 4;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 123;
                        }
                    }
                }
                //3. Conversion en caractères
                char nouveauMot = Convert.ToChar(valeur);
                Console.Write(nouveauMot);

            }
            Console.WriteLine(" ");
            Console.WriteLine("Besoin d'autre chose ?");      //Retour au menu principal?
            Console.WriteLine("1. OUI          2. NON");
            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                SommaireChiffrement();
            }
            else if (choix == 2)
            {
                Console.WriteLine("Merci, à bientôt");
            }


        }
        #endregion Chiffrement Cesar
        #region Déchiffrement Cesar
        /// <summary>
        /// Déhiffrement d'un mot en utilisant la methode Cesar
        /// </summary>
        static void DechiffrementCesar()
        {
            //1. Saisies et initialisations des variables
            Console.Write("Veuillez saisir une chaîne de caractère : ");
            string mot = Convert.ToString(Console.ReadLine());
            Console.Write("Veuillez saisir un nombre entier pour le chiffrage : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int clé = (3 * n) / 2;
            Console.Write("Le chiffrage de " + mot + " est : ");

            //2. Soustrait de la clé sur chaque caractères
            for (int i = 0; i <= mot.Length - 1; i++)
            {
                int valeur = mot[i];
                int nValeur = 0;

                if (mot[i] > 31 && mot[i] < 48)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 32)              //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {
                        while (valeur < 32)
                        {
                            nValeur = valeur + 16;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 47;
                        }
                    }

                }

                if (mot[i] > 47 && mot[i] < 58)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 48)                //Pour rester dans le même dommaine afin de différencier chaque classe (chiffres)
                    {
                        while (valeur < 48)
                        {
                            nValeur = valeur + 10;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 57;
                        }
                    }
                }
                if (mot[i] > 57 && mot[i] < 65)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 58)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur < 58)
                        {
                            nValeur = valeur + 7;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 64;
                        }
                    }
                }
                if (mot[i] > 64 && mot[i] < 91)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 65)                //Pour rester dans le même dommaine afin de différencier chaque classe (majuscules)
                    {

                        while (valeur < 65)
                        {
                            nValeur = valeur + 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 90;
                        }
                    }
                }
                if (mot[i] > 90 && mot[i] < 97)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 91)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur < 91)
                        {
                            nValeur = valeur + 6;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 96;
                        }
                    }
                }
                if (mot[i] > 96 && mot[i] < 123)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 97)               //Pour rester dans le même dommaine afin de différencier chaque classe (minuscules)
                    {

                        while (valeur < 97)
                        {
                            nValeur = valeur + 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 122;
                        }
                    }
                }
                if (mot[i] > 122 && mot[i] <= 126)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 123)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur < 123)
                        {
                            nValeur = valeur + 4;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 125;
                        }
                    }
                }
                //3. Conversion en caractères
                char nouveauMot = Convert.ToChar(valeur);
                Console.Write(nouveauMot);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Besoin d'autre chose ?");      //Retour au menu principal?
            Console.WriteLine("1. OUI          2. NON");
            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                SommaireChiffrement();
            }
            else if (choix == 2)
            {
                Console.WriteLine("Merci, à bientôt");
            };

        }
        #endregion Déchiffrement Cesar
        #region Chiffrement innovant
        /// <summary>
        /// Etape 2: Applique l'effet miroir au mot choisi par l'utilisateur
        /// </summary>
        /// <param name="nouveauMot"></param> Mot saisi par l'utilisateur
        static void Miroir(char nouveauMot)
        {
            string ligne = "";
            string mot = Convert.ToString(nouveauMot);
            for (int i = 0; i <= mot.Length - 1; i++)
            {
                int vvaleur = mot[i];
                // int valeur = vvaleur;
                //string Newvaleur = Convert.ToString(ConversionHex(valeur));

                char NouveauMot = Convert.ToChar(vvaleur);
                ligne = (NouveauMot + ligne);
            }


            Console.Write(ligne);


        }
        /// <summary>
        /// Etape 1: Chiffre le mot avec effet miroir
        /// </summary>
        static void ChiffrementInnov()
        {
            //1. Saisies et initialisations des variables
            Console.Write("Veuillez saisir une chaîne de caractère : ");
            string mot = Convert.ToString(Console.ReadLine());
            Console.Write("Veuillez saisir un nombre entier pour le chiffrage : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int clé = (2 * n + 5);
            Console.Write("Le chiffrage de " + mot + " est : ");

            //2. Addition de la clé sur chaque caractères
            for (int i = 0; i <= mot.Length - 1; i++)
            {
                int valeur = mot[i];
                int nValeur = 0;

                if (mot[i] > 31 && mot[i] < 48)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 47)              //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur > 47)
                        {
                            nValeur = valeur - 16;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 32;
                        }
                    }

                }

                if (mot[i] > 47 && mot[i] < 58)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 57)                //Pour rester dans le même dommaine afin de différencier chaque classe (chiffres)
                    {

                        while (valeur > 57)
                        {
                            nValeur = valeur - 10;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 48;
                        }
                    }
                }
                if (mot[i] > 57 && mot[i] < 65)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 64)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur > 64)
                        {
                            nValeur = valeur - 7;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 58;
                        }
                    }
                }
                if (mot[i] > 64 && mot[i] < 91)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 90)                //Pour rester dans le même dommaine afin de différencier chaque classe (majuscules)
                    {

                        while (valeur > 90)
                        {
                            nValeur = valeur - 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 65;
                        }
                    }
                }
                if (mot[i] > 90 && mot[i] < 97)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 96)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur > 96)
                        {
                            nValeur = valeur - 6;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 91;
                        }
                    }
                }
                if (mot[i] > 96 && mot[i] < 123)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 122)               //Pour rester dans le même dommaine afin de différencier chaque classe (minuscules)
                    {
                        while (valeur > 122)
                        {
                            nValeur = valeur - 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 97;
                        }
                    }
                }
                if (mot[i] > 122 && mot[i] <= 126)
                {
                    valeur = mot[i] + clé;
                    if (valeur > 125)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {
                        while (valeur > 125)
                        {
                            nValeur = valeur - 4;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 123;
                        }
                    }
                }
                //3. Envoi des valeurs vers l'étape 2
                char nouveauMot = Convert.ToChar(valeur);
                Miroir(nouveauMot);

            }
            Console.WriteLine(" ");
            Console.WriteLine("Besoin d'autre chose ?");      //Retour au menu principal?
            Console.WriteLine("1. OUI          2. NON");
            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                SommaireChiffrement();
            }
            else if (choix == 2)
            {
                Console.WriteLine("Merci, à bientôt");
            }

        }
        #endregion Chiffrement innovant
        #region Dechiffrement Innovant
        /// <summary>
        /// Applique un effet miroir au mot
        /// </summary>
        /// <param name="demiroir"></param> Mot entré par l'utilisateur
        /// <returns></returns>
        static string Demiroir(string demiroir)
        {
            //a. Demande de la clé à l'utilisateur
            string ligne = "";
            Console.Write("Veuillez saisir un nombre entier pour le chiffrage : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int clé = (2 * n + 5);
            //b. Applique l'effet miroir au mot
            for (int i = demiroir.Length - 1; i >= 0; i--)
            {
                int vvaleur = demiroir[i];
                string valeur = Convert.ToString(vvaleur);
                char nouveauMot = Convert.ToChar(vvaleur);
                ligne = (nouveauMot + ligne);
                //c. Conversion inverse du nouveau mot
                Conversion(ligne, clé);
            }
            return demiroir;
        }
        /// <summary>
        /// Conversion inverse du nouveau mot
        /// </summary>
        /// <param name="ligne"></param>Mot avec effet miroir appliqué
        /// <param name="clé"></param>Clé choisie par l'utilisateur
        static void Conversion(string ligne, int clé)
        {
            string mot = ligne;
            Console.Write("Le déchiffrage de " + mot + " est : ");
            //a. Soustrait de la clé sur chaque caractères
            for (int i = 0; i <= mot.Length - 1; i++)
            {
                int valeur = mot[i];
                int nValeur = 0;

                if (mot[i] > 31 && mot[i] < 48)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 32)              //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {
                        while (valeur < 32)
                        {
                            nValeur = valeur + 16;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 47;
                        }
                    }

                }

                if (mot[i] > 47 && mot[i] < 58)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 48)                //Pour rester dans le même dommaine afin de différencier chaque classe (chiffres)
                    {
                        while (valeur < 48)
                        {
                            nValeur = valeur + 10;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 57;
                        }
                    }
                }
                if (mot[i] > 57 && mot[i] < 65)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 58)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur < 58)
                        {
                            nValeur = valeur + 7;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 64;
                        }
                    }
                }
                if (mot[i] > 64 && mot[i] < 91)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 65)                //Pour rester dans le même dommaine afin de différencier chaque classe (majuscules)
                    {

                        while (valeur < 65)
                        {
                            nValeur = valeur + 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 90;
                        }
                    }
                }
                if (mot[i] > 90 && mot[i] < 97)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 91)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur < 91)
                        {
                            nValeur = valeur + 6;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 96;
                        }
                    }
                }
                if (mot[i] > 96 && mot[i] < 123)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 97)               //Pour rester dans le même dommaine afin de différencier chaque classe (minuscules)
                    {

                        while (valeur < 97)
                        {
                            nValeur = valeur + 26;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 122;
                        }
                    }
                }
                if (mot[i] > 122 && mot[i] <= 126)
                {
                    valeur = mot[i] - clé;
                    if (valeur < 123)                //Pour rester dans le même dommaine afin de différencier chaque classe (caractères)
                    {

                        while (valeur < 123)
                        {
                            nValeur = valeur + 4;
                            valeur = nValeur;
                        }
                        if (valeur < 0)
                        {
                            valeur = 125;
                        }
                    }
                }
                //b. Conversion en caractères et affichage de la nouvelle valeur
                char nouveauMot = Convert.ToChar(valeur);
                Console.Write(nouveauMot);

            }
        }
        static void DechiffrementInnov()
        {
            //1. Saisie par l'utilisateur des variables
            Console.WriteLine("Veuillez saisir un terme à déchiffrer :");
            string dechiffre = Convert.ToString(Console.ReadLine());
            //2. Retournement du mot en miroir et conversion inverse
            Demiroir(dechiffre);
            Console.WriteLine(" ");
            Console.WriteLine("Besoin d'autre chose ?");      //Retour au menu principal?
            Console.WriteLine("1. OUI          2. NON");
            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                SommaireChiffrement();
            }
            else if (choix == 2)
            {
                Console.WriteLine("Merci, à bientôt");
            }
        }
        #endregion Dechiffrement Innovant
        #region Sommaire Chiffrement/Déchiffrement
        /// <summary>
        /// Affiche clairement le sommaire à l'utilisateur et reçoit son choix
        /// </summary>
        static void SommaireChiffrement()
        {
            Console.WriteLine("1. Chiffrement d'un mot avec César");
            Console.WriteLine("2. Déchiffrement d'un mot avec César");
            Console.WriteLine("3. Chiffrement d'un mot - Méthode innovante et personnelle");
            Console.WriteLine("4. Déchiffrement d'un mot - Méthode innovante et personnelle");
            Console.WriteLine("5. Quitter la partie B");
            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                ChiffrementCesar();
            }
            else if (choix == 2)
            {
                DechiffrementCesar();
            }
            else if (choix == 3)
            {
                ChiffrementInnov();
            }
            else if (choix == 4)
            {
                DechiffrementInnov();
            }
            else if (choix == 5)
            {
                Sommaire();
            }

        }
        #endregion Sommaire Chiffrement/Déchiffrement
        static void ChiffrementDechiffrement()
        {
            SommaireChiffrement();
        }
        #endregion Chiffrement/Dechiffrement
        #region Innovation
        /// <summary>
        /// Affiche la présentation du menu du distributeur de billets
        /// </summary>
        /// <returns></returns>
        static int Presentation()
        {
            Console.WriteLine("Bonjour je suis le distributeur de billets!");
            Console.WriteLine("Vous avez inseré votre carte et entré votre code secret.");
            Console.WriteLine("Quel montant désirez-vous retirer ?");
            Console.WriteLine("1- 10 euros       5- 50 euros");
            Console.WriteLine("2- 20 euros       6- 80 euros");
            Console.WriteLine("3- 30 euros       7- 100 euros");
            Console.WriteLine("4- 40 euros       8- Autre montant");
            Console.WriteLine("  ");
            Console.WriteLine("(Billets disponibles: 200, 100, 50, 20, 10, 5)");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6 && n != 7 && n != 8)
            {
                while (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6 && n != 7 && n != 8)
                {
                    Console.WriteLine("Désolé cette option n'existe pas");
                    Console.WriteLine("Veuillez choisir un montant à retirer:");
                    n = Convert.ToInt32(Console.ReadLine());
                }
            }
            return n;
        }
        /// <summary>
        /// Si l'utilisateur souhaite retirer un autre montant que les montants proposés
        /// </summary>
        /// <param name="m"></param> m le choix de l'utilisateur
        /// <returns></returns>
        static int AutreMontant(int m)
        {
            Console.WriteLine("Veuillez choisir un montant à retirer");
            m = Convert.ToInt32(Console.ReadLine());
            if (m > 1500)
            {
                while (m > 1500)
                {
                    Console.WriteLine("Désolé ce distributeur ne permet pas de retier plus de 1500 euros");
                    Console.WriteLine("Veuillez choisir un montant à retirer");
                    m = Convert.ToInt32(Console.ReadLine());
                }
            }

            return m;
        }
        /// <summary>
        /// Si l'utilisateur souhaite retirer un gros montant en grosses coupures
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>m étant le montant que l'utilisateur souhaite retirer
        static int MajoritePetit(int m)
        {
            int BilletVingt = 0;
            int BilletDix = 0;
            int BilletCinq = 0;
            int PieceUn = 0;
            Console.WriteLine("Vous avez choisi une majorité de petites coupures");
            int n, o;
            if (m % 2 == 0)
            {
                n = m / 2;
                o = m / 2;
                while (n >= 20)
                {
                    n = n - 20;
                    BilletVingt = BilletVingt + 1;
                }
                while (n >= 10)
                {
                    n = n - 10;
                    BilletDix = BilletDix + 1;
                }
                while (n >= 5)
                {
                    n = n - 5;
                    BilletCinq = BilletCinq + 1;
                }
                while (n >= 1)
                {
                    n = n - 1;
                    PieceUn = PieceUn + 1;
                }
                while (o >= 10)
                {
                    o = o - 10;
                    BilletDix = BilletDix + 1;
                }
                while (o >= 5)
                {
                    o = o - 5;
                    BilletCinq = BilletCinq + 1;
                }

                while (o >= 1)
                {
                    o = o - 1;
                    PieceUn = PieceUn + 1;
                }
            }
            if (m % 2 != 0)
            {
                m = m - 1;
                n = m / 2;
                o = m / 2;
                while (n >= 20)
                {
                    n = n - 20;
                    BilletVingt = BilletVingt + 1;
                }
                while (n >= 10)
                {
                    n = n - 10;
                    BilletDix = BilletDix + 1;
                }
                while (n >= 5)
                {
                    n = n - 5;
                    BilletCinq = BilletCinq + 1;
                }
                while (n >= 1)
                {
                    n = n - 1;
                    PieceUn = PieceUn + 1;
                }
                while (o >= 10)
                {
                    o = o - 10;
                    BilletDix = BilletDix + 1;
                }
                while (o >= 5)
                {
                    o = o - 5;
                    BilletCinq = BilletCinq + 1;
                }

                while (o >= 1)
                {
                    o = o - 1;
                    PieceUn = PieceUn + 1;
                }
                PieceUn = PieceUn + 1;
            }
            Console.WriteLine("Voici:");
            if (BilletVingt > 0)                                          // Rendu Billets de 20 ou non
            {
                if (BilletVingt == 1)
                {
                    Console.WriteLine(BilletVingt + " billet de vingt euros.");

                }
                Console.WriteLine(BilletVingt + " billets de vingt euros.");
            }
            if (BilletDix > 0)                                    // Rendu Billets de 10 ou non
            {
                if (BilletDix == 1)
                {
                    Console.WriteLine(BilletDix + " billet de dix euros.");

                }
                Console.WriteLine(BilletDix + " billets de dix euros.");
            }
            if (BilletCinq > 0)                                  // Rendu Billets de 5 ou non
            {
                if (BilletCinq == 1)
                {
                    Console.WriteLine(BilletCinq + " billet de cinq euros.");
                }
                Console.WriteLine(BilletCinq + " billets de cinq euros.");
            }
            if (PieceUn > 0)                                     // Rendu pièces de 1 ou non
            {
                if (PieceUn == 1)
                {
                    Console.WriteLine(PieceUn + " piece de un euro.");
                }
                Console.WriteLine(PieceUn + " pieces de un euro.");
            }
            return m;
        }
        /// <summary>
        /// Si l'utilisateur souhaite retirer un gros montant en grosses coupures
        /// </summary>
        /// <param name="m"></param> m étant le montant que l'utilisateur souhaite retirer
        /// <returns></returns>
        static int MajoriteGrand(int m)
        {

            int BilletDeuxCent = 0;
            int BilletCent = 0;
            int BilletCinquante = 0;
            int BilletVingt = 0;
            int BilletDix = 0;
            int BilletCinq = 0;
            int PieceUn = 0;
            Console.WriteLine("Vous avez choisi une majorité de grosses coupures.");
            if (m % 2 == 0)
            {
                while (m >= 200)
                {
                    m = m - 200;
                    BilletDeuxCent = BilletDeuxCent + 1;
                }
                while (m >= 100)
                {
                    m = m - 100;
                    BilletCent = BilletCent + 1;
                }
                while (m >= 50)
                {
                    m = m - 50;
                    BilletCinquante = BilletCinquante + 1;
                }
                while (m >= 20)
                {
                    m = m - 20;
                    BilletVingt = BilletVingt + 1;
                }
                while (m >= 10)
                {
                    m = m - 10;
                    BilletDix = BilletDix + 1;
                }
                while (m >= 5)
                {
                    m = m - 5;
                    BilletCinq = BilletCinq + 1;
                }
                while (m >= 1)
                {
                    m = m - 1;
                    PieceUn = PieceUn + 1;
                }
            }
            if (m % 2 != 0)
            {
                m = m - 1;
                while (m >= 200)
                {
                    m = m - 200;
                    BilletDeuxCent = BilletDeuxCent + 1;
                }
                while (m >= 100)
                {
                    m = m - 100;
                    BilletCent = BilletCent + 1;
                }
                while (m >= 50)
                {
                    m = m - 50;
                    BilletCinquante = BilletCinquante + 1;
                }
                while (m >= 20)
                {
                    m = m - 20;
                    BilletVingt = BilletVingt + 1;
                }
                while (m >= 10)
                {
                    m = m - 10;
                    BilletDix = BilletDix + 1;
                }
                while (m >= 5)
                {
                    m = m - 5;
                    BilletCinq = BilletCinq + 1;
                }
                while (m >= 1)
                {
                    m = m - 1;
                    PieceUn = PieceUn + 1;
                }
                PieceUn = PieceUn + 1;
            }
            Console.WriteLine("Voici:");
            if (BilletDeuxCent > 1)                                          // Rendu Billets de 200 ou non
            {
                Console.WriteLine(BilletDeuxCent + " billets de deux-cent euros.");
            }
            else if (BilletDeuxCent == 1)
            {
                Console.WriteLine(BilletDeuxCent + " billet de deux-cent euros.");

            }
            if (BilletCent > 0)                                          // Rendu Billets de 100 ou non
            {
                Console.WriteLine(BilletCent + " billets de cent euros.");
            }
            else if (BilletCent == 1)
            {
                Console.WriteLine(BilletCent + " billet de cent euros.");

            }
            if (BilletCinquante > 0)                                          // Rendu Billets de 50 ou non
            {
                Console.WriteLine(BilletCinquante + " billets de cinquante euros.");
            }
            else if (BilletCinquante == 1)
            {
                Console.WriteLine(BilletCinquante + " billet de cinquante euros.");

            }
            if (BilletVingt > 0)                                          // Rendu Billets de 20 ou non
            {
                Console.WriteLine(BilletVingt + " billets de vingt euros.");
            }
            else if (BilletVingt == 1)
            {
                Console.WriteLine(BilletVingt + " billet de vingt euros.");
            }
            if (BilletDix > 0)                                    // Rendu Billets de 10 ou non
            {
                Console.WriteLine(BilletDix + " billets de dix euros.");
            }
            else if (BilletDix == 1)
            {
                Console.WriteLine(BilletDix + " billet de dix euros.");
            }
            if (BilletCinq > 0)                                  // Rendu Billets de 5 ou non
            {
                Console.WriteLine(BilletCinq + " billets de cinq euros.");
            }
            else if (BilletCinq == 1)
            {
                Console.WriteLine(BilletCinq + " billet de cinq euros.");
            }
            if (PieceUn > 0)                                     // Rendu pièces de 1 ou non
            {
                Console.WriteLine(PieceUn + " pieces de un euro.");
            }
            else if (PieceUn == 1)
            {
                Console.WriteLine(PieceUn + " piece de un euro.");
            }
            return m;
        }
        /// <summary>
        /// Si l'utilisateur veut retirer une petite somme, lui donner les billets en fonctions
        /// </summary>
        /// <param name="m"></param>m étant la valeur que l'utilisateur veut retirer
        /// <returns></returns>
        static int PetitNombre(int m)
        {
            int BilletVingt = 0;
            int BilletDix = 0;
            int BilletCinq = 0;
            int PieceUn = 0;
            if (m % 2 == 0)
            {
                while (m >= 20)
                {
                    m = m - 20;
                    BilletVingt = BilletVingt + 1;
                }
                while (m >= 10)
                {
                    m = m - 10;
                    BilletDix = BilletDix + 1;
                }
                while (m >= 5)
                {
                    m = m - 5;
                    BilletCinq = BilletCinq + 1;
                }
                while (m >= 1)
                {
                    m = m - 1;
                    PieceUn = PieceUn + 1;
                }
            }
            if (m % 2 != 0)
            {
                m = m - 1;
                while (m >= 20)
                {
                    m = m - 20;
                    BilletVingt = BilletVingt + 1;
                }
                while (m >= 10)
                {
                    m = m - 10;
                    BilletDix = BilletDix + 1;
                }
                while (m >= 5)
                {
                    m = m - 5;
                    BilletCinq = BilletCinq + 1;
                }
                while (m >= 1)
                {
                    m = m - 1;
                    PieceUn = PieceUn + 1;
                }
                PieceUn = PieceUn + 1;
            }
            Console.WriteLine("Voici:");

            if (BilletVingt > 0)                                          // Rendu Billets de 20 ou non
            {
                Console.WriteLine(BilletVingt + " billets de vingt euros.");
            }
            else if (BilletVingt == 1)
            {
                Console.WriteLine(BilletVingt + " billet de vingt euros.");
            }
            if (BilletDix > 0)                                    // Rendu Billets de 10 ou non
            {
                Console.WriteLine(BilletDix + " billets de dix euros.");
            }
            else if (BilletDix == 1)
            {
                Console.WriteLine(BilletDix + " billet de dix euros.");
            }
            if (BilletCinq > 0)                                  // Rendu Billets de 5 ou non
            {
                Console.WriteLine(BilletCinq + " billets de cinq euros.");
            }
            else if (BilletCinq == 1)
            {
                Console.WriteLine(BilletCinq + " billet de cinq euros.");
            }
            if (PieceUn > 0)                                     // Rendu pièces de 1 ou non
            {
                Console.WriteLine(PieceUn + " pieces de un euro.");
            }
            else if (PieceUn == 1)
            {
                Console.WriteLine(PieceUn + " piece de un euro.");
            }
            return m;
        }
        /// <summary>
        /// Si l'utilisateur a choisi un grand nombre, il va lui être proposé de recevoir des grosses ou des petites coupures
        /// </summary>
        /// <param name="m"></param> m étant le montant que l'utilisateur désire retirer
        /// <returns></returns>
        static int GrandNombre(int m)
        {
            Console.WriteLine("TYPE DE BILLETS");
            Console.WriteLine("1- Majorité de 20, 10, 5   2- Majorité de 200, 100, 50");
            int majorite = Convert.ToInt32(Console.ReadLine());
            if (majorite != 1 && majorite != 2)
            {
                while (majorite != 1 && majorite != 2)
                {
                    Console.WriteLine("Cette option n'existe pas, veuillez choisir une option valide: ");
                    majorite = Convert.ToInt32(Console.ReadLine());
                }
            }
            if (majorite == 1)
            {
                MajoritePetit(m);
            }
            else if (majorite == 2)
            {
                MajoriteGrand(m);
            }
            return m;
        }
        /// <summary>
        /// Saisi le choix de l'utilisateur et lance le programme adapté
        /// </summary>
        /// <param name="n"></param> choix de l'utilisateur
        static void Choix(int n)
        {
            int m = 1;
            if (n == 8)
            {
                m = AutreMontant(m);
            }
            if (n == 7)
            {
                m = 100;
            }
            else if (n == 6)
            {
                m = 80;
            }
            else if (n == 5)
            {
                m = 50;
            }
            else if (n == 4)
            {
                m = 40;
            }
            else if (n == 3)
            {
                m = 30;
            }
            else if (n == 2)
            {
                m = 20;
            }
            else if (n == 1)
            {
                m = 10;
            }
            Console.WriteLine("Vous avez choisi le montant " + m + " euros");
            if (m >= 50)
            {
                GrandNombre(m);
            }
            else if (m < 50)
            {
                PetitNombre(m);
            }
        }
        /// <summary>
        /// Distributeur de billets
        /// </summary>
        static void Innovation()
        {
            int n = Presentation();
            Choix(n);
        }
        #endregion Innovation
        /// <summary>
        /// Effectuer la fonction choisi par l'utilisateur en fonction de son choix
        /// </summary>
        /// <param name="n"></param> n étant le choix saisi par l'utilisateur
        static void ChoixEx(int n)
        {
            Console.WriteLine(" ");
            if (n == 9)                                              //Si l'option est QUITTER, quitte le programme
            {
                Console.WriteLine("Merci, à bientôt! ");
            }
            else if (n == 1)
            {
                SommePuissance();
            }
            else if (n == 2)
            {
                SommeDiviseur();
            }
            else if (n == 3)
            {
                DecouverteAnnee();
            }
            else if (n == 4)
            {
                ConversionOctDec();
            }
            else if (n == 5)
            {
                ConversionDecOct();
            }
            else if (n == 6)
            {
                TrianglePascal();
            }
            else if (n == 7)
            {
                ChiffrementDechiffrement();
            }
            else if (n == 8)
            {
                Innovation();
            }

        }
        /// <summary>
        /// Affiche le sommaire de l'application innovante et demande à l'utilisateur de faire un choix
        /// </summary>
        static void Sommaire()
        {
            Console.WriteLine("Bienvenue");
            Console.WriteLine("           ");
            Console.WriteLine("Application numérique 2019");
            Console.WriteLine("           ");
            Console.WriteLine("Nous vous proposons de réaliser:");
            Console.WriteLine("           ");
            Console.WriteLine("1. Somme des chiffres d'une puissance");
            Console.WriteLine("2. Somme des diviseurs");
            Console.WriteLine("3. Découverte d'une année");
            Console.WriteLine("4. Conversion octal en décimal");
            Console.WriteLine("5. Conversion décimal en octal");
            Console.WriteLine("6. Triangle de Pascal");
            Console.WriteLine("7. Chiffrement/Déchiffrement d'un mot");
            Console.WriteLine("8. Innovation");
            Console.WriteLine("9. Quitter !!");
            Console.WriteLine("       ");
            Console.WriteLine("Veuillez saisir votre choix : ");
            int n = Convert.ToInt32(Console.ReadLine());           //Demander son choix à l'utiliiftateur
            if (n < 1 || n > 9)
            {
                while (n < 1 || n > 9)
                {
                    Console.WriteLine("Cette option n'existe pas, veuillez saisir une option proposée");
                    n = Convert.ToInt32(Console.ReadLine());
                }
            }
            ChoixEx(n);
        }
        static void Main(string[] args)
        {

            Sommaire();                         //Affiche le menu
            Console.ReadKey();
        }
    }
}
