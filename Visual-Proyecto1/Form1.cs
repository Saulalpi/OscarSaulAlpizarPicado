using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Visual_Proyecto1
{
    public partial class Form1 : Form
    {
        float num1 = 0, num2 = 0, op = 0, resultado = 0;
        int turnoActual = 1, puntos = 0, puntos_jug1 = 0, puntos_jug2 = 0, turnos = 0, numeroPartida = 0;
        int N = 10;
        char operador = ' ';
        int contlvl = 0;
        int vidas = 3;
        string jugador1 = "", jugador2 = "";
        class Jugador
        {
            public string Nombre { get; set; }
            public int Puntos { get; set; }
            public int Partida { get; set; }
        }

        List<Jugador> clasificacion = new List<Jugador>();



        private void bclasificacion_Click(object sender, EventArgs e)
        {
            lstclasificacion.Items.Clear();
            if (rAcompañado.Checked)
            {   
                clasificacion.Add(new Jugador { Nombre = jugador1, Puntos = puntos_jug1, Partida = numeroPartida });
                clasificacion.Add(new Jugador { Nombre = jugador2, Puntos = puntos_jug2, Partida = numeroPartida });
            }
            else if (rIndividual.Checked)
            {
                clasificacion.Add(new Jugador { Nombre = jugador1, Puntos = puntos, Partida = numeroPartida });
            }

            clasificacion = clasificacion.OrderByDescending(j => j.Puntos).ToList();

            for(int i = 0; i < clasificacion.Count; i++)
            {
                lstclasificacion.Items.Add($"{i + 1}. {clasificacion[i].Nombre} - {clasificacion[i].Puntos} puntos");
            }

        }


        private static readonly Random rng = new Random();



        public Form1()
        {
            InitializeComponent();
        }

        private void Nivel_jug()
        {
            if (contlvl >= 3 && contlvl < 6)
            {
                lnivel_jug.Text = "2";
                N = 101;

            }
            else if (contlvl >= 6)
            {

                lnivel_jug.Text = "3";
                N = 1001;

            }
            else
            {
                lnivel_jug.Text = "1";
                N = 10;

            }
        }


        private void biniciar_Click(object sender, EventArgs e)
        {
            numeroPartida++;
            if (rIndividual.Checked)
            {   
                jugador1 = tname1.Text;
                if (jugador1 == "")
                {
                    MessageBox.Show("Ingrese un nombre para el jugador.");
                    return;
                }
                contlvl = 0;
                N = 10;

                vidas = 3;
                puntos = 0;
                lpuntos.Text = puntos.ToString();
                lvidas.Text = vidas.ToString();

                baceptar.Enabled = true;
                tresultado.Enabled = true;

                Nivel_jug();
                nuevaOperacion();
            }
            else if (rAcompañado.Checked)
            {
                jugador1 = tname1.Text;
                puntos_jug1 = 0;
                jugador2 = tname2.Text;
                puntos_jug2 = 0;

                if (jugador1 == "")
                {
                    MessageBox.Show("Ingrese un nombre para el jugador 1.");
                    return;
                }

                if (jugador2 == "")
                {
                    MessageBox.Show("Ingrese un nombre para el jugador 2.");
                    return;
                }

                lturno.Text = jugador1;

                lpuntos.Text = jugador1 + ": " + puntos_jug1.ToString() + " | " + jugador2 + ": " + puntos_jug2.ToString();

                contlvl = 0;
                N = 10;

                turnoActual = 1;
                turnos = 1;
                lturnos.Text = "Turnos: " + turnos + " / 5";
                baceptar.Enabled = true;
                tresultado.Enabled = true;

                Nivel_jug();
                nuevaOperacion();
            }
            else
            {
                MessageBox.Show("Seleccione un modo de juego.");
                return;
            }
            
        }



        private void nuevaOperacion()
        {

            num1 = rng.Next(1, N);
            num2 = rng.Next(1, N);
            op = rng.Next(1, 5);




            switch (op)
            {
                case 1:
                    resultado = num1 + num2;
                    operador = '+';
                    break;
                case 2:
                    resultado = num1 - num2;
                    operador = '-';
                    break;
                case 3:
                    resultado = num1 * num2;
                    operador = '*';
                    break;
                case 4:
                    if (num2 != 0)
                    {

                        resultado = num1 / num2;
                        operador = '/';
                    }
                    else
                    {
                        MessageBox.Show("Error: División por cero no permitida.");
                        return;
                    }
                    break;
                default:
                    MessageBox.Show("Error: Operación no válida.");
                    return;
            }
            lnum1.Text = num1.ToString();
            lnum2.Text = num2.ToString();
            lop.Text = operador.ToString();

        }
        private void terminarPartidaAcompañado()
        {
            clasificacion.Add(new Jugador { Nombre = jugador1, Puntos = puntos_jug1 });
            clasificacion.Add(new Jugador { Nombre = jugador2, Puntos = puntos_jug2 });

            if (puntos_jug1 > puntos_jug2)
            {
                MessageBox.Show($"Ganó {jugador1}");
            }
            else if (puntos_jug2 > puntos_jug1)
            {
                MessageBox.Show($"Ganó {jugador2}");
            }
            else
            {
                MessageBox.Show("Juego Terminado. Empate.");
            }
            baceptar.Enabled = false;
            tresultado.Enabled = false;
        }



        private void baceptar_Click(object sender, EventArgs e)
        {
            if(!float.TryParse(tresultado.Text, out float respuesta))
            {
                MessageBox.Show("Por favor, ingrese un número.");
                return;
            }
            if (resultado == respuesta)
            {
                MessageBox.Show("Respuesta Correcta");

                if(rIndividual.Checked)
                {
                    contlvl++;
                    puntos++;
                    lpuntos.Text = puntos.ToString();

                    Nivel_jug();
                    nuevaOperacion();

                }
                else if (rAcompañado.Checked)
                {   
                    contlvl++;
                    Nivel_jug();
                    if (turnoActual == 1)
                    {
                        puntos_jug1++;
                       
                    }
                    else
                    {
                        puntos_jug2++;
                    }
                    lpuntos.Text = jugador1 + ": " + puntos_jug1.ToString() + " | " + jugador2 + ": " + puntos_jug2.ToString();


                    turnos++;
                    lturnos.Text = "Turnos: " + turnos + " / 5";

                    if (turnos >= 6)
                    {
                        terminarPartidaAcompañado();
                        return;
                    }
                    if (turnoActual == 1)
                    {
                        turnoActual = 2;
                        lturno.Text = jugador2;
                    }
                    else
                    {
                        turnoActual = 1;
                        lturno.Text = jugador1;


                    }
                    
                      nuevaOperacion();
                    
                }                 
                
            }
            else
            {
                MessageBox.Show("Respuesta Incorrecta");
                
                if (rIndividual.Checked)
                {
                    vidas--;
                    lvidas.Text = vidas.ToString();

                    if (vidas == 0)
                    {
                        MessageBox.Show("Juego Terminado. No tienes más vidas.");
                        clasificacion.Add(new Jugador { Nombre = jugador1, Puntos = puntos });
                        baceptar.Enabled = false;
                        tresultado.Enabled = false;
                    }
                    else
                    {
                    
                        nuevaOperacion();
                    }
                }
                else if (rAcompañado.Checked)
                {
                    turnos++;
                    lturnos.Text = "Turnos: " + turnos + " / 5";

                    if (turnos >= 5)
                    {
                        terminarPartidaAcompañado();
                        return;
                    }

                    if (turnoActual == 1)
                    {
                        turnoActual = 2;
                        lturno.Text = jugador2;
                    }
                    else
                    {
                        turnoActual = 1;
                        lturno.Text = jugador1;
                        

                    }
                    nuevaOperacion();



                     

                }
            }
        }
    }
}
