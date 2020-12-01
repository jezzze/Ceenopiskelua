using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Threading;

namespace snakes_and_ladders_WPF_peli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle laskeutumisRec;
        Rectangle pelaaja;
        Rectangle vastustaja;

         List<Rectangle> liikkeet = new List<Rectangle>(); 

        DispatcherTimer peliAika = new DispatcherTimer();

        ImageBrush pelaajaKuva = new ImageBrush();
        ImageBrush vastustajaKuva = new ImageBrush();
        // int i ja int jtä käytetään pelaajana ja vastustajana
        //ne auttavat siinä että misä pelaaja ja vastustaja on ssss
        int i = -1;
        int j = -1;
        //paikka ja nykyinen paikka pelaajalle
        int paikka;
        int nykyinenPaikka;

        //vastustajan paikka ja nykyinen paikka
        int vastustajanPaikka;
        int vastustajanNykyinenPaikka;

        //tämä näyttää meille kuvat kun teen ne
        int kuvat = -1;
        //tämä laskee nopan pyöräytykset pelissä
        Random laita = new Random();
        //tämä kertoo kenen vuoro on
        bool pelaajaYksiVuoro, pelaajaKaksiVuoro;
        //tämä näyttää pelaajan ja vastustajan paikat
        int tempPos;

        public MainWindow()
        {
            InitializeComponent();
            SetupGame(); //tämä käynnistää setup gamen
        }
        private void OnClickEventti(object sender, MouseButtonEventArgs e)
        {
            //tämä antaa mahdollisuuden pelaajalle että voi painaa mistä vaan aloittaajseen pelin
            if (pelaajaYksiVuoro == false && pelaajaKaksiVuoro == false)
            {
                paikka = laita.Next(1, 7);
                txtPelaaja.Content = "sinä pyöräytit  " + paikka;
                nykyinenPaikka = 0;

                if ((i + paikka) <= 99)
                {
                    pelaajaYksiVuoro = true;//muuttaa pelaajayksivuoron true
                    peliAika.Start();//aloittaa peli ajan
                }
                else
                {
                    //jos ylempi if on false silloin tapahtuu tämä
                    if (pelaajaKaksiVuoro == false)
                    {
                        pelaajaKaksiVuoro = true;//jos on false muuttuu trueksi
                        vastustajanPaikka = laita.Next(1, 7);//tekee random numeron vastustajalle
                        txtVastustaja.Content = "vastustaja pyöräytti " + vastustajanPaikka;//näyttää random numeron 
                        vastustajanNykyinenPaikka = 0;//laittaa vastustajan nykyisen paikan 0
                        peliAika.Start();
                    }
                    else
                    {
                        peliAika.Stop();//pysäyttää peli ajan
                        pelaajaYksiVuoro = false;
                        pelaajaYksiVuoro = false;
                    }
                }
            }




        }
        private void SetupGame()
        {
            int vasenPos = 10;
            int topPos = 600;
            int a = 0;
            //nämä kaksi riviä  ovat tärkeitä koska siinä on pelaajan ja vastustajan kuvat
            pelaajaKuva.ImageSource = new BitmapImage(new Uri("F:/visual studion repot/snakes-and-ladders-game-images-mooict/player.gif"));
            vastustajaKuva.ImageSource = new BitmapImage(new Uri("F:/visual studion repot/snakes-and-ladders-game-images-mooict/opponent.gif"));


            //tämä on pää looppi
            for (int i = 0; i < 100; i++)
            {
                kuvat++;
                ImageBrush paaKuvat = new ImageBrush();
                //pässä otan kaikki kuvat
                paaKuvat.ImageSource = new BitmapImage(new Uri("F:/visual studion repot/snakes-and-ladders-game-images-mooict/" + kuvat + ".jpg"));

                //tässä teen rectanglen nimeltä boxi
                Rectangle boxi = new Rectangle
                {
                    Height = 60,
                    Width = 60,
                    Fill = paaKuvat,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };
                boxi.Name = "boxi" + i.ToString();//boxien nimeys
                this.RegisterName(boxi.Name, boxi);//registeröi nimi wpf appin sisään
                liikkeet.Add(boxi);//lisää liikkeitä boxiin
                //if on sama kuin 10
                if (a == 10)
                {
                    topPos -= 60;
                    a = 30;
                }
                //if on sama kuin 20
                if (a == 20)
                {
                    topPos -= 60;
                    a = 0;
                }
                //if on suurempi kuin 20
                if (a > 20)
                {
                    a--;
                    Canvas.SetLeft(boxi, vasenPos);
                    vasenPos -= 60;
                }
                //if on vähemmän kuin 10
                if (a < 10)
                {
                    a++;
                    Canvas.SetLeft(boxi, vasenPos);
                    vasenPos += 60;
                    Canvas.SetLeft(boxi, vasenPos);
                }
                Canvas.SetTop(boxi, topPos);
                MinunCanvas.Children.Add(boxi);
                //loopin loppu
            }
            peliAika.Tick += peliAikaEventti;
            peliAika.Interval = TimeSpan.FromSeconds(.2);
            pelaaja = new Rectangle
            {
                Height = 30,
                Width = 30,
                Fill = pelaajaKuva,
                StrokeThickness = 2
            };
            vastustaja = new Rectangle
            {
                Height = 30,
                Width = 30,
                Fill = vastustajaKuva,
                StrokeThickness = 2
            };
            MinunCanvas.Children.Add(pelaaja);
            MinunCanvas.Children.Add(vastustaja);

            MovePiece(pelaaja, "boxi" + 0);
            MovePiece(vastustaja, "boxi" + 0);
        
        }
        private void peliAikaEventti(object sender, EventArgs e)
        {
            //tämä on pelin aika eventti tämä liikuttaa pelaajaa ja vastustajaa 
            if (pelaajaYksiVuoro == true && pelaajaKaksiVuoro == false)
            {
                //jos tämä on true teemme seuraavan 
                //tarkista että onko i vähemmän mitä nappuloita pelissä on
                if (i < liikkeet.Count)
                {
                    //jos kyllä tarkistetaan onko nykyinen paikka vähemmän kuin paikka mikä tehtiin randomina
                    if (nykyinenPaikka < paikka)
                    {
                        //jos niin tarkoitta että lisätään yksi paikka nykyiseen paikkaan 
                        nykyinenPaikka++;
                        i++;
                        MovePiece(pelaaja, "boxi" + i);
                    }
                    else
                    {
                        //jos pelaaja ykkösen vuoro on false teemme seuraavan
                        pelaajaKaksiVuoro = true;
                        i = tarkistaSnakesOrLadders(i);
                        MovePiece(pelaaja, "boxi" + i);

                        vastustajanPaikka = laita.Next(1, 7);
                        txtVastustaja.Content = "vastustaja pyöräytti " + vastustajanPaikka;
                        vastustajanNykyinenPaikka = 0;
                        tempPos = i;
                        txtPelaajanPaikka.Content = "pelaaja on  " + (tempPos + 1);
                    }
                }

                if (i == 99)
                {
                    peliAika.Stop();
                    MessageBox.Show("Hävisit Pelin!, Sinä Voitit!" + Environment.NewLine + "Paina ok pelataksesi uudestaan", "Jesse sanoo");
                    RestartGame();
                }
            }
            if (pelaajaKaksiVuoro == true)
            {

                if (j < liikkeet.Count)
                {
                    if (vastustajanNykyinenPaikka < vastustajanPaikka && (j + vastustajanPaikka < 101))
                    {
                        vastustajanNykyinenPaikka++;
                        j++;
                        MovePiece(vastustaja, "boxi" + j);
                    }
                    else
                    {//muuttaa pelaaja yksi ja kaksi vuorot falseksi
                        pelaajaYksiVuoro = false;
                        pelaajaKaksiVuoro = false;

                        j = tarkistaSnakesOrLadders(j);
                        MovePiece(vastustaja, "boxi" + j);
                        tempPos = j;
                        txtVastustajanPaikka.Content = "Vastustaja on  " + (tempPos + 1);
                        peliAika.Stop();
                    }//else loppu
                }//if loppu
                if (j == 99)
                {
                    peliAika.Stop();
                    MessageBox.Show("Hävisit Pelin!, Vastustaja Voitti!" + Environment.NewLine + "Paina ok pelataksesi uudestaan", "Jesse sanoo");
                    RestartGame();
                }

            }//if loppu
        }
        private void RestartGame()
        {
            //tämä aloittaa koko pelin uudestaan
            i = -1;
            j = -1;
            MovePiece(pelaaja, "boxi" + 0);
            MovePiece(vastustaja, "boxi" + 0);
            //laittaa pelaajan paikan 0
            paikka = 0;
            nykyinenPaikka = 0;

            //laittaa vastustajan paikan 0
            vastustajanPaikka = 0;
            vastustajanNykyinenPaikka = 0;

            //laittaa pelaajan yksi ja kasi vuorot falseen 
            pelaajaYksiVuoro = false;
            pelaajaKaksiVuoro = false;
            //laittaa pelaajan ja vastustajan labelit takasin paikoilleen
            txtPelaaja.Content = "Sinä Pyöräytit  " + paikka;
            txtPelaajanPaikka.Content = "Pelaaja on  1";

            txtVastustaja.Content = "vastustaja Pyöräytti " + vastustajanPaikka;
            txtVastustajanPaikka.Content = "Vastustaja on  1";
            //pysäyttää peliajan
            peliAika.Stop();

        }//restart game loppu

        private int tarkistaSnakesOrLadders(int num)
        {
            //tämä tarkistaa snakesorladders funktion ja tarkistaa onko pelaaja laskeutunut käärmeen päälle tai tikapuiden pääle
            if (num == 1)
            {
                num = 37;
            }

            if (num == 6)
            {
                num = 13;
            }

            if (num == 7)
            {
                num = 30;
            }

            if (num == 14)
            {
                num = 25;
            }

            if (num == 15)
            {
                num = 5;
            }
            if (num == 20)
            {
                num = 41;
            }
            if (num == 27)
            {
                num = 83;
            }
            if (num == 35)
            {
                num = 43;
            }
            if (num == 45)
            {
                num = 24;
            }
            if (num == 48)
            {
                num = 10;
            }
            if (num == 50)
            {
                num = 66;
            }
            if (num == 61)
            {
                num = 18;
            }
            if (num == 63)
            {
                num = 59;
            }
            if (num == 70)
            {
                num = 90;
            }
            if (num == 73)
            {
                num = 52;
            }
            if (num == 77)
            {
                num = 97;
            }
            if (num == 86)
            {
                num = 93;
            }
            if (num == 88)
            {
                num = 67;
            }
            if (num == 91)
            {
                num = 87;
            }
            if (num == 94)
            {
                num = 74;
            }
            if (num == 98)
            {
                num = 79;
            }



            return num;
        }
        private void MovePiece(Rectangle pelaaja, string posName)
        {
            //tämä funktio liikuttaa pelaajaa ympäriinsä
            foreach (Rectangle rectangle in liikkeet)
            {
                if (rectangle.Name == posName)
                {
                    laskeutumisRec = rectangle;
                }
            }
            Canvas.SetLeft(pelaaja, Canvas.GetLeft(laskeutumisRec) + pelaaja.Width / 2);
            Canvas.SetTop(pelaaja, Canvas.GetTop(laskeutumisRec) + pelaaja.Height / 2);
        }

    }
}
