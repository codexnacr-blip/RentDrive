using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RentDrive.Models;

namespace RentDrive.Controllers;

public class HomeController : Controller
{
    private static readonly List<VehiculoModel> _flota = new List<VehiculoModel>
    {
        new VehiculoModel
        {
            ID = 1,
            Marca = "DeLorean",
            Modelo = "DMC-12",
            Año = 1981,
            Epoca = "Años 80s / Synthwave",
            EstiloVisual = "Cyberpunk/Neon",
            ColorExt = "Acero Inoxidable / Plateado",
            ColorInt = "Negro Cuero",
            Apto = true,
            TieneChofer = true,
            TarifaHora = 85.00m,
            TarifaDia = 550.00m,
            ImagenURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsdrdL35_h7myG2IedIHbOE5sOKVn_RS2JOoI4_GQj9drGLha8xGccYtk&s=10",
            DescripcionEscenario = "Modelo legendario que aparte de su diseño futurista, marcó a la industria del cine con Volver al futuro",
            Detalles = new List<string> {"Puertas alas de gaviota", "Acabado metálico mate", "Luces de tablero rojas/verdes" }

        },

        new VehiculoModel
        {
            ID = 2,
            Marca = "Ford",
            Modelo = "Mustang Fastback",
            Año = 1967,
            Epoca = "Clásico 60s/70s",
            EstiloVisual = "Muscle Car Retro",
            ColorExt = "Rojo Pasión",
            ColorInt = "Negro",
            Apto = true,
            TieneChofer = false,
            TarifaHora = 65.00m,
            TarifaDia = 420.00m,
            ImagenURL = "https://www.univision.com/_next/image?url=https%3A%2F%2Fst1.uvnimg.com%2Fcc%2F54%2F749cf28742009c2c606bfd061960%2F1965-ford-mustang-fastback-1.jpg&w=1280&q=75",
            DescripcionEscenario = "Ideal para secuencias de acción estilo cinema clásico, fotografía de moda o videos temáticos",
            Detalles = new List<string> { "Líneas de carreras blancas", "Sonido de motor V8 retro", "Volante de madera de época" }
        },

        new VehiculoModel
        {
            ID = 3,
            Marca = "Volkswagen",
            Modelo = "Type 2 Kombi",
            Año = 1974,
            Epoca = "Años 70s",
            EstiloVisual = "Vintage / Hippie",
            ColorExt = "Turquesa & Blanco",
            ColorInt = "Beige Retro",
            Apto = false,
            TieneChofer = false,
            TarifaHora = 45.00m,
            TarifaDia = 280.00m,
            ImagenURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpgebmuSeIQoaHKBcFAdA9YArERUrgVr4Qm4CPgkNsqg&s=10",
            DescripcionEscenario = "Excelente props estático para sesiones fotográficas de marca, festivales o producciones estilo libre/boho",
            Detalles = new List<string> { "Parrilla de techo de madera", "Cortinas vintage integradas", "Pintura bitono restaurada" }
        }
    };

    public IActionResult Index(string? epoca, string? estilo, string? color)
    {
        var vehiculoFiltrado = _flota.AsQueryable();

        if (!string.IsNullOrEmpty(epoca))
        {
            vehiculoFiltrado = vehiculoFiltrado.Where(v => v.Epoca == epoca);
        }

        if (!string.IsNullOrEmpty(estilo))
        {
            vehiculoFiltrado = vehiculoFiltrado.Where(v => v.EstiloVisual == estilo);
        }

        if (!string.IsNullOrEmpty(color))
        {
            vehiculoFiltrado = vehiculoFiltrado.Where(v => v.ColorExt.Contains(color, StringComparison.OrdinalIgnoreCase));
        }

        var model = new VehiculoViewModel
        {
            Vehiculos = vehiculoFiltrado.ToList(),
            Epoca = epoca,
            Estilo = estilo,
            Color = color,
            Epocas = _flota.Select(v => v.Epoca).Distinct().ToList(),
            Estilos = _flota.Select(v => v.EstiloVisual).Distinct().ToList(),
            Colores = new List<string> { "Plateado", "Rojo", "Turquesa", "Negro"}
        };

        return View(model);
    }
}
