using System.Reflection;

namespace AlquilerMicroservicio.Application
{
    /// <summary>
    /// Referencia al ensamblado de la capa de aplicación. Se usa para registrar cosas como los handlers sin volverse loco buscando tipos.
    /// </summary>
    public static class ApplicationAssemblyReference
    {
        /// <summary>
        /// Ensamblado actual de la aplicación. Básicamente, apunta aquí para saber dónde está todo lo de esta capa.
        /// </summary>
        public static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
