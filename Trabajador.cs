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
    public partial class Trabajador : Form
    {
        public Trabajador()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
            Hide();

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
                textBox1.Text = dataGridView1.CurrentRow.Cells["usuario"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["ID usuario"].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells["Fecha de nacimiento"].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells["Contraseña"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells["Rol"].Value.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Deseas eliminar los datos de este producto?";
            string titulo = "Borrar datos";

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
                        MessageBox.Show(ex.Message, "Datos eliminados:)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un renglon", "producto eliminado", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contraseña = textBox2.Text;
            string correo = textBox3.Text;
            string telefono = textBox4.Text;
            string nombre = textBox5.Text;
            string rol = textBox6.Text;
            string fechadenacimiento= dateTimePicker1.Text;
            string IDusuario = textBox8.Text;


            try
            {
                List<string> errores = new List<string>();


                // Validar que el nombre de usuario no sea vacío y tenga al menos tres caracteres
                if (string.IsNullOrWhiteSpace(usuario))
                {
                    errores.Add("El campo 'usuario' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(contraseña))
                {
                    errores.Add("El campo 'Correo' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(correo))
                {
                    errores.Add("El campo 'Contraseña' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(telefono))
                {
                    errores.Add("Telefono' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    errores.Add("El campo 'Nombre de usuario' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(rol))
                {
                    errores.Add("El campo 'Rol' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(IDusuario))
                {
                    errores.Add("El campo 'ID de usuario' no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(fechadenacimiento))
                {
                    errores.Add("El campo 'Fecha de naimiento' no puede estar vacío.");
                }
                else if (usuario.Length < 3)
                {
                    errores.Add("El 'Nombre de usuario' debe tener al menos tres caracteres.");
                }

                // Validar que el nombre de usuario no sea vacío y tenga al menos tres caracteres
                if (string.IsNullOrWhiteSpace(usuario) || usuario.Length < 3)
                {
                    errores.Add("El 'Nombre de usuario' debe tener al menos tres caracteres.");
                }

                // Validar que el correo electrónico sea válido
                if (string.IsNullOrWhiteSpace(correo) || !IsValidEmail(correo))
                {
                    errores.Add("El 'Correo electrónico' no es válido.");
                }

                // Validar que el teléfono tenga diez caracteres y sea numérico
                if (string.IsNullOrWhiteSpace(telefono) || telefono.Length != 10 || !telefono.All(char.IsDigit))
                {
                    errores.Add("El 'Teléfono' debe tener diez caracteres y contener solo dígitos.");
                }

                // Validar que los nombres y apellidos solo contengan letras y espacios
                if (string.IsNullOrWhiteSpace(nombre) || !IsAlphaWithSpaces(nombre))
                {
                    errores.Add("Los 'Nombres' deben contener solo letras y espacios.");
                }
                if (string.IsNullOrWhiteSpace(rol) || !IsAlphaWithSpaces(rol))
                {
                    errores.Add("Los 'Rol' deben contener solo letras.");
                }

                // Validar que el ID de usuario sea numérico
                if (string.IsNullOrWhiteSpace(IDusuario) || !IDusuario.All(char.IsDigit))
                {
                    errores.Add("El 'ID de usuario' debe contener solo dígitos.");
                }


                // Validar que la fecha de nacimiento no esté vacía

                if (string.IsNullOrWhiteSpace(fechadenacimiento))
                {
                    errores.Add("El campo 'Fecha de nacimiento' no puede estar vacío.");
                }

                // Validar la contraseña
                if (string.IsNullOrWhiteSpace(contraseña) || contraseña.Length < 6 || contraseña.Length > 15 || (!contraseña.Any(char.IsLetter) || !contraseña.Any(char.IsDigit)))
                {
                    errores.Add("La 'Contraseña' debe tener entre 6 y 15 caracteres y contener letras y al menos un dígito.");
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


            // Función para validar correo electrónico
            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            // Función para validar nombres y apellidos
            bool IsAlphaWithSpaces(string input)
            {
                return input.All(char.IsLetter) || input.All(c => char.IsWhiteSpace(c) || char.IsLetter(c));
            }


            DataGridViewRow renglon = (DataGridViewRow)dataGridView1.Rows[0].Clone();

            renglon.Cells[0].Value = textBox1.Text;
            renglon.Cells[1].Value = textBox3.Text;
            renglon.Cells[2].Value = textBox2.Text;
            renglon.Cells[3].Value = textBox4.Text;
            renglon.Cells[4].Value = textBox5.Text;
            renglon.Cells[5].Value = textBox6.Text;
            renglon.Cells[6].Value = dateTimePicker1.Text;
            renglon.Cells[7].Value = textBox8.Text;

            dataGridView1.Rows.Add(renglon);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            Hide();
        }
    }
}
