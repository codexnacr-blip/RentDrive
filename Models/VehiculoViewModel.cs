namespace RentDrive.Models;

public class VehiculoViewModel
{
    public List<VehiculoModel> Vehiculos {get; set;} = new List<VehiculoModel>();

    public string? Epoca {get; set;}
    public string? Estilo {get; set;}
    public string? Color {get; set;}
    public bool Horas {get; set;}

    public List<string> Epocas {get; set;} = new List<string>();
    public List<string> Estilos {get; set;} = new List<string>();
    public List<string> Colores {get; set;} = new List<string>();
    
}