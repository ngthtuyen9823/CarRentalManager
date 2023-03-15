using CarRentalManager.modals;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CarRentalManager.dao;

namespace CarRentalManager.ViewModel
{
    public class ListContractViewModel : BaseViewModel
    {
        private ObservableCollection<Contract> list;
        public ObservableCollection<Contract> List { get; set; }
        readonly ContractDAO contractDAO = new ContractDAO();

        public ListContractViewModel()
        {
            List = getListObservableContract();
        }
        public ObservableCollection<Contract> getListObservableContract()
        {
            List<Contract> contracts = contractDAO.getListContract();
            ObservableCollection<Contract> contractList = new ObservableCollection<Contract>(contracts);
            return contractList;
        }
    }
}
