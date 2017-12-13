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
using System.Drawing;

namespace eLiq
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void miscela(object sender, RoutedEventArgs e)
        {   
            var converter = new GridLengthConverter();
            float pgBase = float.Parse(lbPgBase.Text);                                                       //PG DELLA BASE
            float vgBase = float.Parse(lbVgBase.Text);                                                       //VG DELLA BASE
            float nicotinaBase = float.Parse(tbConcNic.Text);                                                //VG DELLA BASE
            float pgDaOttenere = float.Parse(lbPgDaOttenere.Text);                                           //PG FINALE DESIDERATO
            float vgDaOttenere = float.Parse(lbVgDaOttenere.Text);                                           //VG FINALE DESIDERATO
            float nicotinaDaOttenere = float.Parse(tbNicDaOttenere.Text);                                    //NICOTINA FINALE DESIDERATA
            float volLiquidoFinale = float.Parse(btVolDaott.Text);                                           //VOLUME FINALE LIQUIDO
            float percentualeFlav1 = float.Parse(tbFlavPerc1.Text);                                          //% AROMA1
            float percentualeFlav2 = float.Parse(tbFlavPerc2.Text);                                          //% AROMA2
            float percentualeFlav3 = float.Parse(tbFlavPerc3.Text);
            float percentualeFlav4 = float.Parse(tbFlavPerc4.Text);
            float percentualeFlav5 = float.Parse(tbFlavPerc5.Text);
            float nicotinaDaPrelevareBase = (nicotinaDaOttenere / nicotinaBase) * volLiquidoFinale;
            float volFlaw1 = (percentualeFlav1 / 100) * volLiquidoFinale;
            float volFlaw2 = (percentualeFlav2 / 100) * volLiquidoFinale;
            float volFlaw3 = (percentualeFlav3 / 100) * volLiquidoFinale;
            float volFlaw4 = (percentualeFlav4 / 100) * volLiquidoFinale;
            float volFlaw5 = (percentualeFlav5 / 100) * volLiquidoFinale;
            float pgSol = (nicotinaDaPrelevareBase * pgBase) / 100;
            float vgSol = (nicotinaDaPrelevareBase * vgBase) / 100;
            float pg = (pgDaOttenere / 100) * volLiquidoFinale;
            float vg = (vgDaOttenere / 100) * volLiquidoFinale;
            float pgRicettaFinale = (pg - volFlaw1 - pgSol - volFlaw2 - volFlaw3 - volFlaw4 - volFlaw5);
            float vgRicettaFinale = (vg - vgSol);

            if (isVg.IsChecked == false)
            {
                lbPgRicettaFin.Content = Math.Round(pgRicettaFinale, 2);
                lbVgRicettaFin.Content = Math.Round(vgRicettaFinale, 2);
                lbNicRicettaFin.Content = Math.Round(nicotinaDaPrelevareBase, 2);
                lbFlav1RicettaFin.Content = Math.Round(volFlaw1, 2);
                lbFlav2RicettaFin.Content = Math.Round(volFlaw2, 2);
                lbFlav3RicettaFin.Content = Math.Round(volFlaw3, 2);
                lbFlav4RicettaFin.Content = Math.Round(volFlaw4, 2);
                lbFlav5RicettaFin.Content = Math.Round(volFlaw5, 2);
            }
            else
            {
                lbPgRicettaFin.Content = (Math.Round(pgRicettaFinale, 2)+ Math.Round(volFlaw1, 2));
                lbVgRicettaFin.Content = (Math.Round(vgRicettaFinale, 2)- Math.Round(volFlaw1, 2));
                lbNicRicettaFin.Content = Math.Round(nicotinaDaPrelevareBase, 2);
                lbFlav1RicettaFin.Content = Math.Round(volFlaw1, 2);
                lbFlav2RicettaFin.Content = Math.Round(volFlaw2, 2);
                lbFlav3RicettaFin.Content = Math.Round(volFlaw3, 2);
                lbFlav4RicettaFin.Content = Math.Round(volFlaw4, 2);
                lbFlav5RicettaFin.Content = Math.Round(volFlaw5, 2);
            }

            string pgbar = ((Math.Round(pgRicettaFinale, 2)*100)/volLiquidoFinale).ToString();
            string vgbar = ((Math.Round(vgRicettaFinale, 2) * 100)/volLiquidoFinale).ToString();
            string nicbar = ((Math.Round(nicotinaDaPrelevareBase, 2) * 100)/volLiquidoFinale).ToString();
            string flav1cbar = ((Math.Round(volFlaw1, 2) * 100)/volLiquidoFinale).ToString();
            string flav2cbar = ((Math.Round(volFlaw2, 2) * 100)/volLiquidoFinale).ToString();
           /* PG.Height = (GridLength)converter.ConvertFromString(pgbar +"*");
            VG.Height = (GridLength)converter.ConvertFromString(vgbar + "*");
            NIC.Height = (GridLength)converter.ConvertFromString(nicbar + "*");
            AR1.Height = (GridLength)converter.ConvertFromString(flav1cbar + "*");
            AR2.Height = (GridLength)converter.ConvertFromString(flav2cbar + "*");
            label1.Content = pgbar+" %";
            label2.Content = vgbar + " %";
            label3.Content = nicbar + " %";
            label4.Content = flav1cbar + " %";
            label5.Content = flav2cbar + " %";*/

        }

        private void info(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("eLiq Calculator by CryptoBojack \nFor further information please contact me at cryptobojack@gmail.com");
            info infowindows = new info();
            infowindows.Show();
            this.Close();

        }
    }
}
