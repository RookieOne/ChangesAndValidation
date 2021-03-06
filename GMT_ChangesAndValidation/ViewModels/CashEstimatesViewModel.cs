﻿using System.Collections.ObjectModel;
using FizzWare.NBuilder;
using GMT_ChangesAndValidation.Entities;
using GMT_ChangesAndValidation.PostSharp;

namespace GMT_ChangesAndValidation.ViewModels
{
    [IsBindable]
    public class CashEstimatesViewModel
    {
        public CashEstimatesViewModel()
        {
            var estimates = Builder<CashEstimate>.CreateListOfSize(3).Build();
            CashEstimates = new ObservableCollection<CashEstimate>(estimates);

            var salesPersons = Builder<SalesPerson>.CreateListOfSize(10).Build();
            SalesPersons = new ObservableCollection<SalesPerson>(salesPersons);
        }

        public ObservableCollection<CashEstimate> CashEstimates { get; set; }
        public ObservableCollection<SalesPerson> SalesPersons { get; set; }
    }
}