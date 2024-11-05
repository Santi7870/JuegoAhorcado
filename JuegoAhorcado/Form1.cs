using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JuegoAhorcado
{
    public partial class Form1 : Form
    {
        private string palabraSecreta;
        private string palabraMostrada;
        private int errores;
        private List<char> letrasIncorrectas;
        private List<string> listaPalabras;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaPalabras = new List<string> { "guitarra", "tecnologia", "ecuador", "visualstudio", "algoritmo" };
            IniciarJuego();
        }

        private void IniciarJuego()
        {
            palabraSecreta = listaPalabras[new Random().Next(listaPalabras.Count)];
            palabraMostrada = new string('_', palabraSecreta.Length);
            errores = 0;
            letrasIncorrectas = new List<char>();
            ActualizarInterfaz();
        }

        private void ActualizarInterfaz()
        {
            label1.Text = palabraMostrada; // Muestra la palabra oculta
            label2.Text = string.Join(", ", letrasIncorrectas); // Muestra las letras incorrectas
            textBox1.Clear(); // Limpia el TextBox después de cada intento
            textBox1.Focus(); // Enfoca el TextBox para la siguiente entrada
        }

        private void btnComprobar(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                char letra = textBox1.Text.ToLower()[0];

                if (palabraSecreta.Contains(letra))
                {
                    var nuevaPalabraMostrada = palabraMostrada.ToCharArray();
                    for (int i = 0; i < palabraSecreta.Length; i++)
                    {
                        if (palabraSecreta[i] == letra)
                        {
                            nuevaPalabraMostrada[i] = letra;
                        }
                    }
                    palabraMostrada = new string(nuevaPalabraMostrada);
                }
                else
                {
                    if (!letrasIncorrectas.Contains(letra))
                    {
                        letrasIncorrectas.Add(letra);
                        errores++;
                    }
                }

                ActualizarInterfaz();
                ComprobarEstadoJuego();
            }
        }

        private void ComprobarEstadoJuego()
        {
            if (palabraMostrada == palabraSecreta)
            {
                MessageBox.Show("¡Felicidades, ganaste!");
                IniciarJuego();
            }
            else if (errores >= 6)
            {
                MessageBox.Show($"Has perdido. La palabra era {palabraSecreta}");
                IniciarJuego();
            }
        }

        private void btnReiniciar(object sender, EventArgs e)
        {
            IniciarJuego();
        }
    }
}


