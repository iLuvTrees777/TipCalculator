using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TipCalculator.Maui.Models;

namespace TipCalculator.Maui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _importeDelConsumo;
        [ObservableProperty]
        private string _numeroDePersonas;
        [ObservableProperty]
        private string _porcentajeDePropina;

        // VAriables de instancia para los resultados de la IU
        [ObservableProperty]
        public string _importeDelConsumoDuplicado;
        [ObservableProperty]
        private string _importeDelConsumoPorPersona;
        [ObservableProperty]
        private string _importeDeLaPropina;
        [ObservableProperty]
        private string _importeDeLaPropinaPorPersona;
        [ObservableProperty]
        private string _importeTotalConPropina;
        [ObservableProperty]
        private string _importeTotalConPropinaPorPersona;
        private object consumo;
        private string impoteDelConsumoDuplicado;

        public MainViewModel()
        {
            Limpiar();
        }
        [RelayCommand]
        public void CalcularPropina()
        {
            decimal importeDelConsumo;
            decimal porcentajeDePropina;
            int numeroDePersonas;

            bool importedelConsumoValido = decimal.TryParse(ImporteDelConsumo, out importeDelConsumo);
            bool numeroDePersonasValido = int.TryParse(NumeroDePersonas, out numeroDePersonas);
            bool porcentajeDePropinaValido = decimal.TryParse(PorcentajeDePropina, out porcentajeDePropina);
            if (importedelConsumoValido && numeroDePersonasValido && porcentajeDePropinaValido)
            {
                var consumo = new ConsumoCompartido(importeDelConsumo, numeroDePersonas, porcentajeDePropina);
                ImporteDelConsumoDuplicado = importeDelConsumo.ToString("C2");
                ImporteDelConsumoPorPersona = consumo.ImporteDelConsumoPorPersona.ToString("C2");
                ImporteDeLaPropina = consumo.ImporteDeLaPropina.ToString("C2");
                ImporteDeLaPropinaPorPersona = consumo.ImporteDeLaPropinaPorPersona.ToString("C2");
                ImporteTotalConPropina = consumo.ImporteTotalConPropina.ToString("C2");
                ImporteTotalConPropinaPorPersona = consumo.ImporteTotalConPropinaPorPersona.ToString("C2");
            }
        }
        [RelayCommand]
        public void Limpiar()
        {
            ImporteDelConsumo = string.Empty;
            NumeroDePersonas = "1";
            PorcentajeDePropina = "10";
            ImporteDelConsumoDuplicado = string.Empty;
            ImporteDelConsumoPorPersona = string.Empty;
            ImporteDeLaPropina = string.Empty;
            ImporteDeLaPropinaPorPersona = string.Empty;
            ImporteTotalConPropina = string.Empty;
            ImporteTotalConPropinaPorPersona = string.Empty;
        }
        [RelayCommand]
        public void ActualizarPorcentajeDePropina(string nuevoPorcentaje)
        {
            PorcentajeDePropina = nuevoPorcentaje;
        }
    }


}
