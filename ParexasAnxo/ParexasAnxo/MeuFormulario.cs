using ParexasAnxo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParexasAnxo
{
    public partial class MeuFormulario : Form
    {
        int tamanoColFil = 4,contMovementos=0,contCartasXiradas=0;

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            iniciarXogo();
        }

        public MeuFormulario()
        {
            InitializeComponent();
            iniciarXogo();
        }

        public void iniciarXogo()
        {
            tTempo.Enabled = false;
            tTempo.Stop();
            Partida partida = new Partida(4, 0, 0);//tamañoTableiro,movementos,CartasXiradas
            List<CartaLib.ucImaxe> listaUC = new List<CartaLib.ucImaxe>();

            //Rellenar array con cartas
            for (int i = 1; i <= tamanoColFil*tamanoColFil; i++)
            {
                partida.cartasEnumeradas.Add(new Carta(i, "reverso", "Resources.imagen"+i));
                partida.cartasEnumeradas.Add(new Carta(i, "reverso", "Resources.imagen"+i));
                listaUC.Add(new CartaLib.ucImaxe());
                listaUC.Add(new CartaLib.ucImaxe());
            }

            //Creo el panelde xogo
            var tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = tamanoColFil;
            tablaPanel.ColumnCount = tamanoColFil;
            //ajustamos el contenido al panel
            for (int i = 0; i < tamanoColFil; i++)
            {
                var Porcentaje = 150f / (float)tamanoColFil - 10;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }

            int contadorFichas = 0;

            for (var i = 0; i < tamanoColFil; i++)
            {
                for (var j = 0; j < tamanoColFil; j++)
                {
                    System.Drawing.Image imaxe = ParexasAnxo.Properties.Resources.reverso;
                    //System.Drawing.Image imaxe = Image.FromFile(partida.cartasEnumeradas[i].rutaImagenReverso);

                    // Creo ResourceManager.
                    System.Resources.ResourceManager myManager = new
                       System.Resources.ResourceManager("ParexasAnxo.Properties.Resources", this.GetType().Assembly);


                    // Retrieves String and Image resources.
                    System.Drawing.Image myImage;
                    myImage = (System.Drawing.Image)myManager.GetObject(partida.cartasEnumeradas[contadorFichas].rutaImagenReverso);

                    listaUC[contadorFichas].setImaxe(myImage);
                    tablaPanel.Controls.Add(listaUC[contadorFichas]);

                    contadorFichas++;
                }
            }
           
            tablaPanel.Dock = DockStyle.Fill;
            PanelXogo.Controls.Add(tablaPanel);
        }
    }
}
