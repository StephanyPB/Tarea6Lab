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
using System.Windows.Shapes;
using Tarea6Lab.BLL;
using Tarea6Lab.Entidades;

namespace Tarea6Lab.UI
{
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles Rol = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = this.Rol;
            LlenarCombo();
        }


        private void LlenarCombo()
        {
            this.PermisosComboBox.ItemsSource = PermisoBLL.GetList(x => true);
            this.PermisosComboBox.SelectedValuePath = "PermisoId";
            this.PermisosComboBox.DisplayMemberPath = "Descripcion";

            if (PermisosComboBox.Items.Count > 0)
                PermisosComboBox.SelectedIndex = 0;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void Limpiar()
        {
            Rol = new Roles();
            Cargar();
            LlenarCombo();
        }
        private void Cargar()
        {
            this.DatosDataGrid.ItemsSource = null;
            this.DatosDataGrid.ItemsSource = this.Rol.Detalle;
            this.DataContext = null;
            this.DataContext = this.Rol;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(RolIDTextBox.Text, out int RolId);
            var Rol = RolesBLL.Buscar(RolId);

            if (Rol != null)
                this.Rol = Rol;
            else
                this.Rol = new Roles();
            Cargar();
        }

        private void AgregarPermisoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Rol.AgregarDetalle(this.Rol.RolId, Convert.ToInt32(((Permisos)PermisosComboBox.SelectedItem).PermisoId), true, this.Rol.Descripcion);

            Cargar();

        }

       

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(this.Rol);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }
       
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Roles existe = RolesBLL.Buscar(this.Rol.RolId);

            if (RolesBLL.Eliminar(this.Rol.RolId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void RemoverrPermiso_Click(object sender, RoutedEventArgs e)
        {
            if (DatosDataGrid.SelectedIndex < 0)
                return;//Con estas 2 lineas ya no vuelve a pasar
            if (DatosDataGrid.Items.Count >= 1 && DatosDataGrid.SelectedIndex <= DatosDataGrid.Items.Count - 1)
            {
                Rol.Detalle.RemoveAt(DatosDataGrid.SelectedIndex);
                Cargar();
            }
        }
    }
}
