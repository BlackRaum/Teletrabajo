using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Funcionario
    {
        public int idFuncionario { get; set; }       
        public String numeroIdentificacion { get; set; }
        public String nombreCompleto { get; set; }
        public String nombramiento { get; set; }
        public String cargo { get; set; }
        public String telefonoFijo { get; set; }
        public String telefonoCelular { get; set; }
        public String correoElectronico { get; set; }
        public Boolean isJefe { get; set; }
        public String provincia { get; set; }
        public String canton { get; set; }
        public String distrito { get; set; }
        public String direccion { get; set; }        
        public String usuario { get; set; }
        public String password { get; set; }
        public Boolean datosCompletos { get; set; }

        public Funcionario jefe { get; set; }
        public UnidadTrabajo unidadTrabajo { get; set; }
        public PersonaEmergencia contactoEmergencia { get; set; }
        public PuestoTeletrabajo puestoTeletrabajo { get; set; }
        public PlanTrabajo planTrabajo { get; set; }
        public PerfilLaboral perfilLaboral { get; set; }
        public PerfilPuesto perfilPuesto { get; set; }

        public Funcionario()
        {
            jefe = new Funcionario();
            unidadTrabajo = new UnidadTrabajo();
            contactoEmergencia = new PersonaEmergencia();
            puestoTeletrabajo = new PuestoTeletrabajo();
            planTrabajo = new PlanTrabajo();
            perfilLaboral = new PerfilLaboral();
            perfilPuesto = new PerfilPuesto();
        }
    }
}
