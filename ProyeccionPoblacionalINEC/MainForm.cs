// Forms/MainForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ProyeccionPoblacionalINEC.Models;

namespace ProyeccionPoblacionalINEC.Forms
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private List<Edad> listaEdades = new List<Edad>();
        private List<GrupoEtario> listaGrupoEtario = new List<GrupoEtario>();
        private List<EscolaridadEdad> listaEscolaridadEdad = new List<EscolaridadEdad>();


        public MainForm()
        {
            InitializeComponent();

            // Configuraci�n de MaterialSkin
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Esquema de colores
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            // Configurar DataGridViews
            ConfigurarDataGridViews();

            // Asignar eventos a los botones
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            btnSalir.Click += btnSalir_Click;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de Texto|*.txt",
                Title = "Seleccionar Archivo de Proyecci�n"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;

                try
                {
                    // Deshabilitar botones durante la carga
                    btnCargarArchivo.Enabled = false;
                    btnSalir.Enabled = false;

                    // Configurar y mostrar el mensaje inicial
                    this.Invoke(new Action(() =>
                    {
                        materialLabel1.Text = "Iniciando procesamiento...";
                        materialLabel1.Visible = true;
                        materialProgressBar1.Visible = true;
                        materialProgressBar1.Value = 0;
                    }));

                    // Tarea para leer el archivo y cargar en dgvEdadesSexo
                    var tareaLectura = Task.Run(() => LeerArchivoPlano(rutaArchivo));

                    // Esperar a que la lectura se complete antes de procesar
                    await tareaLectura;

                    // Crear tareas para procesar grupos etarios y escolaridad e
                    var tareaGrupoEtario = Task.Run(() => ProcesarGrupoEtario());
                    var tareaEscolaridad = Task.Run(() => ProcesarEscolaridad());

                    // Esperar a que todas las tareas se completen
                    await Task.WhenAll(tareaGrupoEtario, tareaEscolaridad);

                    // Asignar los datos a los DataGridViews
                    AsignarDatosADataGridView("Edades por Sexo", dgvEdadesSexo, listaEdades.OrderBy(e => e.ValorEdad).ToList());
                    AsignarDatosADataGridView("Sexo y Grupo Etario", dgvSexoGrupoEtario, listaGrupoEtario.OrderBy(g => g.Grupo).ToList());
                    AsignarDatosADataGridView("Distribuci�n por Escolaridad y Edad", dgvEducacion, listaEscolaridadEdad.OrderBy(e => e.GradoEscolaridad).ThenBy(e => e.ValorEdad).ToList());

                    // Completar la barra de progreso y actualizar el mensaje
                    this.Invoke(new Action(() =>
                    {
                        materialProgressBar1.Value = 100;
                        materialLabel1.Text = "Procesamiento completado.";
                    }));

                   
                    await Task.Delay(500);
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Error al procesar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                finally
                {
                    // Ocultar el mensaje y la barra de progreso
                    this.Invoke(new Action(() =>
                    {
                        materialLabel1.Visible = false;
                        materialProgressBar1.Visible = false;
                    }));

                    // Rehabilitar los botones
                    btnCargarArchivo.Enabled = true;
                    btnSalir.Enabled = true;
                }
            }
        }


        private void ConfigurarDataGridViews()
        {
            // Configurar dgvEdadesSexo
            dgvEdadesSexo.AutoGenerateColumns = false;
            dgvEdadesSexo.Columns.Clear();

            dgvEdadesSexo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ValorEdad",
                HeaderText = "Edad",
                DataPropertyName = "ValorEdad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEdadesSexo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CantidadHombres",
                HeaderText = "Hombres",
                DataPropertyName = "CantidadHombres",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEdadesSexo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CantidadMujeres",
                HeaderText = "Mujeres",
                DataPropertyName = "CantidadMujeres",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEdadesSexo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvEdadesSexo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEdadesSexo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEdadesSexo.EnableHeadersVisualStyles = false;
            dgvEdadesSexo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEdadesSexo.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvEdadesSexo.RowHeadersVisible = false;

            // Configurar dgvSexoGrupoEtario
            dgvSexoGrupoEtario.AutoGenerateColumns = false;
            dgvSexoGrupoEtario.Columns.Clear();

            dgvSexoGrupoEtario.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Grupo",
                HeaderText = "Grupo Etario",
                DataPropertyName = "Grupo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvSexoGrupoEtario.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalHombres",
                HeaderText = "Hombres",
                DataPropertyName = "TotalHombres",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvSexoGrupoEtario.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalMujeres",
                HeaderText = "Mujeres",
                DataPropertyName = "TotalMujeres",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvSexoGrupoEtario.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalGrupo",
                HeaderText = "Total Grupo",
                DataPropertyName = "TotalGrupo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvSexoGrupoEtario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvSexoGrupoEtario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSexoGrupoEtario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSexoGrupoEtario.EnableHeadersVisualStyles = false;
            dgvSexoGrupoEtario.RowsDefaultCellStyle.BackColor = Color.White;
            dgvSexoGrupoEtario.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvSexoGrupoEtario.RowHeadersVisible = false;

            // Configurar dgvEducacion
            dgvEducacion.AutoGenerateColumns = false;
            dgvEducacion.Columns.Clear();



            dgvEducacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ValorEdad",
                HeaderText = "Edad",
                DataPropertyName = "ValorEdad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEducacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GradoEscolaridad",
                HeaderText = "Grado de Escolaridad",
                DataPropertyName = "GradoEscolaridad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
           


            dgvEducacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalPoblacion",
                HeaderText = "Total Poblaci�n",
                DataPropertyName = "TotalPoblacion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEducacion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvEducacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEducacion.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEducacion.EnableHeadersVisualStyles = false;
            dgvEducacion.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEducacion.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvEducacion.RowHeadersVisible = false;
        }


        private void AsignarDatosADataGridView(string descripcion, DataGridView dgv, object dataSource)
        {
            try
            {
                // Actualizar el Label para indicar qu� DataGridView se est� procesando
                this.Invoke(new Action(() =>
                {
                    materialLabel1.Text = $"Procesando {descripcion}...";
                }));

                dgv.Invoke(new Action(() =>
                {
                    if (dgv == dgvEducacion)
                    {
                        // Ordenar la lista por GradoEscolaridad y luego por Edad
                        var listaOrdenada = listaEscolaridadEdad
                            .OrderBy(e => e.ValorEdad)
                            .ThenBy(e => e.GradoEscolaridad)
                            .ToList();

                       
                        var listaAgrupada = listaOrdenada
                            .GroupBy(e => e.ValorEdad)
                            .SelectMany(g => g)
                            .ToList();

                        dgv.DataSource = null;
                        dgv.DataSource = listaAgrupada;
                    }
                    else
                    {
                        dgv.DataSource = null;
                        dgv.DataSource = dataSource;
                    }
                }));

                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Error al asignar datos a {descripcion}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }



        private void LeerArchivoPlano(string rutaArchivo)
        {
            try
            {
                listaEdades.Clear();
                listaGrupoEtario.Clear();
                listaEscolaridadEdad.Clear();

                var allLines = File.ReadAllLines(rutaArchivo);
                int totalLines = allLines.Length;
                int processedLines = 0;

                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (linea.Length < 58) continue; // Validar longitud m�nima

                        try
                        {
                            Edad edad = new Edad
                            {
                                ValorEdad = int.Parse(linea.Substring(0, 2).Trim()),
                                CantidadHombres = int.Parse(linea.Substring(2, 7).Trim()),
                                CantidadMujeres = int.Parse(linea.Substring(9, 7).Trim()),
                                PrimariaIncompleta = int.Parse(linea.Substring(16, 6).Trim()),
                                PrimariaCompleta = int.Parse(linea.Substring(22, 6).Trim()),
                                SecundariaCompleta = int.Parse(linea.Substring(28, 6).Trim()),
                                SecundariaIncompleta = int.Parse(linea.Substring(34, 6).Trim()),
                                UniversitariaCompleta = int.Parse(linea.Substring(40, 6).Trim()),
                                UniversitariaIncompleta = int.Parse(linea.Substring(46, 6).Trim()),
                                SinEstudios = int.Parse(linea.Substring(52, 6).Trim())
                            };

                            // Calcular TotalPoblacion
                            edad.TotalPoblacion = edad.CantidadHombres + edad.CantidadMujeres;

                            listaEdades.Add(edad);
                        }
                        catch (FormatException fe)
                        {
                           
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Error de formato en la l�nea: {linea}\nDetalle: {fe.Message}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }));
                        }

                        processedLines++;
                        int progress = (int)((double)processedLines / totalLines * 100);

                        // Actualizar la barra de progreso en el hilo principal
                        this.Invoke(new Action(() =>
                        {
                            materialProgressBar1.Value = progress <= 100 ? progress : 100;
                        }));

                      
                        Thread.Sleep(50);
                    }
                }

                // Procesar Datos para Grupo Etario y Escolaridad
                ProcesarGrupoEtario();
                ProcesarEscolaridad();

                // Asignar las fuentes de datos a los DataGridView
                AsignarDatosADataGridView("Edades por Sexo", dgvEdadesSexo, listaEdades.OrderBy(e => e.ValorEdad).ToList());
                AsignarDatosADataGridView("Sexo y Grupo Etario", dgvSexoGrupoEtario, listaGrupoEtario.OrderBy(g => g.Grupo).ToList());
                AsignarDatosADataGridView("Distribuci�n por Escolaridad", dgvEducacion, listaEscolaridadEdad.OrderBy(e => e.GradoEscolaridad).ToList());
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        

        private void ProcesarGrupoEtario()
        {
            // Limpiar la lista antes de agregar nuevos datos
            listaGrupoEtario.Clear();

            List<string> grupos = new List<string> { "0-4", "5-9", "10-14", "15-19", "20-49", "50-59", "60+" };

            foreach (var grupo in grupos)
            {
                var edadesEnGrupo = listaEdades.Where(e => EstaEnGrupo(e.ValorEdad, grupo)).ToList();

                GrupoEtario grupoEtario = new GrupoEtario
                {
                    Grupo = grupo,
                    TotalHombres = edadesEnGrupo.Sum(e => e.CantidadHombres),
                    TotalMujeres = edadesEnGrupo.Sum(e => e.CantidadMujeres),
                    TotalGrupo = edadesEnGrupo.Sum(e => e.TotalPoblacion)
                };

                listaGrupoEtario.Add(grupoEtario);
            }

            // Agregar la fila de Total
            GrupoEtario total = new GrupoEtario
            {
                Grupo = "Total",
                TotalHombres = listaEdades.Sum(e => e.CantidadHombres),
                TotalMujeres = listaEdades.Sum(e => e.CantidadMujeres),
                TotalGrupo = listaEdades.Sum(e => e.TotalPoblacion)
            };

            listaGrupoEtario.Insert(0, total);
        }


        private bool EstaEnGrupo(int edad, string grupo)
        {
            switch (grupo)
            {
                case "0-4":
                    return edad >= 0 && edad <= 4;
                case "5-9":
                    return edad >= 5 && edad <= 9;
                case "10-14":
                    return edad >= 10 && edad <= 14;
                case "15-19":
                    return edad >= 15 && edad <= 19;
                case "20-49":
                    return edad >= 20 && edad <= 49;
                case "50-59":
                    return edad >= 50 && edad <= 59;
                case "60+":
                    return edad >= 60;
                default:
                    return false;
            }
        }

        private void ProcesarEscolaridad()
{
    listaEscolaridadEdad.Clear();
    List<string> niveles = new List<string>
    {
        "Primaria Completa",
        "Primaria Incompleta",
        "Secundaria Completa",
        "Secundaria Incompleta",
        "Universitaria Completa",
        "Universitaria Incompleta",
        "Sin Estudios"
    };

    foreach (var edad in listaEdades)
    {
        // Crear registros para cada nivel de escolaridad
        listaEscolaridadEdad.Add(new EscolaridadEdad
        {
            GradoEscolaridad = "Primaria Completa",
            ValorEdad = edad.ValorEdad,
            TotalPoblacion = edad.PrimariaCompleta
        });
        listaEscolaridadEdad.Add(new EscolaridadEdad
        {
            GradoEscolaridad = "Primaria Incompleta",
            ValorEdad = edad.ValorEdad,
            TotalPoblacion = edad.PrimariaIncompleta
        });
        listaEscolaridadEdad.Add(new EscolaridadEdad
        {
            GradoEscolaridad = "Secundaria Completa",
            ValorEdad = edad.ValorEdad,
            TotalPoblacion = edad.SecundariaCompleta
        });
        listaEscolaridadEdad.Add(new EscolaridadEdad
        {
            GradoEscolaridad = "Secundaria Incompleta",
            ValorEdad = edad.ValorEdad,
            TotalPoblacion = edad.SecundariaIncompleta
        });
        listaEscolaridadEdad.Add(new EscolaridadEdad
        {
            GradoEscolaridad = "Universitaria Completa",
            ValorEdad = edad.ValorEdad,
            TotalPoblacion = edad.UniversitariaCompleta
        });
        listaEscolaridadEdad.Add(new EscolaridadEdad
        {
            GradoEscolaridad = "Universitaria Incompleta",
            ValorEdad = edad.ValorEdad,
            TotalPoblacion = edad.UniversitariaIncompleta
        });
        listaEscolaridadEdad.Add(new EscolaridadEdad
        {
            GradoEscolaridad = "Sin Estudios",
            ValorEdad = edad.ValorEdad,
            TotalPoblacion = edad.SinEstudios
        });
    }

   
    EscolaridadEdad total = new EscolaridadEdad
    {
        GradoEscolaridad = "Total",
        ValorEdad = 0,
        TotalPoblacion = listaEdades.Sum(e => e.TotalPoblacion)
    };

    listaEscolaridadEdad.Insert(0, total);
}



        private void dgvEdadesSexo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatearColumnasDGV(dgvEdadesSexo, new List<string>
            {
                "ValorEdad",
                "CantidadHombres",
                "CantidadMujeres"
            }, "N0");
        }

        private void dgvSexoGrupoEtario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatearColumnasDGV(dgvSexoGrupoEtario, new List<string>
            {
                "TotalHombres",
                "TotalMujeres",
                "TotalGrupo"
            }, "N0");
        }

        private void dgvEducacion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatearColumnasDGV(dgvEducacion, new List<string>
            {
                "TotalPoblacion"
            }, "N0");
        }

        private void FormatearColumnasDGV(DataGridView dgv, List<string> columnas, string formato)
        {
            foreach (var columna in columnas)
            {
                if (dgv.Columns.Contains(columna))
                {
                    dgv.Columns[columna].DefaultCellStyle.Format = formato;
                    dgv.Columns[columna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
            
                }
            }

            // Centrar los encabezados
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
