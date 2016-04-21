using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerCaballos.Util;



namespace TallerCaballos
{
    public partial class Form1 : Form
    {

        enum Position
        {
            right
        }

        private int posx;
        private int posy;

        private int posx2;
        private int posy2;

        private int posx3;
        private int posy3;

        private int posx4;
        private int posy4;

        private int ancho;
        private int alto;

        private int ancho2;
        private int alto2;

        private int ancho3;
        private int alto3;

        private int ancho4;
        private int alto4;

        private int cambio;
        private int cambio2;
        private int cambio3;
        private int cambio4;


        Thread hilo;
        Thread hilo2;
        Thread hilo3;
        Thread hilo4;



        private Position posicion;
        private Position posicion2;
        private Position posicion3;
        private Position posicion4;

        Random maximoCaballo = new Random();
        int maximo = 40;

        Random rnd = new Random();
        Random rnd2 = new Random();
        Random rnd3 = new Random();
        Random rnd4 = new Random();

        Boolean InicioPausaCaballo1 = true;
        Boolean InicioPausaCaballo2 = true;
        Boolean InicioPausaCaballo3 = true;
        Boolean InicioPausaCaballo4 = true;

        //Bandera encargada de decir si la carrera esta en curso
        Boolean InicioCarrera = false;
        //Instancia de la clase apuesta
        Apuesta apuesta;
        //Caballo seleccionado para realizar la apuesta
        int caballoApuesta;
        //Valor de la apuesta seleccionado por el usuario
        Double valorApuesta;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            
            apuesta = new Apuesta();
            InitializeComponent();

            txtValorInicial.Enabled = false;
            cbxCaballos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbxCaballos.Text = "SELECCIONE";
            posx = 0;
            posy = 10;
            ancho = 50;
            alto = 50;


            posx2 = 0;
            posy2 = 70;
            ancho2 = 50;
            alto2 = 50;

            posx3 = 0;
            posy3 = 130;
            ancho3 = 50;
            alto3 = 50;


            posx4 = 0;
            posy4 = 190;
            ancho4 = 50;
            alto4 = 50;

            apuesta.totalApuesta.Add(apuesta.valorBase);

            valorApuesta = apuesta.valorBase;

            txtValorInicial.Text = valorApuesta + "";


        }



        public void repintar()
        {

            while (InicioPausaCaballo1)
            {
                cambio = rnd.Next(maximoCaballo.Next(maximo));
                if (posicion == Position.right)
                {
                    if (panel1.Width > posx + ancho)
                    {
                        posx = posx + cambio;
                    }
                    else
                    {
                        InicioPausaCaballo1 = false;
                        String caballo1 = "1";
                        DarFinalCarrera(caballo1);
                    }
                }

                //Repinta la interfaz 
                panel1.Invalidate();

                //Duerme el hilo
                Thread.Sleep(150);
            }


        }

        public void repintar2()
        {

            while (InicioPausaCaballo2)
            {
                cambio2 = rnd.Next(maximoCaballo.Next(maximo));
                if (posicion2 == Position.right)
                {
                    if (panel1.Width > posx2 + ancho2)
                    {
                        posx2 = posx2 + cambio2;
                    }
                    else
                    {
                        InicioPausaCaballo2 = false;
                        String caballo2 = "2";
                        DarFinalCarrera(caballo2);
                    }
                }

                //Repinta la interfaz 
                panel1.Invalidate();

                //Duerme el hilo
                Thread.Sleep(150);
            }


        }

        public void repintar3()
        {

            while (InicioPausaCaballo3)
            {
                cambio3 = rnd.Next(maximoCaballo.Next(maximo));
                if (posicion3 == Position.right)
                {
                    if (panel1.Width > posx3 + ancho3)
                    {
                        posx3 = posx3 + cambio3;
                    }
                    else
                    {
                        InicioPausaCaballo3 = false;
                        String caballo3 = "3";
                        DarFinalCarrera(caballo3);
                    }
                }

                //Repinta la interfaz 
                panel1.Invalidate();

                //Duerme el hilo
                Thread.Sleep(150);
            }


        }

        public void repintar4()
        {

            while (InicioPausaCaballo4)
            {
                cambio4 = rnd.Next(maximoCaballo.Next(maximo));
                if (posicion4 == Position.right)
                {
                    if (panel1.Width > posx4 + ancho4)
                    {
                        posx4 = posx4 + cambio4;
                    }
                    else
                    {
                        InicioPausaCaballo4 = false;
                        String caballo4 = "4";
                        DarFinalCarrera(caballo4);
                    }
                }

                //Repinta la interfaz 
                panel1.Invalidate();

                //Duerme el hilo
                Thread.Sleep(150);
            }


        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(new Bitmap("caballo2.png"), posx, posy, ancho, alto);
            e.Graphics.DrawImage(new Bitmap("caballo4.png"), posx2, posy2, ancho2, alto2);
            e.Graphics.DrawImage(new Bitmap("caballo1.png"), posx3, posy3, ancho3, alto3);
            e.Graphics.DrawImage(new Bitmap("caballo3.png"), posx4, posy4, ancho4, alto4);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bttnIniciar_Click(object sender, EventArgs e)
        {

            //Se obtiene el caballo seleccionado
            String caballoSeleccionado = cbxCaballos.Text;
            //Se valida que la apuesta y el caballo seleccionado no este vacio
            if (string.IsNullOrEmpty(txtValor.Text) || string.IsNullOrEmpty(caballoSeleccionado))
            {
                MessageBox.Show("Complete los campos.");
            }
            else
            {
                //CaballoApuesta se encarga de llamar la validacion del combo
                caballoApuesta = apuesta.validarComboCaballo(caballoSeleccionado);
                //Si lanza -1, ocurrio un problema al seleccionar el caballo
                if (caballoApuesta == -1)
                {
                    MessageBox.Show("Seleccione un caballo");
                }
                else
                {
                    
                    //Valor de la apuesta obtenido en el campo de texto
                    valorApuesta = Convert.ToDouble(txtValor.Text);
                    //Se verifica el valor de la apuesta que sea mayor que 0 y menor que la base del dinero total
                    if (valorApuesta > 0 && valorApuesta <= apuesta.DarValorApuestaBase())
                    {
                        if (InicioCarrera == false)
                        {
                            //Metodo encargado de eliminar las posiciones de la carrera
                            cbxCaballos.Enabled = false;
                            apuesta.EliminarPosicionesCarrera();
                            InicioPausaCaballo1 = true;
                            InicioPausaCaballo2 = true;
                            InicioPausaCaballo3 = true;
                            InicioPausaCaballo4 = true;
                            //llamado al metodo de iniciar carrera
                            InicioCarrera = true;
                            hilo = new Thread(repintar);
                            hilo2 = new Thread(repintar2);
                            hilo3 = new Thread(repintar3);
                            hilo4 = new Thread(repintar4);
                            hilo.Start();
                            hilo2.Start();
                            hilo3.Start();
                            hilo4.Start();


                            bttnIniciar.Text = "INICIAR";
                            txtValor.Enabled = false;
                            bttnIniciar.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor de la apuesta debe de ser mayor a 0 y menor o igual a " + txtValorInicial.Text);
                    }
                }
            }




            if (txtValor.Text != "")
            {

                posicion = Position.right;
                posicion2 = Position.right;
                posicion3 = Position.right;
                posicion4 = Position.right;





            }
            else
            {
                MessageBox.Show("Debe completar todos los datos");
            }


        }

        private void cbxCaballos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }



        public void DarFinalCarrera(String caballo)
        {
            //Se agrega el caballo a las posiciones 
            apuesta.AgregarCaballoPosicion(caballo);
            if (InicioPausaCaballo1 == false && InicioPausaCaballo2 == false && InicioPausaCaballo3 == false && InicioPausaCaballo4 == false)
            {
                CheckForIllegalCrossThreadCalls = false;
                //Se da el ganador 
                String ganador = apuesta.DarCaballoGanador();
                int numCaballoGanador = Convert.ToInt32(ganador);
                MessageBox.Show("El ganador de la carrera es el Caballo " + numCaballoGanador);
                InicioCarrera = false;
                //Se inicia la posicion en x | y
                posx = 0;
                posy = 10;
                ancho = 50;
                alto = 50;


                posx2 = 0;
                posy2 = 70;
                ancho2 = 50;
                alto2 = 50;

                posx3 = 0;
                posy3 = 130;
                ancho3 = 50;
                alto3 = 50;


                posx4 = 0;
                posy4 = 190;
                ancho4 = 50;
                alto4 = 50;
                //Se encarga de llamar el metodo de realizar la apuesta
                Boolean respuestaApuesta = apuesta.realizarApuesta(numCaballoGanador, caballoApuesta, valorApuesta);
                bttnIniciar.Enabled = true;
                //Dar el valor de la apuesta base
                valorApuesta = apuesta.DarValorApuestaBase();
                if (respuestaApuesta == true)
                {
                    MessageBox.Show("Gano en la apuesta: " + valorApuesta);
                    txtValorInicial.Text = valorApuesta + "";
                    txtValor.Text = "0";
                    cbxCaballos.Enabled = true;
                    txtValor.Enabled = true;
                    
                }
                else
                {
                    MessageBox.Show("Perdio en la apuesta: " + valorApuesta);
                    txtValorInicial.Text = valorApuesta + "";
                    txtValor.Text = "0";
                    cbxCaballos.Enabled = true;
                    txtValor.Enabled = true;
                    
                }
                //Se muestra la lista de posiciones de los caballos
                foreach (String lista in apuesta.listaCaballosPosiciones)
                {
                    Console.WriteLine(lista);
                }

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


    }
}
