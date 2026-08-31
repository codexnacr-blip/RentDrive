namespace RentDrive.Models;

public class VehiculoModel
{
    public int ID { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Año { get; set; }
    public string Epoca { get; set; } = string.Empty;
    public string EstiloVisual { get; set; } = string.Empty;
    public string ColorExt { get; set; } = string.Empty;
    public string ColorInt { get; set; } = string.Empty;
    public bool Apto { get; set; }
    public bool TieneChofer { get; set; }
    public decimal TarifaHora { get; set; }
    public decimal TarifaDia { get; set; }
    public string ImagenURL { get; set; } = string.Empty;
    public string DescripcionEscenario { get; set; } = string.Empty;
    public List<string> Detalles { get; set; } = new List<string>();
}