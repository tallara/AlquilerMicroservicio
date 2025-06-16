using System.Reflection;

namespace AlquilerMicroservicio.Application
{
    /// <summary>
    /// Referencia al ensamblado de la capa de aplicaci�n. Se usa para registrar cosas como los handlers sin volverse loco buscando tipos.
    /// </summary>
    public static class ApplicationAssemblyReference
    {
        /// <summary>
        /// Ensamblado actual de la aplicaci�n. B�sicamente, apunta aqu� para saber d�nde est� todo lo de esta capa.
        /// </summary>
        public static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
