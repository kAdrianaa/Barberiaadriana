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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombredeusuario = textBox1.Text;
            string correo = textBox2.Text;
            string contraseña = textBox3.Text;
            string telefono = textBox4.Text;
            string nombre = textBox5.Text;
            string rol = textBox6.Text;
            string IDdeusuario = textBox7.Text;
            string fechadenacimiento = dateTimePicker1.Text;

            try
            {
                List<string> errores = new List<string>();


                    // Validar que el nombre de usuario no sea vacío y tenga al menos tres caracteres
                    if (string.IsNullOrWhiteSpace(nombredeusuario))
                    {
                        errores.Add("El campo 'Nombre de usuario' no puede estar vacío.");
                    }
                    if (string.IsNullOrWhiteSpace(correo))
                    {
                        errores.Add("El campo 'correo' no puede estar vacío.");
                    }
                    if (string.IsNullOrWhiteSpace(contraseña))
                    {
                        errores.Add("El campo 'contraseña' no puede estar vacío.");
                    }
                    if (string.IsNullOrWhiteSpace(telefono))
                    {
                        errores.Add("El campo 'telefono' no puede estar vacío.");
                    }
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        errores.Add("El campo 'Nombre' no puede estar vacío.");
                    }
                    if (string.IsNullOrWhiteSpace(rol))
                    {
                        errores.Add("El campo 'Rol' no puede estar vacío.");
                    }
                if (string.IsNullOrWhiteSpace(IDdeusuario))
                {
                    errores.Add("El campo 'ID de usuario' no puede estar vacío.");
                }
                else if (nombredeusuario.Length < 3)
                {
                    errores.Add("El 'Nombre de usuario' debe tener al menos tres caracteres.");
                }

                    // Validar que el nombre de usuario no sea vacío y tenga al menos tres caracteres
                    if (string.IsNullOrWhiteSpace(nombredeusuario) || nombredeusuario.Length < 3)
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
                if (string.IsNullOrWhiteSpace(IDdeusuario) || !IDdeusuario.All(char.IsDigit))
                {
                    errores.Add("El 'ID de usuario' debe contener solo dígitos.");
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



        private void button2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            Hide();
        }
    }
}
