using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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
using Torneo.BIZ;
using Torneo.COMMON.Entidades;
using Torneo.COMMON.Interfaces;
using Torneo.COMMON.PuntosGrafica;
using Torneo.DAL;

namespace Entrada
{
    /// <summary>
    /// Lógica de interacción para puntuacion.xaml
    /// </summary>
    public partial class puntuacion : Window
    {
        Generadora generadora;
        Random ran = new Random();
        enum accion
        {
            Nuevo,
            Editar
        }

        IManejadorDeporte manejadorDeporte;
        IManejadorEquipo manejadorEquipo;
        IManejadorUsuario manejadorUsuario;
        IManejadorTorneo manejadorTorneo;
        accion accionn;
        List<TipoDeporte> a = new List<TipoDeporte>();
        List<TipoDeporte> impar = new List<TipoDeporte>();
        string equipo1, equipo2;
        public puntuacion()
        {
            InitializeComponent();

            manejadorDeporte = new ManejadorDeporte(new RepositorioGenerico<Deporte>());
            manejadorEquipo = new ManejadorEquipos(new RepositorioGenerico<Equipos>());
            manejadorUsuario = new ManejadorUsuario(new RepositorioGenerico<Usuarios>());
            manejadorTorneo = new ManejadorTorneo(new RepositorioGenerico<Torneos>());

            cmbEstadisticosEquipos.ItemsSource = null;
            cmbEstadisticosEquipos.ItemsSource = manejadorDeporte.Listar;

            ActualizarTablaTorneos();
            btnVerEstadisticos.Click += btnVerEstadisticos_Click;
            generadora = new Generadora();
        }

        private void ActualizarTablaTorneos()
        {
            dtgPuntuacion.ItemsSource = null;
            dtgPuntuacion.ItemsSource = manejadorTorneo.Listar;

        } 

        private void btnregresar_Click(object sender, RoutedEventArgs e)
        {
            capturas abrir = new capturas();
            abrir.Show();
            this.Close();
        }
        
          private void btnRegresar_Click(object sender, RoutedEventArgs e)
          {
              capturas abrir = new capturas();
              abrir.Show();
              this.Close();
          }

        private void btnActualizarTorneo_Click(object sender, RoutedEventArgs e)
        {

            if ((manejadorTorneo.VerificarSiEsNumero(E1.Text)) == true)
            {
                MessageBox.Show("No se aceptan letras en el equipo 1", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((manejadorTorneo.VerificarSiEsNumero(E2.Text)) == true)
            {
                MessageBox.Show("No se aceptan letras en el equipo 2 ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (accionn == accion.Nuevo)
            {
                Torneos emp = new Torneos()
                {
                    Equipo1= txbEquipo1.Text,
                    Equipo2=txbEquipo2.Text,
                    Marcador_1 = int.Parse(E1.Text),
                    Marcador_2 = int.Parse(E2.Text),
                };
                if (manejadorTorneo.Agregar(emp))
                {
                    MessageBox.Show("Agregadas correctamente", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTablaTorneos();
                }
                else
                {
                    MessageBox.Show("No se pueden actualizar", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Torneos emp = dtgPuntuacion.SelectedItem as Torneos;
                emp.Equipo1 = txbEquipo1.Text;
                emp.Equipo2 = txbEquipo2.Text;
                emp.Marcador_1 = int.Parse(E1.Text);
                emp.Marcador_2 = int.Parse(E2.Text);
                if (manejadorTorneo.Modificar(emp))
                {
                    MessageBox.Show("Actualizacion correcta  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTablaTorneos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarPuntos_Click(object sender, RoutedEventArgs e)
        {
            
            Torneos emp = dtgPuntuacion.SelectedItem as Torneos;
            if (emp != null)
            {
                txbEquipo1.Text = emp.Equipo1;
                txbEquipo2.Text = emp.Equipo2;
                E1.Text = emp.Marcador_1.ToString();
                E2.Text = emp.Marcador_2.ToString();
                accionn = accion.Editar;
 
            }
        }

        private void GenerarEstadisticos(int valor, string Deporte, string Fecha)
        {
            int contador = 1, contador1 = 1;
            List<TemporalDeporteNombre> nombre = new List<TemporalDeporteNombre>();
            foreach (var item in manejadorEquipo.Listar)
            {
                if (item.Deporte == cmbEstadisticosEquipos.Text)
                {
                    TemporalDeporteNombre a = new TemporalDeporteNombre();
                    a.Numerador = contador1++;
                    a.Nombre = item.Nombre;
                    nombre.Add(a);
                }
            }

            List<TorneoLista> listatorneo = new List<TorneoLista>();

            foreach (var item in nombre)
            {
                int valores1 = 0;
                foreach (var item2 in manejadorTorneo.Listar)
                {
                    if (item2.FechaProgramada == clcFechaPuntosEquipos.Text)
                    {
                        if (item.Nombre == item2.Equipo1)
                        {
                            valores1 = valores1 + item2.Marcador_1;
                        }
                        if (item.Nombre == item2.Equipo2)
                        {
                            valores1 = valores1 + item2.Marcador_2;
                        }
                    }
                }
                TorneoLista a = new TorneoLista();
                a.X = contador++;
                a.Equipo = item.Nombre;
                a.Puntaje = valores1;
                listatorneo.Add(a);
            }


            int valores = 0;
            valores = listatorneo.Count;
            generadora.GeneradorDatos(listatorneo, 1, valores, 1);
            dtgTablaEstadisticos.ItemsSource = null;
            dtgTablaEstadisticos.ItemsSource = listatorneo;
            PlotModel model = new PlotModel();
            LinearAxis ejeX = new LinearAxis();
            ejeX.Minimum = 1;
            ejeX.Maximum = valores;
            ejeX.Position = AxisPosition.Bottom;

            LinearAxis ejeY = new LinearAxis();
            ejeY.Minimum = generadora.Puntos.Min(p => p.Y);
            ejeY.Maximum = generadora.Puntos.Max(p => p.Y);
            ejeY.Position = AxisPosition.Left;

            model.Axes.Add(ejeX);
            model.Axes.Add(ejeY);
            model.Title = "Datos ";
            LineSeries linea = new LineSeries();
            foreach (var item in generadora.Puntos)
            {
                linea.Points.Add(new DataPoint(item.X, item.Y));
            }
            linea.Title = "Valores ";
            linea.Color = OxyColor.FromRgb(byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()));
            model.Series.Add(linea);
            Grafica.Model = model;
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            Torneos emp = dtgPuntuacion.SelectedItem as Torneos;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este Torneo ", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorTorneo.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Torneo  eliminado", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaTorneos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            }

        private void btnVerEstadisticos_Click(object sender, RoutedEventArgs e)
        {
            int valor = 0;
            if (string.IsNullOrEmpty(clcFechaPuntosEquipos.Text) || string.IsNullOrEmpty(cmbEstadisticosEquipos.Text))
            {
                MessageBox.Show("Favor de llenar la fecha y el deporte", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorTorneo.Listar)
            {
                if (item.Tipo_Deporte == cmbEstadisticosEquipos.Text && item.FechaProgramada == clcFechaPuntosEquipos.Text)
                {
                    valor++;
                }
            }
            if (valor <= 0)
            {
                MessageBox.Show("Verifique que coincidan los datos ", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GenerarEstadisticos(valor, cmbEstadisticosEquipos.Text, clcFechaPuntosEquipos.Text);

        }
    }
}
