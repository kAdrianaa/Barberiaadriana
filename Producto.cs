using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia
{
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button2_Click(object sender, EventArgs e)
        {

            string mensaje = "¿Deseas eliminar los datos de este producto?";
            string titulo = "Eliminar datos";

            if (!(dataGridView1.CurrentRow is null))
            {
                if (MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Informacion borrada con exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un renglon", "producto eliminado", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("selecciona un renglon", "correciones", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["ID de empleado"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells["Tipo de contrato"].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells["Edad"].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells["Numero de cuenta"].Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string IDempleado = textBox1.Text;
            string edad = textBox2.Text;
            string nombre = textBox3.Text;
            string correo = textBox4.Text;
            string cargo = textBox5.Text;
            string numerodecuenta = textBox6.Text;
            string tipodecontrato = textBox7.Text;
            string telefono = textBox8.Text;
            try
            {
                List<string> errores = new List<string>();


                // Validar que el nombre de usuario no sea vacío y tenga al menos tres caracteres
                if (string.IsNullOrWhiteSpace(IDempleado))
                {
                    errores.Add("El campo 'ID de empleado' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(edad))
                {
                    errores.Add("El campo 'Edad' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    errores.Add("El campo 'Nombre' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(correo))
                {
                    errores.Add("El campo 'Correo' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(cargo))
                {
                    errores.Add("El campo 'Cargo' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(numerodecuenta))
                {
                    errores.Add("El campo 'Numero de cuenta' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(tipodecontrato))
                {
                    errores.Add("El campo 'Tipo de contrato' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(telefono))
                {
                    errores.Add("El campo 'Telefono' no puede estar vacío.");
                }
                else if (numerodecuenta.Length < 20)
                {
                    errores.Add("El 'numero de cuenta' debe tener al menos 20 caracteres.");
                }


                if (string.IsNullOrWhiteSpace(numerodecuenta) || numerodecuenta.Length < 20)
                {
                    errores.Add("El 'Numero de cuenta' debe tener al menos 20 caracteres.");
                }
                // Validar que el teléfono tenga diez caracteres y sea numérico
                if (string.IsNullOrWhiteSpace(telefono) || telefono.Length != 10 || !telefono.All(char.IsDigit))
                {
                    errores.Add("El 'Teléfono' debe tener diez caracteres y contener solo dígitos.");
                }

                // Agrega más validaciones según sea necesario...

                if (errores.Count > 0)
                {
                    string mensajeError = "Por favor, corrige los siguientes errores:\n\n";
                    mensajeError += string.Join("\n", errores);
                    MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("¡Bienvenido!");
                    this.Hide();

                    Trabajador trabajador = new Trabajador();
                    trabajador.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        }
    }
