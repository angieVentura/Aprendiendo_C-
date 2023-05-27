using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula
{
    internal class Aula
    {
        public int id;
        public int maxAl;
        public Materia materia;
        public Profesor profesor;
        public List<Estudiante> estudiantes;

        public Aula(int id, int maxAl, Materia materia, Profesor profesor, List<Estudiante> estudiantes)
        {
            this.id = id;
            this.maxAl = maxAl;
            this.materia = materia;
            this.profesor = profesor;
            this.estudiantes = estudiantes;
        }

        public string[] ClaseSuspendida()
        {
            return new string[] {
                estudiantes.Count(e => !e.presente) > (estudiantes.Count / 2) ? "\nNo se cumple con el porcentaje de asistencia del alumnado." : null,
                !profesor.presente ? "\nEl docente está ausente." : null,
                profesor.materia == materia ? "\nNo hay docente para la materia." : null
            };
        }

        public int AprobadosM()
        {
            return estudiantes.Count(e => e.sexo == 'm' && e.calificacion >= 6);
        }

        public int AprobadosH()
        {
            return estudiantes.Count(e => e.sexo == 'h' && e.calificacion >= 6);
        }
    }
}
