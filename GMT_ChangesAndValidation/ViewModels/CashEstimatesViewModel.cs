using System.Collections.ObjectModel;
using FizzWare.NBuilder;
using GMT_ChangesAndValidation.Entities;
using GMT_ChangesAndValidation.PostSharp;

namespace GMT_ChangesAndValidation.ViewModels
{
    [Notify]
    public class CashEstimatesViewModel : ViewModel
    {
        public CashEstimatesViewModel()
        {
            var estimates = Builder<CashEstimate>.CreateListOfSize(10).Build();
            CashEstimates = new ObservableCollection<CashEstimate>(estimates);
        }

        public ObservableCollection<CashEstimate> CashEstimates { get; set; }
    }
}