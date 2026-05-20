using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    public partial class InscripcionesForm : Form
    {
        private int? idEstudianteActual = null;
        private readonly DBComponent db;
        private readonly JsonLoader loader;

        public InscripcionesForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            this.Load += InscripcionesForm_Load;
            SearchBox.KeyDown += SearchBox_KeyDown;
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
        }

        /// <summary>
        /// Evento que inicializa la pantalla de inscripciones.
        /// Configura los grids de cursos y horarios, y prepara columnas dinámicas.
        /// </summary>
        private void InscripcionesForm_Load(object? sender, EventArgs e)
        {
            dataGridCursos.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridCursos.ReadOnly = false;
            dataGridCursos.SelectionChanged += dataGridCursos_SelectionChanged;
            SearchBox.Click += SearchBox_Click;
            dataGridHorario.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridHorario.RowTemplate.Height = 60; 
            dataGridCursos.AutoGenerateColumns = false;
            dataGridHorario.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dataGridCursos.Rows.Clear();
            dataGridHorario.Rows.Clear();
            dataGridHorario.ReadOnly = false; 
            dataGridHorario.Enabled = true;    
            dataGridHorario.AllowUserToAddRows = false;
            dataGridHorario.AllowUserToDeleteRows = false;
            dataGridHorario.EditMode = DataGridViewEditMode.EditProgrammatically;

            if (!dataGridCursos.Columns.Contains("Seleccionar"))
            {
                var colCheck = new DataGridViewCheckBoxColumn
                {
                    Name = "Seleccionar",
                    HeaderText = "✔",
                    Width = 50,
                    ReadOnly = false
                };
                dataGridCursos.Columns.Insert(0, colCheck);
            }

            if (!dataGridCursos.Columns.Contains("id_curso"))
            {
                var colHidden = new DataGridViewTextBoxColumn
                {
                    Name = "id_curso",
                    Visible = false
                };
                dataGridCursos.Columns.Add(colHidden);
            }

            dataGridCursos.CellValueChanged += dataGridCursos_CellValueChanged;
            dataGridCursos.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dataGridCursos.CurrentCell is DataGridViewCheckBoxCell &&
                    dataGridCursos.IsCurrentCellDirty)
                {
                    dataGridCursos.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
            dataGridHorario.Refresh();
        }

        /// <summary>
        /// Evento que se dispara al cambiar la selección en el grid de cursos.
        /// Consulta el horario asociado al curso seleccionado.
        /// </summary>
        private void dataGridCursos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridCursos.CurrentRow?.Cells["id_curso"].Value is not int idCurso)
                return;

            string sql = loader.BuildSql("horario_por_curso");
            var parameters = new[] { new NpgsqlParameter("@curso", idCurso) };
            DataTable horario = db.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Acción que intenta inscribir al estudiante en todos los cursos marcados.
        /// Realiza validaciones por período y confirma cada inserción.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (idEstudianteActual is null)
            {
                MessageBox.Show("Busque primero al estudiante.");
                return;
            }

            int contador = 0;
            foreach (DataGridViewRow fila in dataGridCursos.Rows)
            {
                bool seleccionado = fila.Cells["Seleccionar"].Value is true;
                if (!seleccionado) continue;

                if (!int.TryParse(fila.Cells["id_curso"].Value?.ToString(), out int idCurso))
                    continue;

                string sqlPeriodo = loader.BuildSql("periodo_de_curso");
                var paramPeriodo = new[] { new NpgsqlParameter("@id", idCurso) };
                DataTable resultado = db.ExecuteQuery(sqlPeriodo, paramPeriodo);

                string periodo = resultado.Rows.Count > 0
                    ? resultado.Rows[0]["periodo_academico"]?.ToString() ?? ""
                    : "";

                if (string.IsNullOrWhiteSpace(periodo))
                {
                    MessageBox.Show($"Curso {idCurso} no tiene período definido.");
                    continue;
                }

                string sql = loader.BuildSql("insertar_inscripcion");
                var parameters = new[]
                {
            new NpgsqlParameter("@persona", idEstudianteActual),
            new NpgsqlParameter("@curso", idCurso),
            new NpgsqlParameter("@fecha", DateTime.Today),
            new NpgsqlParameter("@periodo", periodo)
        };

                try
                {
                    db.ExecuteNonQuery(sql, parameters);
                    contador++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al inscribir curso {idCurso}: {ex.Message}");
                }
            }

            if (contador > 0)
            {
                MessageBox.Show($"Se inscribieron {contador} curso(s).");
                ShowCursosAvailable(idEstudianteActual.Value);
            }
            else
            {
                MessageBox.Show("No se inscribió ningún curso.");
            }
        }

        /// <summary>
        /// Cierra el formulario y retorna al flujo anterior.
        /// </summary>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el campo de búsqueda.
        /// Busca al estudiante por cédula y carga los cursos disponibles si es válido.
        /// </summary>
        private void SearchBox_Click(object? sender, EventArgs e)
        {
            string cedula = SearchBox.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("Por favor ingrese una cédula.");
                return;
            }

            int? resultado = SearchIdByCedula(cedula);

            if (resultado is null)
            {
                MessageBox.Show("Esta sección es solo para inscripción de estudiantes.");
                return;
            }

            if (resultado == -1)
            {
                MessageBox.Show("Estudiante no encontrado.");
                return;
            }
                
            idEstudianteActual = resultado;
            ShowCursosAvailable(resultado.Value);
        }

        /// <summary>
        /// Muestra los cursos disponibles para inscripción, excluyendo los ya inscritos.
        /// Filtra por código de materia y carga el grid con los datos actualizados.
        /// </summary>
        private void ShowCursosAvailable(int idPersona)
        {
            string sqlCursos = loader.BuildSql("cursos_disponibles_con_detalles");
            DataTable todos = db.ExecuteQuery(sqlCursos);

            string sqlYaInscrito = loader.BuildSql("horario_actual_del_estudiante");
            var parameters = new[] { new NpgsqlParameter("@persona", idPersona) };
            DataTable horarioActual = db.ExecuteQuery(sqlYaInscrito, parameters);

            var codigosYaInscritos = horarioActual.Rows.Cast<DataRow>()
                .Where(r => r["codigo_materia"] != DBNull.Value)
                .Select(r => r["codigo_materia"]!.ToString())
                .ToHashSet();

            var disponibles = todos.Rows.Cast<DataRow>()
                .Where(r => r["codigo_materia"] != DBNull.Value &&
                            !codigosYaInscritos.Contains(r["codigo_materia"]!.ToString()))
                .ToList();

            if (disponibles.Count > 0)
                LoadCursosInGrid(disponibles.CopyToDataTable());
            else
                dataGridCursos.Rows.Clear();
        }

        /// <summary>
        /// Evento que se dispara al presionar ENTER en el campo de búsqueda.
        /// Ejecuta la lógica del clic y suprime el evento de teclado.
        /// </summary>
        private void SearchBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBox_Click(SearchBox, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Carga los cursos filtrados en el grid de cursos.
        /// Asigna valores y oculta columnas técnicas.
        /// </summary>
        private void LoadCursosInGrid(DataTable cursos)
        {
            dataGridCursos.Rows.Clear();

            foreach (DataRow row in cursos.Rows)
            {
                int idx = dataGridCursos.Rows.Add();
                var r = dataGridCursos.Rows[idx];

                r.Cells["Seleccionar"].Value = false;
                r.Cells["ID"].Value = row["codigo_materia"]?.ToString() ?? "—";
                r.Cells["Materia"].Value = row["materia"]?.ToString() ?? "—";
                r.Cells["Seccion"].Value = row["seccion"]?.ToString() ?? "—";
                r.Cells["Trimestre"].Value = row["trimestre"]?.ToString() ?? "—";
                r.Cells["HC"].Value = row["hc"]?.ToString() ?? "—";
                r.Cells["Cupo"].Value = row["cupo"]?.ToString() ?? "—";
                r.Cells["Docente"].Value = row["docente"]?.ToString() ?? "—";
                r.Cells["id_curso"].Value = row["id_curso"];
            }
        }

        /// <summary>
        /// Busca el ID del estudiante a partir de su cédula.
        /// Retorna -1 si no existe, null si no es tipo estudiante.
        /// </summary>
        private int? SearchIdByCedula(string cedula)
        {
            string sql = loader.BuildSql("buscar_persona_por_cedula");
            var parameters = new[] { new NpgsqlParameter("@cedula", cedula) };
            DataTable dt = db.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count == 0 || dt.Rows[0]["id"] == DBNull.Value)
                return -1;

            string tipo = dt.Rows[0]["id_tipo_persona"]?.ToString() ?? "";

            if (tipo != "1")
                return null;

            return Convert.ToInt32(dt.Rows[0]["id"]);
        }

        /// <summary>
        /// Evento que se dispara al cambiar el estado del checkbox 'Seleccionar' en una fila del grid.
        /// Carga el horario asociado al curso si fue marcado, o lo elimina si fue desmarcado.
        /// </summary>
        private void dataGridCursos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (dataGridCursos.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            var fila = dataGridCursos.Rows[e.RowIndex];
            bool seleccionado = fila.Cells["Seleccionar"].Value is true;

            if (fila.Cells["id_curso"].Value is not null &&
                int.TryParse(fila.Cells["id_curso"].Value.ToString(), out int idCurso))
            {
                string sql = loader.BuildSql("horario_por_curso");
                var parameters = new[] { new NpgsqlParameter("@curso", idCurso) };
                DataTable horario = db.ExecuteQuery(sql, parameters);

                if (horario.Rows.Count == 0)
                {
                    MessageBox.Show("Este curso no tiene horario registrado.");
                    return;
                }

                if (seleccionado)
                    DrawIncrementalSchedule(horario);
                else
                    RemoveCursoSchedule(horario);
            }
        }

        /// <summary>
        /// Elimina visualmente el bloque de horario correspondiente al curso desmarcado.
        /// Busca coincidencias exactas en cada celda y limpia la que lo contiene.
        /// </summary>
        /// <param name="horario">DataTable con los bloques de horario a eliminar.</param>
        private void RemoveCursoSchedule(DataTable horario)
        {
            foreach (DataRow row in horario.Rows)
            {
                string dia = row["dia"]?.ToString() ?? "";
                string hi = row["hora_inicio"]?.ToString() ?? "—";
                string hf = row["hora_fin"]?.ToString() ?? "—";
                string aula = row["aula"]?.ToString() ?? "—";
                string materia = row["materia"]?.ToString() ?? "Materia";

                string bloque = $"{hi}-{hf} ({aula})\n{materia}";

                int colIndex = dataGridHorario.Columns[dia]?.Index ?? -1;
                if (colIndex == -1) continue;

                for (int i = 0; i < dataGridHorario.Rows.Count; i++)
                {
                    var cell = dataGridHorario.Rows[i].Cells[colIndex];
                    if (cell.Value?.ToString() == bloque)
                    {
                        cell.Value = ""; 
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Dibuja en el grid de horarios los bloques asociados a un curso marcado.
        /// Agrega columnas y filas si no existen, y coloca el texto en la primera celda vacía del día.
        /// </summary>
        /// <param name="horario">DataTable con los bloques de horario a insertar.</param>
        private void DrawIncrementalSchedule(DataTable horario)
        {
            if (dataGridHorario.Columns.Count == 0)
            {
                string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
                foreach (string dia in dias)
                    dataGridHorario.Columns.Add(dia, dia);
            }

            while (dataGridHorario.Rows.Count < 5)
                dataGridHorario.Rows.Add();

            foreach (DataRow row in horario.Rows)
            {
                string dia = row["dia"]?.ToString() ?? "";
                string hi = row["hora_inicio"]?.ToString() ?? "—";
                string hf = row["hora_fin"]?.ToString() ?? "—";
                string aula = row["aula"]?.ToString() ?? "—"; 
                string nombre = row["materia"]?.ToString() ?? "Materia";
                string seccion = row["seccion"]?.ToString() ?? "";
                string bloque = $"{hi}-{hf} ({aula})\n{nombre} \"{seccion}\"";


                int colIndex = dataGridHorario.Columns[dia]?.Index ?? -1;
                if (colIndex == -1) continue;

                for (int i = 0; i < dataGridHorario.Rows.Count; i++)
                {
                    var cell = dataGridHorario.Rows[i].Cells[colIndex];
                    if (string.IsNullOrEmpty(cell.Value?.ToString()))
                    {
                        cell.Value = bloque;
                        break;
                    }
                }
            }
        }

    }
}
