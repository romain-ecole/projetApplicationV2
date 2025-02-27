using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IohnerWinterTPChapitre4
{
    public partial class FenChp4 : Form
    {
        //Déclaration des variables qu'on utilise dans les onglets
        //variables exo31
        Int16 cpteur1 = 0;
        Int16 nbnotes1 = 0;
        Double cumul1 = 0;
        //variables exo34
        Int16 cpteur2 = 0;
        Double cumul2 = 0;
        Double emplSal = 0;
        Double emplSalH = 0;
        Double emplNbH = 0;
        Double tauxRet = 0;
        Double emplPrime = 0;
        //variables exo38
        Int16 cpteur3 = 0;
        Double accConso = 0;
        Double relv1 = 0;
        Double relv2 = 0;
        Double accTranche1 = 0;
        Double accTranche2 = 0;
        Int16 aboTranche1 = 0;
        Int16 aboTranche2 = 0;
        //variables exo41
        Int16 resultat5 = 0;
        //variables exo42
        Int32 cpteur4 = 1;
        Int16 nbMots = 0;
        Int16 i6 = 0;
        Int16 nbPhrases = 0;
        string textecorrige6 = "";
        //variable exo44
        Int16 i7 = 0;
        Int16 j7 = 0;
        //variable exo51
        int amende = 0;
        string retrait = "";
        public FenChp4()
        {
            InitializeComponent();
        }

        private void BFermer2_Click(object sender, EventArgs e)
        {
            //Lors du click sur le bouton fermer de l'onglet exo34 la fenêtre complète se ferme
            Close();
        }

        //Exo31

        public void tabExo31_Load(object sender, EventArgs e)
        {
            TxtNote1.Focus();
        }

        private void TxtSaisi1_Leave(object sender, System.EventArgs e)
        {
            //Si le nombre de notes saisi est différent du nombre total de notes à saisir
            if (cpteur1 != nbnotes1)
            {
                //Le compteur du nombre de notes saisies est incrémenté
                cpteur1++;
                //On ajoute la nouvelle note à la somme
                cumul1 = Convert.ToDouble(TxtSaisi1.Text) + cumul1;
                //Réinitialisation de la zone de saisi des notes et on lui redonne le focus
                TxtSaisi1.Text = "";
                TxtSaisi1.Focus();
                if(cpteur1!=nbnotes1)
                {
                    //On change le label pour afficher que c'est la n-ième note qu'il faut saisir
                    LabSaisi1.Text = "Saisir la" + Convert.ToString(cpteur1 + 1) + "ème note:";
                    //On affiche le nombre de note qu'il reste à saisir à la place du nombre de note total
                    LabNote1.Text = "Notes restantes à saisir: ";
                    TxtNote1.Text = Convert.ToString(nbnotes1 - cpteur1);

                }
                else
                {
                    //Si l'utilisateur a saisi toutes les notes à saisir on calcul la moyenne et on rend la zone de texte visible
                    TxtMoy1.Text = Convert.ToString(cumul1 / nbnotes1);
                    TxtMoy1.Visible = true;
                    TxtNote1.Text = "0";
                    LabSaisi1.Text = "Notes saisies";
                    BReinit1.Focus();
                }

            }
            
        }

        private void TxtNote1_Leave(object sender, System.EventArgs e)
        {
            //On récupère le nombre de notes à saisir avec une condition pour éviter un plantage si on quitte la zone de saisie sans saisir
            if (TxtNote1.Text != "")
            {
                nbnotes1 = Convert.ToInt16(TxtNote1.Text);
                TxtSaisi1.Focus();
            }
        }

        private void BReinit1_Click(object sender, EventArgs e)
        {
            //réinitialisation des zones de textes, des labels et on redonne le focus à la zone de saisie du nombre de note
            cumul1 = 0;
            cpteur1 = 0;
            TxtNote1.Text = "";
            TxtSaisi1.Text = "";
            LabNote1.Text = "Nombre de notes: ";
            LabSaisi1.Text = "Saisir la première note: ";
            TxtNote1.Focus();
            TxtMoy1.Visible = false;
        }


        //Exo34
        private void tabExo34_Load(object sender, EventArgs e)
        {
            TxtRlv13.Focus();
        }

        private void TxtTauxRet2_Leave(object sender, EventArgs e)
        {
            //On vérifie si les 3 premières case sont remplies pour permettre d'écrire dans les autres
            if (TxtTauxRet2.Text != "" && TxtNbEmp2.Text != "" && TxtSalH2.Text != "")
            {
                TxtNom2.ReadOnly = false;
                TxtPrime2.ReadOnly = false;
                TxtNbHT2.ReadOnly = false;
            }
        }

        private void TxtNbHT2_Leave(object sender, EventArgs e)
        {
            //On vérifie si les informations de l'employé sont bien toutes remplies
            if (TxtNom2.Text != "" && TxtPrime2.Text != "" && TxtNbHT2.Text != "" && (CombCivil2.Text == "Madame" || CombCivil2.Text == "Monsieur" || CombCivil2.Text == "Mademoiselle"))
            {
                int nbEmpl = int.Parse(TxtNbEmp2.Text);
                //Si Le compteur est différent du nombre d'employé faire :
                if (cpteur2 <= nbEmpl)
                //On incrémente le compteur  
                //On affiche "Saisir les informations de l'employé 'cpteur2'" dans LabEmp2                
                //On calcul le salaire
                {

                    LabEmp2.Text = "Saisir les informations de l'employé" + cpteur2.ToString();
                    emplSalH = Double.Parse(TxtSalH2.Text);
                    emplNbH = Double.Parse(TxtNbHT2.Text);
                    tauxRet = Double.Parse(TxtTauxRet2.Text);
                    emplPrime = Double.Parse(TxtPrime2.Text);


                    emplSal = (emplSalH * emplNbH + emplPrime) / tauxRet;
                    cumul2 += emplSal;
                    cpteur2++;

                }


                //On ajoute le salaire au cumul
                //On affiche la phrase "'CombCivil2' 'TxtNom2' doit percevoir un salaire de 'salaire'" dans LabPhrase2
                //On vide toutes les cases d'informations de l'employé
                //Else
                //Calcul la moyenne des salaires: cumul2/NbEmp
                //Affichage de la moyenne dans LabMoyen2 (qu'il faut rendre visible)
                //Fin Si 

                //<bidon>
                LabPhrase2.Text = CombCivil2.Text + " " + TxtNom2.Text + " Doit percevoir un salaire de" + emplSal.ToString();
                LabMoyen2.Text = "La moyenne des salaires est de " + cumul2 / Double.Parse(TxtNbEmp2.Text);
                //</bidon>
                LabMoyen2.Visible = true;
                BReinit2.Focus();
                TxtNom2.Text = "";
                TxtPrime2.Text = "";
                TxtNbHT2.Text = "";
            }
        }

        private void BReinit2_Click(object sender, EventArgs e)
        {
            //réinitialisation des variables, zones de textes, des labels, de la liste déroulante et on redonne le focus à la zone de saisie du nombre d'employées
            cpteur2 = 0;
            cumul2 = 0;
            TxtNbEmp2.Text = "";
            TxtSalH2.Text = "";
            TxtTauxRet2.Text = "";
            TxtNom2.Text = "";
            TxtPrime2.Text = "";
            TxtNbHT2.Text = "";
            LabMoyen2.Text = "";
            LabPhrase2.Text = "Monsieur [...] doit percevoir un salaire de";
            CombCivil2.Text = "Civilité";
            LabEmp2.Text = "Saisie des employés";
            TxtNom2.ReadOnly = true;
            TxtPrime2.ReadOnly = true;
            TxtNbHT2.ReadOnly = true;
            TxtNbEmp2.Focus();
        }

        //Exo38
        private void tabExo38_Load(object sender, EventArgs e)
        {
            TxtRlv23.Focus();
        }

        private void TxtRlv13_Leave(object sender, EventArgs e)
        {
            if (TxtRlv13.Text != "" & TxtRlv23.Text != "")
            {
                cpteur3++;
                relv1 = Convert.ToDouble(TxtRlv13.Text);
                TxtRlv13.Text = "";
                relv2 = Convert.ToDouble(TxtRlv23.Text);
                TxtRlv23.Text = "";
                //ici test du relevé pour déterminer la tranche de l'abonné
                //en fonction de la tranche ajouter 1 au compteur de la tranche et ajouter la consommation à
                //l'accumulateur global et à l'accumulateur de la tranche
                accConso += relv1 - relv2;
                if (relv1 - relv2 < 100)
                {
                    aboTranche1++;
                    accTranche2 += relv1 - relv2;
                }
                else
                {
                    aboTranche2++;
                    accTranche1 += relv1 - relv2;
                }
                if (cpteur3 != 5)
                {
                    LabIndex3.Text = "Abonné n°" + (cpteur3 + 1);
                }
                else
                {
                    TxtRlv13.ReadOnly = true;
                    TxtRlv23.ReadOnly = true;
                    LabIndex3.Text = "Tout les abonnés ont été saisis";
                    //ici afficher les résultat dans les 4 boites réservés aux tranches et la moyenne globale
                    //<bidon>
                    TxtNbP13.Text = Convert.ToString(aboTranche1);
                    TxtNbP23.Text = Convert.ToString(aboTranche2);
                    TxtMoy23.Text = Convert.ToString(accTranche1 / aboTranche1);
                    TxtMoy13.Text = Convert.ToString(accTranche2 / aboTranche2);
                    LabMoy3.Text = "La consommation totale s'élève a : " + accConso;
                    //</bidon>
                    BReinit3.Focus();
                }

            }
            else
            {
                //On vérifie quelle textbox n'est pas remplie et lui donne le focus
                if (TxtRlv13.Text == "")
                {
                    TxtRlv13.Focus();
                }
                else
                {
                    TxtRlv23.Focus();
                }
            }
        }

        private void BReinit3_Click(object sender, EventArgs e)
        {
            //réinitialisation des variables, zones de textes, des labels et on redonne le focus à la zone de saisie du 1er relevé
            cpteur3 = 0;
            accConso = 0;
            relv1 = 0;
            relv2 = 0;
            accTranche1 = 0;
            accTranche2 = 0;
            aboTranche1 = 0;
            aboTranche2 = 0;
            LabIndex3.Text = "Abonné n°1";
            LabMoy3.Text = "La consommation totale s'élève a :";
            TxtNbP13.Text = "";
            TxtNbP23.Text = "";
            TxtMoy13.Text = "";
            TxtMoy23.Text = "";
            TxtRlv13.ReadOnly = false;
            TxtRlv23.ReadOnly = false;
            TxtNbEmp2.Focus();
        }

        //Exo40 v3
        private void BCrypt4_Click_1(object sender, EventArgs e)
        {
            // Récupérer le texte de la TextBox4
            string texte = TxtBox4.Text;

            // Diviser le texte en phrases en utilisant le point comme délimiteur
            string[] phrases = texte.Split('.');

            // Inverser l'ordre des phrases
            Array.Reverse(phrases);

            // Crypter chaque phrase
            StringBuilder texteCrypte = new StringBuilder();
            foreach (string phrase in phrases)
            {
                // Ignorer les phrases vides
                if (!string.IsNullOrWhiteSpace(phrase))
                {
                    // Crypter la phrase
                    string phraseCryptee = CrypterPhrase(phrase.Trim());
                    texteCrypte.Append(phraseCryptee);
                    texteCrypte.Append("."); // Ajouter un point après chaque phrase cryptée
                }
            }

            // Afficher le texte crypté dans la textbox4
            TxtBox4.Text = texteCrypte.ToString();
        }

        // Fonction pour crypter une phrase
        // Fonction pour crypter une phrase
        private string CrypterPhrase(string phrase)
        {
            StringBuilder phraseCryptee = new StringBuilder();

            // Inverser la phrase
            char[] chars = phrase.ToCharArray();
            Array.Reverse(chars);
            string phraseInverse = new string(chars);

            // Parcourir la phrase inversée et crypter chaque caractère
            foreach (char c in phraseInverse)
            {
                // Si le caractère est une lettre, trouver sa position symétrique dans l'alphabet
                if (char.IsLetter(c))
                {
                    char caractereCrypte = (char)(2 * 'a' + 25 - char.ToLower(c)); // 2 * 'a' car 'a' est à la position 0
                    phraseCryptee.Append(caractereCrypte);
                    phraseCryptee.Append(c); // Intercaler la lettre d'origine
                }
                else
                {
                    // Si le caractère n'est pas une lettre, le conserver tel quel
                    phraseCryptee.Append(c);
                }
            }

            return phraseCryptee.ToString();
        }

        private void BReinit4_Click(object sender, EventArgs e)
        {
            //réinitialisation du contenu la textbox, de sa propriété readonly et du focus
            TxtBox4.Text = "";
            TxtBox4.ReadOnly = false;
            TxtBox4.Focus();
        }

        //Exo41
        private void BLancer5_Click(object sender, EventArgs e)
        {
            //on demande un random entre 0 et 1
            var random = new Random();
            int resultat5 = Convert.ToUInt16(random.Next(2) == 1);
            //si une pile ou face est selectionné
            if (RBPile5.Checked==true || RBFace5.Checked==true)
            {
                LabSelect5.Text = "";
                if (resultat5 == 0)
                {
                    //On affiche face car le resultat est 0
                    LabLancer5.Text = "Face";
                    if (RBFace5.Checked == true)
                    {
                        //si il selectionne face et que c'est face
                        TxtGagnant5.Text = Convert.ToString(Convert.ToUInt16(TxtGagnant5.Text) + 1);
                    }
                    else
                    {
                        //si il selectionne face et que c'est pile
                        TxtPerdant5.Text = Convert.ToString(Convert.ToUInt16(TxtPerdant5.Text) + 1);

                    }
                }
                else
                {
                    //On affiche pile car le resultat est 1
                    LabLancer5.Text = "Pile";
                    if (RBPile5.Checked == true)
                    {
                        //si il selectionne pile et que c'est pile
                        TxtGagnant5.Text = Convert.ToString(Convert.ToUInt16(TxtGagnant5.Text) + 1);
                    }
                    else
                    {
                        //si il selectionne pile et que c'est face
                        TxtPerdant5.Text = Convert.ToString(Convert.ToUInt16(TxtPerdant5.Text) + 1);

                    }
                }
            }
            else 
            {
                LabSelect5.Text = "Selectionner pile ou face";
            }
            
        }

        private void BReinit5_Click(object sender, EventArgs e)
        {
            //On remet les compteurs à 0 et on enlève les textes qui pourraient être afichés
            TxtGagnant5.Text = "0";
            TxtPerdant5.Text = "0";
            LabLancer5.Text = "";
            LabSelect5.Text = "";
        }

        //Exo42
        private void TxtBox6_Leave(object sender, EventArgs e)
        {
            //boucle de correction du texte (enlever les espaces en trop)
            i6 = 0;
            nbMots = 1;
            nbPhrases = 1;
            //initialisation du texte final
            textecorrige6 = "";
            while (i6 + 1 < TxtBox6.Text.Length)
            {
                if (Convert.ToString(TxtBox6.Text[i6]) == "." && Convert.ToString(TxtBox6.Text[i6 + 1]) == " ")
                {
                    //si il y a un point suivi d'un espace on ajoute un point au texte final
                    textecorrige6 += ".";
                    i6++;
                    cpteur4--;
                }
                else if (Convert.ToString(TxtBox6.Text[i6]) == " " && Convert.ToString(TxtBox6.Text[i6 + 1]) == " ")
                {
                    //si il y a une double espace on n'ajoute rien au texte final
                    i6++;
                    nbMots--;
                    cpteur4--;
                }
                else
                {
                    //sinon on ajoute le caractère initial au texte final
                    textecorrige6 += TxtBox6.Text[i6];
                    i6++;
                }
            }
            int nbCaracteres = TxtBox6.TextLength - cpteur4;

            for (int i = 1; i < TxtBox6.TextLength; i++)
            {
                // Si le caractère actuel est un espace, incrémentez le compteur de mots
                if (TxtBox6.Text[i] == ' ')
                {
                    nbMots++;
                }
            }
            char[] separateurs = { '.', '!', '?' };
            foreach (char caractere in TxtBox6.Text)
            {
                if (separateurs.Contains(caractere))
                {
                    nbPhrases++;
                }
            }
            nbCaracteres++;

            textecorrige6 += TxtBox6.Text[i6];
            TxtBox6.Text = Convert.ToString(textecorrige6);
            //procédure de comptage de caractères, mots et phrases à placer ici
            //<bidon>
            TxtCar6.Text = nbCaracteres.ToString();
            TxtMot6.Text = nbMots.ToString();
            TxtPhrase6.Text = nbPhrases.ToString();
            //</bidon>
            BReinit6.Focus();
        }

        private void BReinit6_Click(object sender, EventArgs e)
        {
            //On vide toutes les zones de texte
            TxtCar6.Text = "";
            TxtMot6.Text = "";
            TxtPhrase6.Text = "";
            TxtBox6.Text = "";
        }

        //Exo44
         private void BAfficher7_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                dataGridView1.Columns.Add("col" + i, i.ToString());
            }

            // Ajout des lignes au DataGridView
            for (int i = 1; i <= 10; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();
            }

            // Remplissage des cellules avec les résultats des multiplications
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    dataGridView1.Rows[i - 1].Cells[j - 1].Value = (i * j).ToString();
                }
            }
        }
        private void BReinit7_Click(object sender, EventArgs e)
        {
            //vider le tableau
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        //Exo51

        private void BCalculer8_Click(object sender, EventArgs e)
        {
            int quantite = Convert.ToInt32(TxtQte8.Text);
            int degre = Convert.ToInt32(TxtDeg8.Text);
            //traitement du calcul de l'amende et du retrait
            if (quantite > 0 && degre > 0)
            {
                amende = quantite * degre * 10; // Exemple de calcul simple
                retrait = $"{quantite * degre / 10} mois"; // Exemple de calcul simple
            }
            TxtRetrait8.Text = retrait;
            TxtAm8.Text = amende.ToString() + " euros";
        }
        private void BReinit8_Click(object sender, EventArgs e)
        {
            //On vide toutes les cases
            TxtQte8.Text = "";
            TxtDeg8.Text = "";
            TxtAm8.Text = "";
            TxtRetrait8.Text = "";
        }
    }
}

